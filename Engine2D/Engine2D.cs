using Engine.Sistema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Engine2D
    {
        #region Campos
        private int _id_objeto = 0;
        private int _id_camera = 0;
        #endregion

        #region Propriedades
        public long TempoDelta => Camera.TempoDelta;
        public Camera2D Camera { get; set; }
        public List<Camera2D> Cameras { get; set; } = new List<Camera2D>();

        public bool Debug { get; set; }
        #endregion

        public List<Objeto2D> objetos { get; set; } = new List<Objeto2D>();
        public int MaximoFPS { get; internal set; }

        public void AddObjeto(Objeto2D objeto2d)
        {
            objeto2d.Id = _id_objeto++;
            Objeto2D ambiguo = objetos.Where(x => x.Nome.StartsWith(objeto2d.Nome)).LastOrDefault();

            int number = 0;
            if (ambiguo != null)
            {
                int length = objeto2d.Nome.Length;
                int.TryParse(ambiguo.Nome.Substring(length), out number);
            }

            objeto2d.Nome += (++number).ToString("D2");
            objetos.Add(objeto2d);
        }


        public Camera2D CriarCamera(int width, int heigth)
        {
            return CriarCamera(width, heigth, PixelFormat.Format32bppRgb);
        }
        public Camera2D CriarCamera(int width, int heigth, PixelFormat pixelFormat)
        {
            Camera2D camera = new Camera2D(this, width, heigth, pixelFormat);

            camera.Id = _id_camera++;
            Camera2D ambiguo = Cameras.Where(x => x.Nome.StartsWith(camera.Nome)).LastOrDefault();

            int number = 0;
            if (ambiguo != null)
            {
                int length = camera.Nome.Length;
                int.TryParse(ambiguo.Nome.Substring(length), out number);
            }

            camera.Nome += (++number).ToString("D2");
            Cameras.Add(camera);

            // Define a primeira camera adicionada como camera padrão
            if (Cameras.Count == 1) Camera = camera;

            return camera;
        }

        public void AtualizarFisica(float deltaTime)
        {
            int tick = Environment.TickCount;

            // TODO: Física

            int tempoGasto = Environment.TickCount - tick;
        }
    }
}
