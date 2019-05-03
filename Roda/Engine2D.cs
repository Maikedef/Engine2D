using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Engine2D
    {
        int id_objeto = 0;

        public Camera camera = new Camera(0, 0);
        public float gravidade = 1F;
        public int FPS { get; private set; }
        public bool Debug { get; set; }
        private int _quantQuadrosPorSegundo = 0;
        private int _tickSegundo = 0;

        /// <summary>Tempo de atraso entre uma renderização e outra</summary>
        public int TempoDelta;

        public List<Objeto2D> objetos2d { get; set; } = new List<Objeto2D>();

        public void AddObjeto(Objeto2D objeto2d)
        {
            objeto2d.id = id_objeto++;
            Objeto2D ambiguo = objetos2d.Where(x => objeto2d.nome.StartsWith(x.nome)).LastOrDefault();
            if (ambiguo != null)
            {
                int length = objeto2d.nome.Length;
                int number;
                if (int.TryParse(ambiguo.nome.Substring(length), out number))
                {
                    objeto2d.nome += number;
                }
            }
            objetos2d.Add(objeto2d);

            //Array.Resize(ref objetos2d, objetos2d.Length + 1);
            //objeto2d.id = id_objeto++;
            //objetos2d[objetos2d.Length - 1] = objeto2d;
        }

        /// <summary>
        /// Obtém o objeto 2d através do espaço. Utilize coordenadas existentes em todo o mapa 2D.
        /// </summary>
        /// <param name="ponto"></param>
        /// <returns></returns>
        public Objeto2D ObterObjeto2DPeloEspaco(Vetor2D ponto)
        {
            for (int i = 0; i < objetos2d.Count; i++)
            {
                Objeto2D obj = objetos2d[i];

                float xMax = obj.pos.x + obj.xMax;
                float xMin = obj.pos.x + obj.xMin;
                float yMax = obj.pos.y + obj.yMax;
                float yMin = obj.pos.y + obj.yMin;

                if (ponto.x >= xMin && ponto.x <= xMax)
                    if (ponto.y >= yMin && ponto.y <= yMax)
                    {
                        return objetos2d[i];
                    }
            }
            return null;
        }

        /// <summary>
        /// Obtém o objeto 2d através da camera. Utilize X = 0 a Width, Y = 0 a Height
        /// </summary>
        /// <param name="ponto"></param>
        /// <returns></returns>
        public Objeto2D ObterObjeto2DPelaCamera(Camera camera, Vetor2D ponto)
        {
            for (int i = 0; i < objetos2d.Count; i++)
            {
                Objeto2D obj = objetos2d[i];

                float xMax = -(camera.pos.x - camera.width / 2) + obj.pos.x + obj.xMax;
                float xMin = -(camera.pos.x - camera.width / 2) + obj.pos.x + obj.xMin;
                float yMax = -(camera.pos.y - camera.heigth / 2) + obj.pos.y + obj.yMax;
                float yMin = -(camera.pos.y - camera.heigth / 2) + obj.pos.y + obj.yMin;

                if (ponto.x >= xMin && ponto.x <= xMax)
                    if (ponto.y >= yMin && ponto.y <= yMax)
                    {
                        return objetos2d[i];
                    }
            }
            return null;
        }

        public void AtualizarFisica(float deltaTime)
        {
            int tick = Environment.TickCount;

            // TODO: Física

            int tempoGasto = Environment.TickCount - tick;
        }

        Point pontoA = new Point();
        Point pontoB = new Point();
        int _tickRender;
        public void Render(Camera camera, Graphics g)
        {
            TempoDelta = Environment.TickCount - _tickRender;
            _tickRender = Environment.TickCount;

            for (int i = 0; i < objetos2d.Count; i++)
            {
                Objeto2D obj = objetos2d[i];
                if (!Objeto2DVisivelNaCamera(camera, obj)) continue;

                for (int v = 1; v < obj.vertices.Length; v++)
                {
                    Vertice2D v1 = obj.vertices[v - 1]; // Ponto A
                    Vertice2D v2 = obj.vertices[v];     // Ponto B

                    // Aplica estilo ao objeto
                    EstiloObjeto2D estilo;
                    if (obj.selecionado)
                        estilo = obj.estilo_selecao;
                    else
                        estilo = obj.estilo_atual;

                    // Desenha as linhas entre as vértices na câmera
                    pontoA.X = (int)(-(camera.pos.x - camera.width / 2) + obj.pos.x + v1.x);
                    pontoA.Y = (int)(-(camera.pos.y - camera.heigth / 2) + obj.pos.y + v1.y);
                    pontoB.X = (int)(-(camera.pos.x - camera.width / 2) + obj.pos.x + v2.x);
                    pontoB.Y = (int)(-(camera.pos.y - camera.heigth / 2) + obj.pos.y + v2.y);
                    g.DrawLine(new Pen(estilo.cor_borda, estilo.pen_width), pontoA, pontoB);
                }

                // Pinta o interior do objeto 2d
                if (obj.estilo_atual.cor_interior != Color.Transparent)
                {
                    GraphicsPath preenchimento = new GraphicsPath(FillMode.Alternate);
                    preenchimento.AddLines(obj.vertices.ToList().Select(ponto => new Point(
                        (int)(-camera.pos.x + obj.pos.x + ponto.x),
                        (int)(-camera.pos.y + obj.pos.y + ponto.y))).ToArray());
                    g.FillPath(new SolidBrush(obj.estilo_atual.cor_interior), preenchimento);
                }
            }

            // Exibe informações de depuração
            if (this.Debug)
            {
                using (Font font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel))
                {
                    g.DrawString("FPS: " + FPS, font, new SolidBrush(Color.Blue), new Point(10, 10));
                    //g.DrawString($"CameraPos: {camera.pos.x},{camera.pos.y}", font, new SolidBrush(Color.Blue), new Point(80, 10));
                }
            }

            // Cáculo de Quadros por Segundo
            if (Environment.TickCount - _tickSegundo >= 1000)
            {
                FPS = _quantQuadrosPorSegundo;
                _quantQuadrosPorSegundo = 0;
                _tickSegundo = Environment.TickCount;
            }
            else
            {
                _quantQuadrosPorSegundo++;
            }

            int tempoGato = Environment.TickCount - _tickRender;
        }

        public bool Objeto2DVisivelNaCamera(Camera camera, Objeto2D objeto2d)
        {
            float xMax = -(camera.pos.x - camera.width / 2) + objeto2d.pos.x + objeto2d.xMax;
            float xMin = -(camera.pos.x - camera.width / 2) + objeto2d.pos.x + objeto2d.xMin;
            float yMax = -(camera.pos.y - camera.heigth / 2) + objeto2d.pos.y + objeto2d.yMax;
            float yMin = -(camera.pos.y - camera.heigth / 2) + objeto2d.pos.y + objeto2d.yMin;

            if (xMax >= 0 && xMin <= camera.width)
                if (yMax >= 0 && yMin <= camera.heigth)
                {
                    return true;
                }

            return false;
        }
    }
}
