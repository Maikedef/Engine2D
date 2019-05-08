using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Sistema
{
    public class Avancado2D : Objeto2DRenderizar
    {
        public virtual void GerarGeometriaRadialVariante(int angulo, int raio_min, int raio_max, int lados)
        {
            Angulo = angulo;
            Random rnd = new Random(Environment.TickCount + lados);

            float rad = (float)(Math.PI * 2 / lados);
            for (int i = 0; i < lados + 1; i++)
            {
                if (i == lados)
                {
                    AdicionarVertice(Vertices[0]);
                }
                else
                {
                    float raio = rnd.Next(raio_min, raio_max);
                    Vertice2D v = new Vertice2D();
                    v.x = (float)(Math.Sin(i * rad + Util.Angulo2Radiano(angulo)) * raio);
                    v.y = (float)(Math.Cos(i * rad + Util.Angulo2Radiano(angulo)) * raio);
                    v.rad = i * rad;
                    v.raio = raio;
                    AdicionarVertice(v);
                }
            }

            AtualizarRaio();
        }
    }
}
