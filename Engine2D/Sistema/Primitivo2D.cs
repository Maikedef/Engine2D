using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Sistema
{
    public class Primitivo2D : Objeto2DRenderizar
    {
        protected void GerarGeometriaRadial(int angulo, int raio, int lados)
        {
            Angulo = angulo;
            Raio = raio; 
            float rad = (float)(Math.PI * 2 / lados);
            for (int i = 0; i < lados + 1; i++)
            {
                Vertice2D v = new Vertice2D();
                v.x = (float)(Math.Sin(i * rad + Util.Angulo2Radiano(angulo)) * raio);
                v.y = (float)(Math.Cos(i * rad + Util.Angulo2Radiano(angulo)) * raio);
                v.rad = i * rad;
                v.raio = raio;
                AdicionarVertice(v);
            }
        }
    }
}
