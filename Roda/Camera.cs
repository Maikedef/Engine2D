using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Camera
    {
        public List<Animacao> animacoes = new List<Animacao>();

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

        public Camera(int width, int heigth)
        {
            this.pos = new Vetor2D(0, 0);
            this.width = width;
            this.heigth = heigth;
        }
    }
}
