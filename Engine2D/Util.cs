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
        public static float Angulo2Radiano(this float angulo) => angulo * (float)Math.PI / 180;
        public static float DistanciaEntreDoisPontos(Vetor2D pontoA, Vetor2D pontoB) => DistanciaEntreDoisPontos(pontoA.x, pontoA.y, pontoB.x, pontoB.y);
        public static float DistanciaEntreDoisPontos(float x1, float y1, float x2, float y2) => (float)(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));
        public static float AnguloEntreDoisPontos(Vetor2D pontoA, Vetor2D pontoB) => AnguloEntreDoisPontos(pontoA.x, pontoA.y, pontoB.x, pontoB.y);
        public static float AnguloEntreDoisPontos(float x1, float y1, float x2, float y2) => (float)(Math.Atan2(y2 - y1, x2 - x1) * 180 / Math.PI);

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
