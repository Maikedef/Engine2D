﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;
using Engine.Objetos2D.Avancados;
using Engine.Objetos2D.Primitivos;
using Engine.Sistema;

namespace Roda
{
    public partial class Form1 : Form
    {
        bool _sair = false;
        int raio_padrao = 50;
        Engine2D engine2D = new Engine2D();
        Objeto2D obj_selecionado;

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Cria a Câmera
            Camera2D camera = new Camera2D(picScreen.ClientRectangle.Width, picScreen.ClientRectangle.Height, PixelFormat.Format32bppRgb);
            engine2D.AddCamera(camera);
            #endregion

            #region Define os atributos dos controles
            txtPosX.Maximum = txtEscalaY.Maximum = txtEscalaX.Maximum = txtCamPosY.Maximum = txtCamPosX.Maximum = txtPosY.Maximum = txtAngulo.Maximum = txtRaio.Maximum = decimal.MaxValue;
            txtPosY.Minimum = txtEscalaY.Minimum = txtEscalaX.Minimum = txtCamPosY.Minimum = txtCamPosX.Minimum = txtPosY.Minimum = txtAngulo.Minimum = txtRaio.Minimum = decimal.MinValue;

            cboCamera.DisplayMember = "Nome";
            cboCamera.ValueMember = "cam";
            cboCamera.DataSource = engine2D.Cameras.Select(
                cam => new
                {
                    cam.Id,
                    cam.Nome,
                    cam
                }).ToList();

            cboObjeto2D.DisplayMember = "Nome";
            cboObjeto2D.ValueMember = "o";
            cboObjeto2D.DataSource = engine2D.objetos.Select(
                o => new
                {
                    o.Id,
                    o.Nome,
                    o
                }).ToList();

            BtnCirculo_Click(sender, e);
            AtualizarControles(null);
            #endregion

            Show();

            // Bitmap bmp = new Bitmap(camera.width, camera.heigth, g = picScreen.CreateGraphics());

            //Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            //bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format16bppArgb1555);
            // g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //Bitmap bmp = new Bitmap(camera.ResWidth, camera.ResHeigth, PixelFormat.Format16bppRgb555);

            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //    Rectangle rect = new Rectangle(0, 0, 50, 50);
            //    g.FillEllipse(Brushes.LightGreen, rect);
            //    using (Pen thick_pen = new Pen(Color.Black, 5))
            //    {
            //        g.DrawEllipse(thick_pen, rect);
            //    }

            //    Point point = new Point();

                int tick = Environment.TickCount;
                int fps = 0;

                // Loop principal de rotinas do simulador 2D
                while (!_sair)
                {
                    // Use o tempo delta em todos os cálculos que alteram o comportamento dos objetos 2d
                    // para que rode em processadores de baixo e alto desempenho sem alterar a qualidade do simulador

                    // TODO: Insira toda sua rotina aqui

                    if (moveCamera)
                    {
                        engine2D.Camera.Pos.x += -(float)((cameraDrag.X - Cursor.Position.X) * engine2D.TempoDelta * 0.000001);
                        engine2D.Camera.Pos.y += -(float)((cameraDrag.Y - Cursor.Position.Y) * engine2D.TempoDelta * 0.000001);
                    }

                    #region FPS
                    if (Environment.TickCount - tick >= 1000)
                    {
                        Text = fps.ToString();
                        tick = Environment.TickCount;
                        fps = 0;
                    }
                    else fps++;
                    #endregion

                    #region Renderização
                    //picScreen.Invalidate();
                    //engine2D.Camera.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    //engine2D.Render(engine2D.Camera);

                    picScreen.Image = engine2D.Camera.Renderizar();
                    Application.DoEvents();
                    #endregion
                }
            //}
        }

