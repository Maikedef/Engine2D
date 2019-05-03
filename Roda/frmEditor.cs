using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace Roda
{
    public partial class Form1 : Form
    {
        int raio_padrao = 50;
        Engine2D engine2D = new Engine2D();
        Objeto2D obj_selecionado = new Objeto2D();
        Objeto2D obj_mousehover = new Objeto2D();

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPosX.Maximum = txtEscalaY.Maximum = txtEscalaX.Maximum = txtCamPosY.Maximum = txtCamPosX.Maximum = txtPosY.Maximum = txtAngulo.Maximum = txtRaio.Maximum = decimal.MaxValue;
            txtPosY.Minimum = txtEscalaY.Minimum = txtEscalaX.Minimum = txtCamPosY.Minimum = txtCamPosX.Minimum = txtPosY.Minimum = txtAngulo.Minimum = txtRaio.Minimum = decimal.MinValue;

            BtnCirculo_Click(sender, e);
            chkDebug.Checked = true;

            engine2D.camera = new Camera(0, 0, picDesign.ClientRectangle.Width, picDesign.ClientRectangle.Height);
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

            if (obj_selecionado != null)
            {
                if (engine2D.Objeto2DVisivelNaCamera(engine2D.camera, obj_selecionado))
                    txtVisivel.Text = "True";
                else
                    txtVisivel.Text = "False";
            }
        }

        private void PicDesign_Paint(object sender, PaintEventArgs e)
        {
            engine2D.Render(engine2D.camera, e.Graphics);
        }

        private void PicDesign_MouseDown(object sender, MouseEventArgs e)
        {
            Vetor2D ponto_tela = new Vetor2D();
            ponto_tela.x = e.X;
            ponto_tela.y = e.Y;

            Objeto2D novo_obj_selecionado = engine2D.ObterObjeto2DPelaCamera(engine2D.camera, ponto_tela);
            AtualizarControles(novo_obj_selecionado);

            // Seleciona o novo objeto
            if (novo_obj_selecionado != null)
            {
                if (obj_selecionado != null) obj_selecionado.selecionado = false; // Deseleciona o objeto anterior
                obj_selecionado = novo_obj_selecionado; // Define o novo objeto selecionado
                novo_obj_selecionado.selecionado = true; // Define como selecionado
            }
            else
            {
                obj_selecionado.selecionado = false;
            }
        }

        private Vetor2D PosAleatorio()
        {
            int x = new Random(Environment.TickCount).Next(0, picDesign.ClientRectangle.Width);
            int y = new Random(Environment.TickCount + x).Next(0, picDesign.ClientRectangle.Height);

            engine2D.camera.pos = new Vetor2D(x, y);
            return new Vetor2D(x, y);
        }

        private void BtnQuadrado_Click(object sender, EventArgs e)
        {
            Objeto2D quadrado = new Objeto2D();
            quadrado.nome = "Quadrado1";
            quadrado.pos = PosAleatorio();
            quadrado.GerarQuadrado(raio_padrao);

            EstiloObjeto2D estilo = new EstiloObjeto2D("quadrado");
            estilo.cor_borda = Color.DarkSlateBlue;
            quadrado.colecaoEstilos.Add(estilo);
            quadrado.DefinirEstilo(estilo);

            engine2D.AddObjeto(obj_selecionado = quadrado);
            AtualizarControles(obj_selecionado);
        }

        private void BtnCirculo_Click(object sender, EventArgs e)
        {
            Objeto2D circulo = new Objeto2D();
            circulo.nome = "Circulo1";
            circulo.pos = PosAleatorio();
            circulo.GerarCirculo(raio_padrao);

            EstiloObjeto2D estilo = new EstiloObjeto2D("circulo");
            estilo.cor_borda = Color.DarkRed;
            estilo.cor_interior = Color.Transparent;

            circulo.colecaoEstilos.Add(estilo);
            circulo.DefinirEstilo(estilo);

            engine2D.AddObjeto(obj_selecionado = circulo);
            AtualizarControles(obj_selecionado);
        }

        private void BtnTriangulo_Click(object sender, EventArgs e)
        {
            Objeto2D triangulo = new Objeto2D();
            triangulo.nome = "Triangulo1";
            triangulo.pos = PosAleatorio();
            triangulo.GerarTriangulo(raio_padrao);

            EstiloObjeto2D estilo = new EstiloObjeto2D("triangulo");
            estilo.cor_borda = Color.Red;
            estilo.cor_interior = Color.Transparent;
            triangulo.colecaoEstilos.Add(estilo);
            triangulo.DefinirEstilo(estilo);

            engine2D.AddObjeto(obj_selecionado = triangulo);
            AtualizarControles(obj_selecionado);
        }

        private void BtnPentagono_Click(object sender, EventArgs e)
        {
            Objeto2D pentagono = new Objeto2D();
            pentagono.nome = "Pentagono1";
            pentagono.pos = PosAleatorio();
            pentagono.GerarPentagono(raio_padrao);

            EstiloObjeto2D estilo = new EstiloObjeto2D("pentagono");
            estilo.cor_borda = Color.DarkMagenta;
            pentagono.colecaoEstilos.Add(estilo);
            pentagono.DefinirEstilo(estilo);

            engine2D.AddObjeto(obj_selecionado = pentagono);
            AtualizarControles(obj_selecionado);
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
                    obj_selecionado.pos.y = posY;
                    obj_selecionado.AtualizarObjeto();
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
                    obj_selecionado.AtualizarObjeto();
                }
            }
        }

        private void PicDesign_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
            {
                Objeto2D obj = 
                    engine2D.ObterObjeto2DPelaCamera(engine2D.camera, new Vetor2D(e.X, e.Y));

                if (obj != null && obj_mousehover != obj)
                {
                    obj_mousehover = 
                    obj_mousehover = obj;
                }
            }
        }

        private void ChkDebug_CheckedChanged(object sender, EventArgs e)
        {
            engine2D.Debug = chkDebug.Checked;
        }

        private void TxtCamPosX_ValueChanged(object sender, EventArgs e)
        {
            if (txtCamPosX.Focused)
            {
                float camPosX;
                if (float.TryParse(txtCamPosX.Text, out camPosX))
                {
                    engine2D.camera.pos.x = camPosX;
                }
            }
        }

        private void TxtCamPosY_ValueChanged(object sender, EventArgs e)
        {
            if (txtCamPosY.Focused)
            {
                float camPosY;
                if (float.TryParse(txtCamPosY.Text, out camPosY))
                {
                    engine2D.camera.pos.y = camPosY;
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            engine2D.camera.width = picDesign.ClientRectangle.Width;
            engine2D.camera.heigth = picDesign.ClientRectangle.Height;
        }

        private void TxtEscalaY_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtEscalaY.Focused)
            {
                float escalaY;
                if (float.TryParse(txtEscalaY.Text, out escalaY))
                {
                    obj_selecionado.escala.y = escalaY;
                    obj_selecionado.AtualizarObjeto();
                }
            }
        }

        private void TxtEscalaX_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtEscalaX.Focused)
            {
                float escalaX;
                if (float.TryParse(txtEscalaX.Text, out escalaX))
                {
                    obj_selecionado.escala.x = escalaX;
                    obj_selecionado.AtualizarObjeto();
                }
            }
        }
    }
}
