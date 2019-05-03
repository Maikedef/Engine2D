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
        public Camera camera = new Camera(0, 0, 0, 0);
        public float gravidade = 1F;
        public int QuadrosPorSegundo { get; private set; }
        public bool Debug { get; set; }
        private int _quantQuadrosPorSegundo = 0;
        private int _tickSegundo = 0;

        Objeto2D[] objetos2d = new Objeto2D[0];

        public void AddObjeto(Objeto2D objeto2d)
        {
            Array.Resize(ref objetos2d, objetos2d.Length + 1);
            objetos2d[objetos2d.Length - 1] = objeto2d;
        }

        /// <summary>
        /// Obtém o objeto 2d através do espaço
        /// </summary>
        /// <param name="ponto"></param>
        /// <returns></returns>
        public Objeto2D ObterObjeto2DPeloEspaco(Vetor2D ponto)
        {
            for (int i = 0; i < objetos2d.Length; i++)
            {
                Objeto2D obj = objetos2d[i];

                float xMax = obj.pos.x + obj.vertices.Max(x => x.x);
                float xMin = obj.pos.x + obj.vertices.Min(x => x.x);
                float yMax = obj.pos.y + obj.vertices.Max(x => x.y);
                float yMin = obj.pos.y + obj.vertices.Min(x => x.y);

                if (ponto.x >= xMin && ponto.x <= xMax)
                    if (ponto.y >= yMin && ponto.y <= yMax)
                    {
                        return objetos2d[i];
                    }
            }
            return null;
        }

        /// <summary>
        /// Obtém o objeto 2d através da camera
        /// </summary>
        /// <param name="ponto"></param>
        /// <returns></returns>
        public Objeto2D ObterObjeto2DPelaCamera(Camera camera, Vetor2D ponto)
        {
            for (int i = 0; i < objetos2d.Length; i++)
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



            int tempoGasto = Environment.TickCount - tick;
        }

        public void Render(Camera camera, Graphics g)
        {
            int tick = Environment.TickCount;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < objetos2d.Length; i++)
            {
                Objeto2D obj = objetos2d[i];

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

                    // Desenha apenas objetos que visíveis na câmera

                    // Desenha as linhas entre as vértices na câmera
                    g.DrawLine(
                        new Pen(estilo.cor_borda, estilo.pen_width), 
                        new Point((int)(-(camera.pos.x - camera.width / 2) + obj.pos.x + v1.x), (int)(-(camera.pos.y - camera.heigth / 2) + obj.pos.y + v1.y)), 
                        new Point((int)(-(camera.pos.x - camera.width / 2) + obj.pos.x + v2.x), (int)(-(camera.pos.y - camera.heigth / 2) + obj.pos.y + v2.y)));

                    // Pinta o interior do(s) objeto(s) 2d na câmera
                    if (obj.estilo_atual.cor_interior != Color.Transparent)
                    {
                        GraphicsPath preenchimento = new GraphicsPath(FillMode.Alternate);
                        preenchimento.AddLines(obj.vertices.ToList().Select(ponto => new Point(
                            (int)(-camera.pos.x + obj.pos.x + ponto.x), 
                            (int)(-camera.pos.y + obj.pos.y + ponto.y))).ToArray());
                        g.FillPath(new SolidBrush(obj.estilo_atual.cor_interior), preenchimento);

                    }
                    
                    // Exibe informações de depuração
                    if (this.Debug)
                    {
                        using (Font font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel))
                        {
                            g.DrawString("FPS: " + QuadrosPorSegundo, font, new SolidBrush(Color.Blue), new Point(10, 10));
                            g.DrawString($"CameraPos: {camera.pos.x},{camera.pos.y}", font, new SolidBrush(Color.Blue), new Point(80, 10));
                        }
                    }
                }
            }

            // Cáculo de Quadros por Segundo
            if (Environment.TickCount - _tickSegundo >= 1000)
            {
                QuadrosPorSegundo = _quantQuadrosPorSegundo;
                _quantQuadrosPorSegundo = 0;
                _tickSegundo = Environment.TickCount;
            }
            else
            {
                _quantQuadrosPorSegundo++;
            }

            int tempoGato = Environment.TickCount - tick;
        }

        public bool Objeto2DVisivelNaCamera(Camera camera, Objeto2D objeto2d)
        {
            float xMax = -(camera.pos.x - camera.width / 2) + objeto2d.pos.x + objeto2d.xMax;
            float xMin = -(camera.pos.x - camera.width / 2) + objeto2d.pos.x + objeto2d.xMin;
            float yMax = -(camera.pos.y - camera.heigth / 2) + objeto2d.pos.y + objeto2d.yMax;
            float yMin = -(camera.pos.y - camera.heigth / 2) + objeto2d.pos.y + objeto2d.yMin;

            if (xMax > camera.pos.x || xMin > camera.pos.x)
                if (yMax > camera.pos.y || yMin > camera.pos.y)
                {
                    return true;
                }

            return false;
        }
    }
}
