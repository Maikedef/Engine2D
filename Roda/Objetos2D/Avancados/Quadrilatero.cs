using Engine.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Objetos2D.Avancados
{
    public sealed class Quadrilatero : Avancado2D
    {
        public Quadrilatero()
        {
            Nome = "Quadrilatero";
        }

        public void GerarGeometria(int angulo, int raio_min, int raio_max)
        {
            GerarGeometriaRadialVariante(angulo, raio_min, raio_max, 5);
        }
    }
}
