using Engine.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Objetos2D.Primitivos
{
    public sealed class Circulo : Primitivo2D
    {
        public Circulo()
        {
            Nome = "Circulo";
        }

        public void GerarGeometria(int angulo, int raio, int lados = 20)
        {
            GerarGeometriaRadial(angulo, raio, lados);
        }
    }
}
