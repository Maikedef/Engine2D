﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Sistema
{
    /// <summary>
    /// Luzes que herdarem este tipo serão iluminados na Câmera
    /// </summary>
    public class Luz2D : Luz2DRenderizar
    {
        public byte Intensidade { get; set; } = 128;
        public Luz2D()
        {
            Cor = new RGBA(Intensidade, 255, 255, 255); // Branco
        }

        public void GerarLuzPonto(float angulo, float raio, int lados = 20)
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
