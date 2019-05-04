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
        public long TempoDelta { get; private set; }
        public float Zoom { get; internal set; }
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
        readonly Font font_debug = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel);
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
                if (obj == null || !Objeto2DVisivel(obj)) continue;

                if (obj.Mat_render.CorSolida.A > 0) // Se não transparente...
                {
                    GraphicsPath preenche = new GraphicsPath(FillMode.Alternate);
                    preenche.AddLines(obj.Vertices.ToList().Select(ponto => new Point(
                        (int)(-fatorCam.X + obj.Pos.x + ponto.x),
                        (int)(-fatorCam.Y + obj.Pos.y + ponto.y))).ToArray());
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

                for (int v = 1; v < obj.Vertices.Length; v++)
                {
                    Vertice2D v1 = obj.Vertices[v - 1]; // Ponto A
                    Vertice2D v2 = obj.Vertices[v];     // Ponto B

                    // Desenha as linhas entre as vértices na câmera
                    pontoA.X = (int)(-fatorCam.X + obj.Pos.x + v1.x);
                    pontoA.Y = (int)(-fatorCam.Y + obj.Pos.y + v1.y);
                    pontoB.X = (int)(-fatorCam.X + obj.Pos.x + v2.x);
                    pontoB.Y = (int)(-fatorCam.Y + obj.Pos.y + v2.y);

                    g.DrawLine(pen, pontoA, pontoB);
                }
            }

            #region Exibe informações de depuração
            if (engine.Debug)
            {
                g.DrawString(Nome, font_debug, new SolidBrush(Color.Blue), new Point(10, 10));
                g.DrawString("FPS: " + FPS, font_debug, new SolidBrush(Color.Blue), new Point(10, 30));
                
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

            return render;
        }
    }
}
