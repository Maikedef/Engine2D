using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda
{
    public class Engine2D
    {
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

        public Objeto2D ObterObjetoPeloPonto2D(Vector2D ponto)
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

        public void AtualizarFisica(float deltaTime)
        {
            int tick = Environment.TickCount;



            int tempoGasto = Environment.TickCount - tick;
        }

        public void Render(Graphics g)
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

                    g.DrawLine(
                        new Pen(estilo.cor, estilo.pen_width), 
                        new Point((int)(obj.pos.x + v1.x), (int)(obj.pos.y + v1.y)), 
                        new Point((int)(obj.pos.x + v2.x), (int)(obj.pos.y + v2.y)));

                    if (this.Debug)
                    {
                        using (Font font = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Pixel))
                        {
                            Point point = new Point(10, 10);
                            g.DrawString("FPS: " + QuadrosPorSegundo, font, new SolidBrush(Color.Blue), point);
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
    }
}
