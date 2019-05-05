using Engine.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Objetos2D.Primitivos
{
    public sealed class Pentagono : Primitivo2D
    {
        public Pentagono()
        {
            Nome = "Pentagono";
        }

        public void GerarGeometria(int angulo, int raio)
        {
            GerarGeometriaRadial(angulo, raio, 5);
        }
    }
}