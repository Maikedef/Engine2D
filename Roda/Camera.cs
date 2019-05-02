using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Camera
    {
        public Vector2D pos = new Vector2D();
        public float angulo = 0F;
        public float zoom = 0F;
        public float width = 0F;
        public float heigth = 0F;

        public Camera(float x, float y, float width, float heigth)
        {
            this.pos = new Vector2D(x, y);
            this.width = width;
            this.heigth = heigth;
        }
    }
}
