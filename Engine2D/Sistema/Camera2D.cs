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
        public PixelFormat FormatoPixel = PixelFormat.Format32bppArgb;
        public InterpolationMode ModoInterpolacao = InterpolationMode.Bilinear;
        public SmoothingMode ModoSuavidade = SmoothingMode.AntiAlias;
        public CompositingMode ModoComposicao = CompositingMode.SourceOver;
        public CompositingQuality QualidadeComposicao = CompositingQuality.Default;
        public PixelOffsetMode ModoDeslocamentoPixel = PixelOffsetMode.Default;
        private int _fps;
        private int _tickFPS;
        #endregion

        #region Propriedades
        public int FPS { get; private set; }
        private int _maxFPS { get; set; } = 60;
        private float _tickMaxFPS { get; set; }
        /// <summary>Tempo de atraso entre uma e outra renderização</summary>
        public long TempoDelta { get; private set; }
        public float ZoomCamera { get; set; } = 1F;

        public bool DesligarSistemaZoom { get; set; } = true;
        #endregion

        public Camera2D(Engine2D engine, int width, int height)
        {
            this.engine = engine;
            IniciarCamera(width, height, FormatoPixel);
        }

        public Camera2D(Engine2D engine, int width, int height, PixelFormat formatoPixel)
        {
            this.engine = engine;
            IniciarCamera(width, height, formatoPixel);
        }

        private void IniciarCamera(int width, int heigth, PixelFormat formatoPixel)
        {
            Nome = "Camera";
            FormatoPixel = formatoPixel;
            ResWidth = width;
            ResHeigth = heigth;
            render = new Bitmap(width, heigth, formatoPixel);
            g = Graphics.FromImage(render);
            g.SmoothingMode = ModoSuavidade;
            g.InterpolationMode = ModoInterpolacao;
            g.CompositingMode = ModoComposicao;
            g.CompositingQuality = QualidadeComposicao;
            g.PixelOffsetMode = ModoDeslocamentoPixel;
            DefineFPSMaximo(_maxFPS);
        }

        public void RedefinirResolucao(int width, int height) => RedefinirResolucao(width, height, FormatoPixel);

        public void RedefinirResolucao(int width, int height, PixelFormat pixelFormat)
        {
            if (width > 0 && height > 0)
            {
                render.Dispose();
                g.Dispose();

                FormatoPixel = pixelFormat;
                ResWidth = width;
                ResHeigth = height;
                render = new Bitmap(width, height, pixelFormat);
                g = Graphics.FromImage(render);
                g.SmoothingMode = ModoSuavidade;
                g.InterpolationMode = ModoInterpolacao;
                g.CompositingMode = ModoComposicao;
                g.CompositingQuality = QualidadeComposicao;
                g.PixelOffsetMode = ModoDeslocamentoPixel;
            }
        }
        public void DefineFPSMaximo(int maxFPS)
        {
            this._maxFPS = maxFPS;
            this._tickMaxFPS = 1000 / maxFPS;
        }

        /// <summary>
        /// Incrementa o Zoom
        /// </summary>
        public void Zoom(float valor)
        {
            this.ZoomCamera += valor;
        }

        /// <summary>
        /// Define o Zoom da Câmera
        /// </summary>
        public void DefinirZoom(float zoom)
        {
            ZoomCamera = zoom;
        }

        /// <summary>
        /// Centraliza a camera em cima do objeto alvo
        /// </summary>
        /// <param name="obj"></param>
        public void FocarNoObjeto2D(Objeto2D obj)
        {
            Pos = obj.Pos;
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
        Point fatorCam = new Point();
        long _tickRender;
        Pen pen = new Pen(new SolidBrush(Color.Black), 1);
        readonly Font font_debug = new Font("Lucida Console", 12, FontStyle.Regular, GraphicsUnit.Pixel);
        #endregion

        public Bitmap Renderizar()
        {
            TempoDelta = DateTime.Now.Ticks - _tickRender; // Calcula o tempo delta (tempo de atraso)
            _tickRender = DateTime.Now.Ticks;

            if (ResWidth > 0 && ResHeigth > 0) // Janela não minimizada?
            {
                g.Clear(Color.Black);

                // Obtém o fator da câmera conforme sua posição
                fatorCam.X = (int)Pos.x - ResWidth / 2;
                fatorCam.Y = (int)Pos.y - ResHeigth / 2;

                for (int i = 0; i < engine.objetos.Count; i++)
                {
                    Objeto2DRenderizar obj = engine.objetos[i] as Objeto2DRenderizar;
                    if (obj == null) continue;

                    #region ZOOM
                    if (!DesligarSistemaZoom)
                    {
                        obj = (Objeto2DRenderizar)obj.Clone();
                        Objeto2D objZoom = ZoomEscalaObjeto2D(obj, ZoomCamera);
                        Objeto2D objPosZoom = ZoomPosObjeto2D(obj, ZoomCamera);
                        objZoom.Pos = objPosZoom.Pos;
                    }
                    #endregion

                    if (!Objeto2DVisivel(obj)) continue;

                    if (obj.Mat_render.CorSolida.A > 0) // Pinta objeto materialmente visível
                    {
                        GraphicsPath preenche = new GraphicsPath(FillMode.Alternate);
                        preenche.AddLines(obj.Vertices.ToList().Select(ponto => new Point(
                            (int)(-fatorCam.X + obj.Pos.x + ponto.x),
                            (int)(-fatorCam.Y + obj.Pos.y + ponto.y))).ToArray());
                        g.FillPath(new SolidBrush(Color.FromArgb(obj.Mat_render.CorSolida.A, obj.Mat_render.CorSolida.R, obj.Mat_render.CorSolida.G, obj.Mat_render.CorSolida.B)), preenche);
                    }

                    // Materialização do objeto na Câmera
                    Material mat;
                    if (obj.Selecionado)
                        mat = obj.Mat_render_sel;
                    else
                        mat = obj.Mat_render;

                    if (mat.CorBorda.A > 0) // Desenha borda materialmente visível
                    {
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
                }

                #region Exibe informações de depuração
                if (engine.Debug)
                {
                    g.DrawString(Nome.ToUpper(), font_debug, new SolidBrush(Color.Aquamarine), new Point(10, 10));
                    g.DrawString("FPS: " + FPS, font_debug, new SolidBrush(Color.Aquamarine), new Point(10, 30));

                }
                #endregion
            }

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
        private Objeto2D ZoomEscalaObjeto2D(Objeto2D obj, float zoom)
        {
            for (int i = 0; i < obj.Vertices.Length; i++)
            {
                obj.Vertices[i].x = (float)(Math.Sin(obj.Vertices[i].rad + Util.Angulo2Radiano(obj.Angulo)) * obj.Vertices[i].raio * zoom);
                obj.Vertices[i].y = (float)(Math.Cos(obj.Vertices[i].rad + Util.Angulo2Radiano(obj.Angulo)) * obj.Vertices[i].raio * zoom);
            }
            obj.AtualizarXYMinMax();

            return obj;
        }

        /// <summary>
        /// Trabalha o Zoom orientado a posição do objeto em relação ao centro da camera
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        private Objeto2D ZoomPosObjeto2D(Objeto2D obj, float zoom)
        {
            // TODO: Precisa rever este conceito. Há erro no cálculo!

            float radZoom = Util.Angulo2Radiano(Util.AnguloEntreDoisPontos(Pos, obj.Pos));
            float distZoom = (float)(Util.DistanciaEntreDoisPontos(Pos, obj.Pos) * zoom);
            obj.Pos.x += (float)(Math.Cos(radZoom) * distZoom);
            obj.Pos.y += (float)(Math.Sin(radZoom) * distZoom);
            
            return obj;
        }
    }
}
