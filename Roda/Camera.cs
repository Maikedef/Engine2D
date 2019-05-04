using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Camerar
    {
        public int id { get; set; }
        public string Nome { get; set; } = "Camera";
        public Graphics g { get; set; }

        public List<Animacao2D> animacoes = new List<Animacao2D>();

        /// <summary>Posição da Câmera no espaço</summary>
        public Vetor2D pos = new Vetor2D();

        /// <summary>Ângulo da tela</summary>
        public float angulo = 0F;
        public float zoom = 0F;

        /// <summary>Largura da tela</summary>
        public int width = 640;

        /// <summary>Altura da tela</summary>
        public int heigth = 480;

        /// <summary>Proporção de tela</summary>
        public float AspectRatio = 0F;

        public Camerar(int width, int heigth)
        {
            this.pos = new Vetor2D(0, 0);
            this.width = width;
            this.heigth = heigth;
        }
    }
}
