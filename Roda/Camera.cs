using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Camera
    {
        /// <summary>Posição da Câmera no espaço</summary>
        public Vetor2D pos = new Vetor2D();

        /// <summary>Ângulo da tela</summary>
        public float angulo = 0F;
        public float zoom = 0F;

        /// <summary>Largura da tela</summary>
        public float width = 0F;

        /// <summary>Altura da tela</summary>
        public float heigth = 0F;

        /// <summary>Proporção de tela</summary>
        public float AspectRatio = 0F;

        public Camera(float x, float y, float width, float heigth)
        {
            this.pos = new Vetor2D(x, y);
            this.width = width;
            this.heigth = heigth;
        }
    }
}