        private void AtualizarControles(Objeto2D obj)
        {
            cboObjeto2D.DataSource = engine2D.objetos
                .Select(o => new
                {
                    o.Id,
                    o.Nome,
                    o
                }).ToList();
            
            if (obj != null)
            {
                cboObjeto2D.SelectedValue = obj;
                txtPosX.Text = obj.Pos.x.ToString();
                txtPosY.Text = obj.Pos.y.ToString();
                txtAngulo.Text = obj.Angulo.ToString();
                txtRaio.Text = obj.Raio.ToString();
                txtEscalaX.Text = obj.Escala.x.ToString();
                txtEscalaY.Text = obj.Escala.y.ToString();
            }
            else
            {
                txtPosX.Text = string.Empty;
                txtPosY.Text = string.Empty;
                txtAngulo.Text = string.Empty;
                txtRaio.Text = string.Empty;
                txtEscalaX.Text = string.Empty;
                txtEscalaY.Text = string.Empty;
            }
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
                    engine2D.ObterObjeto2DPelaCamera(engine2D.Camera, new Vetor2D(e.X, e.Y));

                // Seleciona o novo objeto
                if (novo_obj_selecionado != null)
                {
                    if (obj_selecionado != null) obj_selecionado.Selecionado = false; // Deseleciona o objeto anterior
                    obj_selecionado = novo_obj_selecionado; // Define o novo objeto selecionado
                    novo_obj_selecionado.Selecionado = true; // Define como selecionado
                }
                else
                {
                    obj_selecionado.Selecionado = false;
                }

                AtualizarControles(novo_obj_selecionado);
            }

           
        }

        private Vetor2D PosAleatorio()
        {
            int x = new Random(Environment.TickCount).Next(0, picScreen.ClientRectangle.Width);
            int y = new Random(Environment.TickCount + x).Next(0, picScreen.ClientRectangle.Height);

            engine2D.Camera.Pos = new Vetor2D(x, y);
            return new Vetor2D(x, y);
        }

        private void BtnQuadrado_Click(object sender, EventArgs e)
        {
            Quadrado quadrado = new Quadrado();
            quadrado.Pos = PosAleatorio();
            quadrado.GerarGeometria(45, raio_padrao);
            engine2D.AddObjeto(obj_selecionado = quadrado);
            AtualizarControles(obj_selecionado);
        }

        private void BtnCirculo_Click(object sender, EventArgs e)
        {
            Circulo circulo = new Circulo();
            circulo.Pos = PosAleatorio();
            circulo.GerarGeometria(0, raio_padrao);
            engine2D.AddObjeto(obj_selecionado = circulo);
            AtualizarControles(obj_selecionado);
        }

        private void BtnTriangulo_Click(object sender, EventArgs e)
        {
            Triangulo triangulo = new Triangulo();
            triangulo.Pos = PosAleatorio();
            triangulo.GerarGeometria(0, raio_padrao);
            engine2D.AddObjeto(obj_selecionado = triangulo);
            AtualizarControles(obj_selecionado);
        }

        private void BtnPentagono_Click(object sender, EventArgs e)
        {
            Pentagono pentagono = new Pentagono();
            pentagono.Pos = PosAleatorio();
            pentagono.GerarGeometria(0, raio_padrao);
            engine2D.AddObjeto(obj_selecionado = pentagono);
            AtualizarControles(obj_selecionado);
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && cboObjeto2D.Focused)
            {
                obj_selecionado.Nome = cboObjeto2D.Text;
            }
        }

        private void TxtAngulo_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtAngulo.Focused)
            {
                if (float.TryParse(txtAngulo.Text, out float angulo))
                {
                    obj_selecionado.DefinirAngulo(angulo);
                }
            }
        }

        private void TxtRaio_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtRaio.Focused)
            {
                if (float.TryParse(txtRaio.Text, out float raio))
                {
                    obj_selecionado.DefinirRaio(raio);
                }
            }
        }

        private void TxtPosY_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtPosY.Focused)
            {
                if (float.TryParse(txtPosY.Text, out float posY))
                {
                    obj_selecionado.PosicionarY(posY);
                }
            }
        }

        private void TxtPosX_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtPosX.Focused)
            {
                if (float.TryParse(txtPosX.Text, out float posX))
                {
                    obj_selecionado.PosicionarX(posX);
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

        private void TxtCamPosX_ValueChanged(object sender, EventArgs e)
        {
            if (txtCamPosX.Focused)
            {
                float camPosX;
                if (float.TryParse(txtCamPosX.Text, out camPosX))
                {
                    engine2D.Camera.Pos.x = camPosX;
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
                    engine2D.Camera.Pos.y = camPosY;
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            engine2D.Camera.ResWidth = picScreen.ClientRectangle.Width;
            engine2D.Camera.ResHeigth = picScreen.ClientRectangle.Height;
        }

        private void TxtEscalaY_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtEscalaY.Focused)
            {
                if (float.TryParse(txtEscalaY.Text, out float escalaY))
                {
                    obj_selecionado.DefinirEscalaY(escalaY);
                }
            }
        }
        private void TxtEscalaX_ValueChanged(object sender, EventArgs e)
        {
            if (obj_selecionado != null && txtEscalaX.Focused)
            {
                if (float.TryParse(txtEscalaX.Text, out float escalaX))
                {
                    obj_selecionado.DefinirEscalaX(escalaX);
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sair = true;
        }

        private void TmrObjeto2D_Tick(object sender, EventArgs e)
        {
            if (_sair) return;
            
            if (obj_selecionado != null)
            {
                if (Util.Objeto2DVisivelNaCamera(engine2D.Camera, obj_selecionado))
                    txtVisivel.Text = "True";
                else
                    txtVisivel.Text = "False";
            }

            if (!txtCamPosX.Focused) txtCamPosX.Value = (decimal)engine2D.Camera.Pos.x;
            if (!txtCamPosY.Focused) txtCamPosY.Value = (decimal)engine2D.Camera.Pos.y;
            if (!txtCamAngulo.Focused) txtCamAngulo.Value = (decimal)engine2D.Camera.Angulo;
            if (!txtCamZoom.Focused) txtCamZoom.Value = (decimal)engine2D.Camera.Zoom;

            engine2D.Debug = fPSToolStripMenuItem.Checked;
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
            engine2D.Camera.Pos = ((Objeto2D)cboObjeto2D.SelectedValue).Pos;
        }

        private void CboObjeto2D_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboObjeto2D.Focused)
            {
                BtnFocarObjeto_Click(sender, e);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (pnScreen.Focused)
            {
                if (obj_selecionado != null)
                {
                    if (e.KeyCode == Keys.Delete)
                    {
                        engine2D.objetos.Remove(obj_selecionado);
                        obj_selecionado = null;
                        AtualizarControles(null);
                    }
                }
            }
        }

        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);

        // you also need ReleaseDC
        [DllImport("user32")]
        private static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);
        private void TelaCheiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //IntPtr hdc = GetWindowDC(this.Handle);
            //Graphics g = Graphics.FromHdc(hdc);

            //engine2D.Camera.g = g;
        }

        private void FPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPSToolStripMenuItem.Checked = !fPSToolStripMenuItem.Checked;
        }

        private void BtnNovaCamera_Click(object sender, EventArgs e)
        {
            #region Cria a Câmera 2D
            Camera2D camera = new Camera2D(picScreen.ClientRectangle.Width, picScreen.ClientRectangle.Height, PixelFormat.Format32bppRgb);
            camera.Pos = new Vetor2D(obj_selecionado.Pos.x, obj_selecionado.Pos.y);
            engine2D.AddCamera(camera);
            #endregion

            cboCamera.DataSource = engine2D.Cameras
                .Select(cam => new
                {
                    cam.Id,
                    cam.Nome,
                    cam
                }).ToList();

            cboCamera.SelectedValue = camera;
        }

        private void CboCamera_SelectedValueChanged(object sender, EventArgs e)
        {
            engine2D.Camera = (Camera2D)cboCamera.SelectedValue;
        }

        private void BtnQuadrilatero_Click(object sender, EventArgs e)
        {
            Quadrilatero quadrilatero = new Quadrilatero();
            quadrilatero.Pos = PosAleatorio();
            quadrilatero.GerarGeometria(0, raio_padrao, (int)(raio_padrao * 1.5F));

            engine2D.AddObjeto(obj_selecionado = quadrilatero);
            AtualizarControles(obj_selecionado);
        }

        private void PicScreen_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            picScreen.Invalidate();
        }
    }
}
