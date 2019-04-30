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
        int raio_padrao = 50;
        Engine2D engine2D = new Engine2D();
        Objeto2D obj_selecionado = new Objeto2D();

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
            txtPosX.Maximum = txtPosY.Maximum = txtAngulo.Maximum = txtRaio.Maximum = decimal.MaxValue;
            txtPosY.Minimum = txtPosY.Minimum = txtAngulo.Minimum = txtRaio.Minimum = decimal.MinValue;

            BtnCirculo_Click(sender, e);
        }

        private void AtualizarControles(Objeto2D objeto2d)
        {
            if (objeto2d != null)
            {
                txtNome.Text = objeto2d.nome;
                txtPosX.Text = objeto2d.pos.x.ToString();
                txtPosY.Text = objeto2d.pos.y.ToString();
                txtAngulo.Text = objeto2d.angulo.ToString();
                txtRaio.Text = objeto2d.raio.ToString();
            }
            else
            {
                txtNome.Text = string.Empty;
                txtPosX.Text = string.Empty;
                txtPosY.Text = string.Empty;
                txtAngulo.Text = string.Empty;
                txtRaio.Text = string.Empty;
            }
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
            Vector2D ponto = new Vector2D();
            ponto.x = e.X;
            ponto.y = e.Y;

            Objeto2D novo_obj_selecionado = engine2D.ObterObjetoPeloPonto2D(ponto);
            AtualizarControles(novo_obj_selecionado);

            // Seleciona o novo objeto
            if (novo_obj_selecionado != null)
            {
                if (obj_selecionado != null) obj_selecionado.selecionado = false; // Deseleciona o objeto anterior
                obj_selecionado = novo_obj_selecionado; // Define o novo objeto selecionado
                novo_obj_selecionado.selecionado = true; // Define como selecionado
            }
        }

        private Vector2D PosAleatorio()
        {
            int x = new Random(Environment.TickCount).Next(0, picDesign.ClientRectangle.Width);
            int y = new Random(Environment.TickCount + x).Next(0, picDesign.ClientRectangle.Height);

            return new Vector2D(x, y);
        }

        private void BtnQuadrado_Click(object sender, EventArgs e)
        {
            Objeto2D quadrado = new Objeto2D();
            quadrado.nome = "Quadrado1";
            quadrado.pos = PosAleatorio();
            quadrado.GerarQuadrado(raio_padrao);
            engine2D.AddObjeto(quadrado);
        }

        private void BtnCirculo_Click(object sender, EventArgs e)
        {
            Objeto2D circulo = new Objeto2D();
            circulo.nome = "Circulo1";
            circulo.pos = PosAleatorio();
            circulo.GerarCirculo(raio_padrao);
            engine2D.AddObjeto(circulo);
        }

        private void BtnTriangulo_Click(object sender, EventArgs e)
        {
            Objeto2D triangulo = new Objeto2D();
            triangulo.nome = "Triangulo1";
            triangulo.pos = PosAleatorio();
            triangulo.GerarTriangulo(raio_padrao);
            engine2D.AddObjeto(triangulo);
        }

        private void BtnPentagono_Click(object sender, EventArgs e)
        {
            Objeto2D pentagono = new Objeto2D();
            pentagono.nome = "Pentagono1";
            pentagono.pos = PosAleatorio();
            pentagono.GerarPentagono(raio_padrao);
            engine2D.AddObjeto(pentagono);
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtNome.Focused)
            {
                obj_selecionado.nome = txtNome.Text;
            }
        }

        private void TxtAngulo_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtAngulo.Focused)
            {
                float angulo;
                if (float.TryParse(txtAngulo.Text, out angulo))
                {
                    obj_selecionado.angulo = angulo;
                    obj_selecionado.AtualizarObjeto();
                }
            }
        }

        private void TxtRaio_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtRaio.Focused)
            {
                float raio;
                if (float.TryParse(txtRaio.Text, out raio))
                {
                    obj_selecionado.raio = raio;
                    obj_selecionado.AtualizarObjeto();
                }
            }
        }

        private void TxtPosY_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtPosY.Focused)
            {
                float posY;
                if (float.TryParse(txtPosY.Text, out posY))
                {
                    obj_selecionado.pos.x = posY;
                }
            }
        }

        private void TxtPosX_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtPosX.Focused)
            {
                float posX;
                if (float.TryParse(txtPosX.Text, out posX))
                {
                    obj_selecionado.pos.x = posX;
                }
            }
        }
    }
}
