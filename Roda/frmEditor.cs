using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roda
{
    public partial class Form1 : Form
    {
        Engine2D engine2D = new Engine2D();
        Objeto2D circulo = new Objeto2D();

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            circulo.nome = "Triangulo1";
            circulo.pos.x = 100;
            circulo.pos.y = 200;
            circulo.GerarCirculo(50,3);
            engine2D.AddObjeto(circulo);
        }

        private void AtualizarControles(Objeto2D objeto2d)
        {
            txtNome.Text = objeto2d.nome;
            txtPosX.Text = objeto2d.pos.x.ToString();
            txtPosY.Text = objeto2d.pos.y.ToString();
            txtAngulo.Text = objeto2d.angulo.ToString();
        }

        private void TmrRender_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void PicDesign_Paint(object sender, PaintEventArgs e)
        {
            engine2D.Render(e.Graphics);
        }

        private void PicDesign_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
