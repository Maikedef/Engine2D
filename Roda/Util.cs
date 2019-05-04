using Engine.Sistema;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Util
    {
        public static float Angulo2Radiano(this float angulo)
        {
            return angulo * (float)Math.PI / 180;
        }

        

        /// <summary>
        /// Obtém o objeto 2d através do espaço. Utilize coordenadas existentes em todo o mapa 2D.
        /// </summary>
        /// <param name="ponto"></param>
        /// <returns></returns>
        public static Objeto2D ObterObjeto2DPeloEspaco(this Engine2D engine, Vetor2D ponto)
        {
            for (int i = 0; i < engine.objetos.Count; i++)
            {
                Objeto2D obj = engine.objetos[i];

                float xMax = obj.Pos.x + obj.XMax;
                float xMin = obj.Pos.x + obj.XMin;
                float yMax = obj.Pos.y + obj.YMax;
                float yMin = obj.Pos.y + obj.YMin;

                if (ponto.x >= xMin && ponto.x <= xMax)
                    if (ponto.y >= yMin && ponto.y <= yMax)
                    {
                        return engine.objetos[i];
                    }
            }
            return null;
        }

        /// <summary>
        /// Obtém o objeto 2d através da camera. Utilize X = 0 a Width, Y = 0 a Height
        /// </summary>
        /// <param name="ponto"></param>
        /// <returns></returns>
        public static Objeto2D ObterObjeto2DPelaCamera(this Engine2D engine, Camera2D camera, Vetor2D ponto)
        {
            for (int i = 0; i < engine.objetos.Count; i++)
            {
                Objeto2D obj = engine.objetos[i];

                float xMax = -(camera.Pos.x - camera.ResWidth / 2) + obj.Pos.x + obj.XMax;
                float xMin = -(camera.Pos.x - camera.ResWidth / 2) + obj.Pos.x + obj.XMin;
                float yMax = -(camera.Pos.y - camera.ResHeigth / 2) + obj.Pos.y + obj.YMax;
                float yMin = -(camera.Pos.y - camera.ResHeigth / 2) + obj.Pos.y + obj.YMin;

                if (ponto.x >= xMin && ponto.x <= xMax)
                    if (ponto.y >= yMin && ponto.y <= yMax)
                    {
                        return engine.objetos[i];
                    }
            }
            return null;
        }

        
    }
}
