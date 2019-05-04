using Engine.Sistema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Engine2D
    {
        #region Campos
        public float _gravidade = 1F;
        private int _id_objeto = 0;
        private int _id_camera = 0;
        #endregion

        #region Propriedades
        public Camera2D Camera { get; set; }
        private List<Camera2D> Cameras { get; set; } = new List<Camera2D>();

        public bool Debug { get; set; }
        public int FPS { get; private set; }
        public long TempoDelta { get; private set; }
        public int TotalVertices { get; private set; }
        public int TotalObjetos2D { get; private set; }
        public float MaximoFPS { get; set; } = 150;
        #endregion

        public List<Objeto2D> objetos { get; set; } = new List<Objeto2D>();

        public void AddCamera(Camera2D camera)
        {
            camera.Id = _id_camera++;
            Camera2D ambiguo = this.Cameras.Where(x => x.Nome.StartsWith(camera.Nome)).LastOrDefault();

            int number = 0;
            if (ambiguo != null)
            {
                int length = camera.Nome.Length;
                int.TryParse(ambiguo.Nome.Substring(length), out number);
            }

            camera.Nome += ++number;
            Cameras.Add(camera);

            // Define a primeira camera adicionada como camera padrão
            if (Cameras.Count == 1) this.Camera = camera;
        }

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

            objeto2d.Nome += ++number;
            objetos.Add(objeto2d);
        }

        

        public void AtualizarFisica(float deltaTime)
        {
            int tick = Environment.TickCount;

            // TODO: Física

            int tempoGasto = Environment.TickCount - tick;
        }
    }
}
