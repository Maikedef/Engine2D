using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct Vetor2D
    {
        public float x;
        public float y;

        public Vetor2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public struct Vertice2D
    {
        public float x;
        public float y;
        public float rad;
        public float raio;
    }
}
