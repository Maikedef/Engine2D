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

        public void Render(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < objetos2d.Length; i++)
            {
                Objeto2D obj = objetos2d[i];

                for (int v = 1; v < obj.vertices.Length; v++)
                {
                    Vertice2D v1 = obj.vertices[v - 1];
                    Vertice2D v2 = obj.vertices[v];

                    Color cor = obj.cor;
                    if (obj.selecionado) cor = Color.Blue;

                    g.DrawLine(
                        new Pen(cor), 
                        new Point((int)(obj.pos.x + v1.x), (int)(obj.pos.y + v1.y)), 
                        new Point((int)(obj.pos.x + v2.x), (int)(obj.pos.y + v2.y)));
                }
            }
        }
    }
}
