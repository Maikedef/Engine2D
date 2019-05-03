﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace Roda
{
    public partial class Form1 : Form
    {
        bool _sair = false;
        int raio_padrao = 50;
        Engine2D engine2D = new Engine2D();
        Objeto2D obj_selecionado = new Objeto2D();
        Objeto2D obj_mousehover = new Objeto2D();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPosX.Maximum = txtEscalaY.Maximum = txtEscalaX.Maximum = txtCamPosY.Maximum = txtCamPosX.Maximum = txtPosY.Maximum = txtAngulo.Maximum = txtRaio.Maximum = decimal.MaxValue;
            txtPosY.Minimum = txtEscalaY.Minimum = txtEscalaX.Minimum = txtCamPosY.Minimum = txtCamPosX.Minimum = txtPosY.Minimum = txtAngulo.Minimum = txtRaio.Minimum = decimal.MinValue;
            chkDebug.Checked = true;

            engine2D.camera = new Camera(picScreen.ClientRectangle.Width, picScreen.ClientRectangle.Height);
            engine2D.camera.pos = new Vetor2D(obj_selecionado.pos.x, obj_selecionado.pos.y);

            cboObjeto2D.DataSource = engine2D.objetos2d.Select(
                obj => new
                {
                    id = obj.id,
                    nome = obj.nome,
                    obj = obj
                }).ToList();

            cboObjeto2D.DisplayMember = "nome";
            cboObjeto2D.ValueMember = "obj";

            BtnCirculo_Click(sender, e);
            AtualizarControles(null);

            Show();

            Camera camera = engine2D.camera;
            Graphics g;
            Bitmap bmp = new Bitmap(camera.width, camera.heigth, g = picScreen.CreateGraphics());

            //Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            //bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format16bppArgb1555);
            // g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Loop principal de rotinas do simulador 2D
            while (!_sair)
            {
                // Use o tempo delta em todos os cálculos que alteram o comportamento dos objetos 2d
                // para que rode em processadores de baixo e alto desempenho sem alterar a qualidade do simulador

                // TODO: Insira toda sua rotina aqui

                if (moveCamera)
                {
                    engine2D.camera.pos.x += -(float)((cameraDrag.X - Cursor.Position.X) * engine2D.TempoDelta * 0.01);
                    engine2D.camera.pos.y += -(float)((cameraDrag.Y - Cursor.Position.Y) * engine2D.TempoDelta * 0.01);
                }

                #region Renderização
                picScreen.Invalidate();
                engine2D.Render(engine2D.camera, g);
                Application.DoEvents();
                #endregion
            }
        }

        private void AtualizarControles(Objeto2D objeto2d)
        {
            cboObjeto2D.DataSource = engine2D.objetos2d.Select(
                obj => new
                {
                    id = obj.id,
                    nome = obj.nome,
                    obj = obj
                }).ToList();
            
            if (objeto2d != null)
            {
                cboObjeto2D.SelectedValue = objeto2d;
                txtPosX.Text = objeto2d.pos.x.ToString();
                txtPosY.Text = objeto2d.pos.y.ToString();
                txtAngulo.Text = objeto2d.angulo.ToString();
                txtRaio.Text = objeto2d.raio.ToString();
            }
            else
            {
                txtPosX.Text = string.Empty;
                txtPosY.Text = string.Empty;
                txtAngulo.Text = string.Empty;
                txtRaio.Text = string.Empty;
            }
        }

        private void PicDesign_Paint(object sender, PaintEventArgs e)
        {
            engine2D.Render(engine2D.camera, e.Graphics);
        }

        Point cameraDrag;
        private void PicDesign_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                cameraDrag = Cursor.Position;
            }
            else if (e.Button == MouseButtons.Left)
            {
                Objeto2D novo_obj_selecionado =
                    engine2D.ObterObjeto2DPelaCamera(engine2D.camera, new Vetor2D(e.X, e.Y));

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

                AtualizarControles(novo_obj_selecionado);
            }
        }

        private Vetor2D PosAleatorio()
        {
            int x = new Random(Environment.TickCount).Next(0, picScreen.ClientRectangle.Width);
            int y = new Random(Environment.TickCount + x).Next(0, picScreen.ClientRectangle.Height);

            engine2D.camera.pos = new Vetor2D(x, y);
            return new Vetor2D(x, y);
        }

        private void BtnQuadrado_Click(object sender, EventArgs e)
        {
            Objeto2D quadrado = new Objeto2D();
            quadrado.nome = "Quadrado";
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
            circulo.nome = "Circulo";
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
            triangulo.nome = "Triangulo";
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
            pentagono.nome = "Pentagono";
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
            if (obj_selecionado != null && cboObjeto2D.Focused)
            {
                obj_selecionado.nome = cboObjeto2D.Text;
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

        bool moveCamera = false;

        private void PicDesign_MouseMove(object sender, MouseEventArgs e)
        {
            moveCamera = false;
            if (e.Button == MouseButtons.Middle)
            {
                moveCamera = true;
            }
            else if (e.Button == MouseButtons.None)
            {
                // Seleciona ao passar com o mouse sobre o objeto

                //Objeto2D obj = 
                //    engine2D.ObterObjeto2DPelaCamera(engine2D.camera, new Vetor2D(e.X, e.Y));

                //if (obj != null && obj_mousehover != obj)
                //{
                    
                //}
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
            engine2D.camera.width = picScreen.ClientRectangle.Width;
            engine2D.camera.heigth = picScreen.ClientRectangle.Height;
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

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sair = true;
        }

        private void TmrObjeto2D_Tick(object sender, EventArgs e)
        {
            if (obj_selecionado != null)
            {
                if (engine2D.Objeto2DVisivelNaCamera(engine2D.camera, obj_selecionado))
                    txtVisivel.Text = "True";
                else
                    txtVisivel.Text = "False";
            }

            if (!txtCamPosX.Focused) txtCamPosX.Value = (decimal)engine2D.camera.pos.x;
            if (!txtCamPosY.Focused) txtCamPosY.Value = (decimal)engine2D.camera.pos.y;
            if (!txtCamAngulo.Focused) txtCamAngulo.Value = (decimal)engine2D.camera.angulo;
            if (!txtCamZoom.Focused) txtCamZoom.Value = (decimal)engine2D.camera.zoom;
        }

        private void BtnVarios_Click(object sender, EventArgs e)
        {
            int quant = 50 / 4;

            for (int i = 0; i < quant; i++)
            {
                BtnCirculo_Click(sender, e);
                Thread.Sleep(20);
                BtnTriangulo_Click(sender, e);
                Thread.Sleep(20);
                BtnQuadrado_Click(sender, e);
                Thread.Sleep(20);
                BtnPentagono_Click(sender, e);
                Thread.Sleep(20);
            }
        }

        private void BtnFocarObjeto_Click(object sender, EventArgs e)
        {
            if (cboObjeto2D.SelectedValue == null) return;
            engine2D.camera.pos = ((Objeto2D)cboObjeto2D.SelectedValue).pos;
        }

        private void CboObjeto2D_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboObjeto2D.Focused)
            {
                BtnFocarObjeto_Click(sender, e);
            }
        }
    }
}
