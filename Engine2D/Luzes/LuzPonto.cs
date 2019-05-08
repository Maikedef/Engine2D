﻿using Engine.Sistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Luzes
{
    public sealed class LuzPonto : Luz2D
    {
        public LuzPonto(byte intensidade, float raio)
        {
            Nome = "LuzPonto";
            GerarLuzPonto(0, raio);
        }
    }
}
