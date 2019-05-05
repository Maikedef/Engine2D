using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Sistema
{
    public sealed class Camera2D : Objeto2D
    {
        readonly Engine2D engine;
        Bitmap render;
        Graphics g;

        #region Campos
        public int ResWidth;
        public int ResHeigth;
        public PixelFormat PixelFormat = PixelFormat.Format32bppRgb;
        private int _fps;
        private int _tickFPS;
        #endregion

        #region Propriedades
        public int FPS { get; private set; }
        private int _maxFPS { get; set; } = 60;
        private float _TickFPSConstante { get; set; }
        public long TempoDelta { get; private set; }
        public float ZoomCamera { get; set; } = 1F;
        #endregion

        public Camera2D(Engine2D engine, int width, int height)
        {
            this.engine = engine;
            IniciarCamera(width, height, PixelFormat);
        }

        public Camera2D(Engine2D engine, int width, int height, PixelFormat pixelFormat)
        {
            this.engine = engine;
            IniciarCamera(width, height, pixelFormat);
        }

        private void IniciarCamera(int width, int heigth, PixelFormat pixelFormat)
        {
            DefineMaxFPS(_maxFPS);

            Nome = "Camera";

            PixelFormat = pixelFormat;
            ResWidth = width;
            ResHeigth = heigth;
            render = new Bitmap(width, heigth, pixelFormat);
            g = Graphics.FromImage(render);
        }

        public void RedefinirResolucao(int width, int height) => RedefinirResolucao(width, height, PixelFormat);

        public void RedefinirResolucao(int width, int height, PixelFormat pixelFormat)
        {
            render.Dispose();
            PixelFormat = pixelFormat;
            ResWidth = width;
            ResHeigth = height;
            render = new Bitmap(width, height, pixelFormat);
        }
        public void DefineMaxFPS(int maxFPS)
        {
            this._maxFPS = maxFPS;
            this._TickFPSConstante = 1000 / maxFPS;
        }

        /// <summary>
        /// Infrementa Zoom na camera
        /// </summary>
        public void Zoom(float valor)
        {
            this.ZoomCamera += valor;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DefinirZoom(float zoom)
        {
            ZoomCamera = zoom;
        }

        public bool Objeto2DVisivel(Objeto2D obj)
        {
            float xMax = -(Pos.x - ResWidth / 2) + obj.Pos.x + obj.XMax;
            float xMin = -(Pos.x - ResWidth / 2) + obj.Pos.x + obj.XMin;
            float yMax = -(Pos.y - ResHeigth / 2) + obj.Pos.y + obj.YMax;
            float yMin = -(Pos.y - ResHeigth / 2) + obj.Pos.y + obj.YMin;

            if (xMax >= 0 && xMin <= ResWidth)
                if (yMax >= 0 && yMin <= ResHeigth)
                {
                    return true;
                }

            return false;
        }

        #region Atributos de otimização do Renderizador
        Point pontoA = new Point();
        Point pontoB = new Point();
        long _tickRender;
        Pen pen = new Pen(new SolidBrush(Color.Black), 1);
        readonly Font font_debug = new Font("Lucida Console", 12, FontStyle.Regular, GraphicsUnit.Pixel);
        #endregion

        public Bitmap Renderizar()
        {
            TempoDelta = DateTime.Now.Ticks - _tickRender; // Calcula o tempo delta (tempo de atraso)
            _tickRender = DateTime.Now.Ticks;

            g.Clear(Color.Black);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Obtém o fator da câmera conforme sua posição

            Point fatorCam = new Point((int)Pos.x - ResWidth / 2, (int)Pos.y - ResHeigth / 2);

            for (int i = 0; i < engine.objetos.Count; i++)
            {
                Objeto2DRenderizar obj = engine.objetos[i] as Objeto2DRenderizar;
                if (obj == null) continue;

                Objeto2D objZoom = ZoomObjeto2D(obj, ZoomCamera);
                objZoom = ZoomPosObjeto2D(objZoom, ZoomCamera);

                

                if (!Objeto2DVisivel(objZoom)) continue;

                if (obj.Mat_render.CorSolida.A > 0) // Se não transparente...
                {
                    GraphicsPath preenche = new GraphicsPath(FillMode.Alternate);
                    preenche.AddLines(objZoom.Vertices.ToList().Select(ponto => new Point(
                        (int)(-fatorCam.X + objZoom.Pos.x + ponto.x),
                        (int)(-fatorCam.Y + objZoom.Pos.y + ponto.y))).ToArray());
                    g.FillPath(new SolidBrush(Color.FromArgb(obj.Mat_render.CorSolida.A, obj.Mat_render.CorSolida.R, obj.Mat_render.CorSolida.G, obj.Mat_render.CorSolida.B)), preenche);
                }

                // Materializa o objeto na Câmera
                Material mat;
                if (obj.Selecionado)
                    mat = obj.Mat_render_sel;
                else
                    mat = obj.Mat_render;

                // Cor da borda do objeto
                pen.Color = Color.FromArgb(mat.CorBorda.A, mat.CorBorda.R, mat.CorBorda.G, mat.CorBorda.B);
                pen.Width = mat.LarguraBorda;

                for (int v = 1; v < objZoom.Vertices.Length; v++)
                {
                    Vertice2D v1 = objZoom.Vertices[v - 1]; // Ponto A
                    Vertice2D v2 = objZoom.Vertices[v];     // Ponto B

                    // Desenha as linhas entre as vértices na câmera
                    pontoA.X = (int)(-fatorCam.X + objZoom.Pos.x + v1.x);
                    pontoA.Y = (int)(-fatorCam.Y + objZoom.Pos.y + v1.y);
                    pontoB.X = (int)(-fatorCam.X + objZoom.Pos.x + v2.x);
                    pontoB.Y = (int)(-fatorCam.Y + objZoom.Pos.y + v2.y);

                    g.DrawLine(pen, pontoA, pontoB);
                }
            }

            #region Exibe informações de depuração
            if (engine.Debug)
            {
                g.DrawString(Nome.ToUpper(), font_debug, new SolidBrush(Color.Aquamarine), new Point(10, 10));
                g.DrawString("FPS: " + FPS, font_debug, new SolidBrush(Color.Aquamarine), new Point(10, 30));
                
            }
            #endregion

            #region Calcula o FPS
            if (Environment.TickCount - _tickFPS >= 1000)
            {
                _tickFPS = Environment.TickCount;
                FPS = _fps;
                _fps = 0;
            }
            else _fps++;
            #endregion

            #region Limita o FPS
            // TODO: Limitar o FPS
            #endregion

            return render;
        }

        /// <summary>
        /// Trabalha o Zoom orientado a escala do objeto
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        private Objeto2D ZoomObjeto2D(Objeto2D obj, float zoom)
        {
            Objeto2D clone = (Objeto2D)obj.Clone();

            for (int i = 0; i < clone.Vertices.Length; i++)
            {
                clone.Vertices[i].x = (float)Math.Sin(clone.Vertices[i].rad + Util.Angulo2Radiano(clone.Angulo)) * clone.Vertices[i].raio * zoom;
                clone.Vertices[i].y = (float)Math.Cos(clone.Vertices[i].rad + Util.Angulo2Radiano(clone.Angulo)) * clone.Vertices[i].raio * zoom;
            }
            clone.AtualizarXYMinMax();

            return clone;
        }

        /// <summary>
        /// Trabalha o Zoom orientado a posição do objeto em relação ao centro da camera
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        private Objeto2D ZoomPosObjeto2D(Objeto2D obj, float zoom)
        {
            float radZoom = Util.Angulo2Radiano(Util.AnguloEntreDoisPontos(Pos, obj.Pos));
            float distZoom = Util.DistanciaEntreDoisPontos(Pos, obj.Pos) * zoom;
            obj.Pos.x += (float)Math.Cos(radZoom) * distZoom;
            obj.Pos.y += (float)Math.Sin(radZoom) * distZoom;

            return obj;
        }
    }
}
