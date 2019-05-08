using Engine.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Objetos2D.Primitivos
{
    public class Triangulo : Primitivo2D
    {
        public Triangulo()
        {
            Nome = "Triangulo";
        }

        public void GerarGeometria(int angulo, int raio)
        {
            GerarGeometriaRadial(angulo, raio, 3);
        }
    }
}