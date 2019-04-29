﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roda
{
    public struct Vector2D
    {
        public float x;
        public float y;
    }

    public struct Vertice2D
    {
        public float x;
        public float y;
        public float rad;
        public float raio;
        public Color cor;
    }
    public class Objeto2D
    {
        public string nome;
        public Vector2D pos;
        public Color cor = Color.Black;
        public float raio = 0F;
        public float angulo = 0F;
        public Vertice2D[] vertices;

        public void AddVertice(Vertice2D vetor)
        {
            Array.Resize(ref vertices, vertices.Length + 1);
            vertices[vertices.Length - 1] = vetor;
        }

        public void GerarCirculo(float raio, int quant = 20)
        {
            GerarObjetoRadial(raio, quant);
        }

        public void GerarTriangulo(float raio)
        {
            GerarObjetoRadial(raio, 3);
        }

        public void GerarQuadrado(float raio)
        {
            GerarObjetoRadial(raio, 4);
        }

        public void GerarPentagono(float raio)
        {
            GerarObjetoRadial(raio, 5);
        }

        public void GerarObjetoRadial(float raio, int lados)
        {
            vertices = new Vertice2D[lados + 1];
            this.raio = raio;
            float rad = (float)(Math.PI * 2 / lados);
            for (int i = 0; i < lados + 1; i += 1)
            {
                Vertice2D v = new Vertice2D();
                v.x = (float)(Math.Sin(i * rad) * raio);
                v.y = (float)(Math.Cos(i * rad) * raio);
                v.cor = Color.Black;
                v.rad = i * rad;
                v.raio = raio;
                vertices[i] = v;
            }
        }

        public void DefinirAngulo(float novoAngulo)
        {
            this.angulo = novoAngulo;
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].x = (float)Math.Sin(vertices[i].rad + Angulo2Radiano(novoAngulo)) * vertices[i].raio;
                vertices[i].y = (float)Math.Cos(vertices[i].rad + Angulo2Radiano(novoAngulo)) * vertices[i].raio;
            }
        }
        private float Angulo2Radiano(float angulo)
        {
            return angulo * (float)Math.PI / 180;
        }
    }
}