namespace Roda
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnTriangulo = new System.Windows.Forms.Button();
            this.btnPentagono = new System.Windows.Forms.Button();
            this.btnCirculo = new System.Windows.Forms.Button();
            this.btnQuadrado = new System.Windows.Forms.Button();
            this.picScreen = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtEscalaX = new System.Windows.Forms.NumericUpDown();
            this.txtEscalaY = new System.Windows.Forms.NumericUpDown();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVisivel = new System.Windows.Forms.TextBox();
            this.txtAngulo = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRaio = new System.Windows.Forms.NumericUpDown();
            this.txtPosY = new System.Windows.Forms.NumericUpDown();
            this.txtPosX = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCamAngulo = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCamZoom = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCamPosX = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCamPosY = new System.Windows.Forms.NumericUpDown();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.tmrObjeto2D = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picScreen)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEscalaX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEscalaY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAngulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosX)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamAngulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamPosY)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTriangulo
            // 
            this.btnTriangulo.Location = new System.Drawing.Point(165, 3);
            this.btnTriangulo.Name = "btnTriangulo";
            this.btnTriangulo.Size = new System.Drawing.Size(75, 23);
            this.btnTriangulo.TabIndex = 5;
            this.btnTriangulo.Text = "Triângulo";
            this.btnTriangulo.UseVisualStyleBackColor = true;
            this.btnTriangulo.Click += new System.EventHandler(this.BtnTriangulo_Click);
            // 
            // btnPentagono
            // 
            this.btnPentagono.Location = new System.Drawing.Point(3, 32);
            this.btnPentagono.Name = "btnPentagono";
            this.btnPentagono.Size = new System.Drawing.Size(75, 23);
            this.btnPentagono.TabIndex = 4;
            this.btnPentagono.Text = "Pentágono";
            this.btnPentagono.UseVisualStyleBackColor = true;
            this.btnPentagono.Click += new System.EventHandler(this.BtnPentagono_Click);
            // 
            // btnCirculo
            // 
            this.btnCirculo.Location = new System.Drawing.Point(84, 3);
            this.btnCirculo.Name = "btnCirculo";
            this.btnCirculo.Size = new System.Drawing.Size(75, 23);
            this.btnCirculo.TabIndex = 3;
            this.btnCirculo.Text = "Círculo";
            this.btnCirculo.UseVisualStyleBackColor = true;
            this.btnCirculo.Click += new System.EventHandler(this.BtnCirculo_Click);
            // 
            // btnQuadrado
            // 
            this.btnQuadrado.Location = new System.Drawing.Point(3, 3);
            this.btnQuadrado.Name = "btnQuadrado";
            this.btnQuadrado.Size = new System.Drawing.Size(75, 23);
            this.btnQuadrado.TabIndex = 2;
            this.btnQuadrado.Text = "Quadrado";
            this.btnQuadrado.UseVisualStyleBackColor = true;
            this.btnQuadrado.Click += new System.EventHandler(this.BtnQuadrado_Click);
            // 
            // picScreen
            // 
            this.picScreen.BackColor = System.Drawing.Color.White;
            this.picScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picScreen.Location = new System.Drawing.Point(303, 3);
            this.picScreen.Name = "picScreen";
            this.picScreen.Size = new System.Drawing.Size(552, 520);
            this.picScreen.TabIndex = 2;
            this.picScreen.TabStop = false;
            this.picScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.PicDesign_Paint);
            this.picScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicDesign_MouseDown);
            this.picScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicDesign_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PosX:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "PosY:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picScreen, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(858, 526);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.chkDebug);
            this.panel1.Controls.Add(this.btnQuadrado);
            this.panel1.Controls.Add(this.btnCirculo);
            this.panel1.Controls.Add(this.btnTriangulo);
            this.panel1.Controls.Add(this.btnPentagono);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 520);
            this.panel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(9, 481);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(256, 100);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Animação:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Location = new System.Drawing.Point(9, 375);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 100);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Física:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Gravidade:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(81, 14);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown1.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNome);
            this.groupBox2.Controls.Add(this.txtEscalaX);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtEscalaY);
            this.groupBox2.Controls.Add(this.txtNome);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtVisivel);
            this.groupBox2.Controls.Add(this.txtAngulo);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtRaio);
            this.groupBox2.Controls.Add(this.txtPosY);
            this.groupBox2.Controls.Add(this.txtPosX);
            this.groupBox2.Location = new System.Drawing.Point(9, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 189);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Objeto 2D";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 20);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 9;
            this.lblNome.Text = "Nome:";
            // 
            // txtEscalaX
            // 
            this.txtEscalaX.Location = new System.Drawing.Point(55, 77);
            this.txtEscalaX.Name = "txtEscalaX";
            this.txtEscalaX.Size = new System.Drawing.Size(59, 20);
            this.txtEscalaX.TabIndex = 33;
            this.txtEscalaX.ValueChanged += new System.EventHandler(this.TxtEscalaX_ValueChanged);
            // 
            // txtEscalaY
            // 
            this.txtEscalaY.Location = new System.Drawing.Point(178, 77);
            this.txtEscalaY.Name = "txtEscalaY";
            this.txtEscalaY.Size = new System.Drawing.Size(59, 20);
            this.txtEscalaY.TabIndex = 32;
            this.txtEscalaY.ValueChanged += new System.EventHandler(this.TxtEscalaY_ValueChanged);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(55, 17);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(182, 20);
            this.txtNome.TabIndex = 10;
            this.txtNome.TextChanged += new System.EventHandler(this.TxtNome_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(127, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "EscalaY:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ângulo:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "EscalaX:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Raio:";
            // 
            // txtVisivel
            // 
            this.txtVisivel.Location = new System.Drawing.Point(55, 150);
            this.txtVisivel.Name = "txtVisivel";
            this.txtVisivel.ReadOnly = true;
            this.txtVisivel.Size = new System.Drawing.Size(172, 20);
            this.txtVisivel.TabIndex = 29;
            // 
            // txtAngulo
            // 
            this.txtAngulo.Location = new System.Drawing.Point(55, 105);
            this.txtAngulo.Name = "txtAngulo";
            this.txtAngulo.Size = new System.Drawing.Size(59, 20);
            this.txtAngulo.TabIndex = 16;
            this.txtAngulo.ValueChanged += new System.EventHandler(this.TxtAngulo_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Visivel";
            // 
            // txtRaio
            // 
            this.txtRaio.Location = new System.Drawing.Point(178, 103);
            this.txtRaio.Name = "txtRaio";
            this.txtRaio.Size = new System.Drawing.Size(59, 20);
            this.txtRaio.TabIndex = 17;
            this.txtRaio.ValueChanged += new System.EventHandler(this.TxtRaio_ValueChanged);
            // 
            // txtPosY
            // 
            this.txtPosY.Location = new System.Drawing.Point(178, 51);
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.Size = new System.Drawing.Size(59, 20);
            this.txtPosY.TabIndex = 18;
            this.txtPosY.ValueChanged += new System.EventHandler(this.TxtPosY_ValueChanged);
            // 
            // txtPosX
            // 
            this.txtPosX.Location = new System.Drawing.Point(55, 51);
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.Size = new System.Drawing.Size(59, 20);
            this.txtPosX.TabIndex = 19;
            this.txtPosX.ValueChanged += new System.EventHandler(this.TxtPosX_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCamAngulo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCamZoom);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCamPosX);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCamPosY);
            this.groupBox1.Location = new System.Drawing.Point(9, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 100);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Câmera:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Ângulo:";
            // 
            // txtCamAngulo
            // 
            this.txtCamAngulo.Location = new System.Drawing.Point(55, 44);
            this.txtCamAngulo.Name = "txtCamAngulo";
            this.txtCamAngulo.Size = new System.Drawing.Size(59, 20);
            this.txtCamAngulo.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(125, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Zoom:";
            // 
            // txtCamZoom
            // 
            this.txtCamZoom.Location = new System.Drawing.Point(166, 44);
            this.txtCamZoom.Name = "txtCamZoom";
            this.txtCamZoom.Size = new System.Drawing.Size(59, 20);
            this.txtCamZoom.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "PosX:";
            // 
            // txtCamPosX
            // 
            this.txtCamPosX.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtCamPosX.Location = new System.Drawing.Point(55, 18);
            this.txtCamPosX.Name = "txtCamPosX";
            this.txtCamPosX.Size = new System.Drawing.Size(59, 20);
            this.txtCamPosX.TabIndex = 26;
            this.txtCamPosX.ValueChanged += new System.EventHandler(this.TxtCamPosX_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "PosY:";
            // 
            // txtCamPosY
            // 
            this.txtCamPosY.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtCamPosY.Location = new System.Drawing.Point(166, 18);
            this.txtCamPosY.Name = "txtCamPosY";
            this.txtCamPosY.Size = new System.Drawing.Size(59, 20);
            this.txtCamPosY.TabIndex = 25;
            this.txtCamPosY.ValueChanged += new System.EventHandler(this.TxtCamPosY_ValueChanged);
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.Location = new System.Drawing.Point(99, 38);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(58, 17);
            this.chkDebug.TabIndex = 22;
            this.chkDebug.Text = "Debug";
            this.chkDebug.UseVisualStyleBackColor = true;
            this.chkDebug.CheckedChanged += new System.EventHandler(this.ChkDebug_CheckedChanged);
            // 
            // tmrObjeto2D
            // 
            this.tmrObjeto2D.Enabled = true;
            this.tmrObjeto2D.Interval = 1;
            this.tmrObjeto2D.Tick += new System.EventHandler(this.TmrObjeto2D_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 526);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picScreen)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEscalaX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEscalaY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAngulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamAngulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamPosY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTriangulo;
        private System.Windows.Forms.Button btnPentagono;
        private System.Windows.Forms.Button btnCirculo;
        private System.Windows.Forms.Button btnQuadrado;
        private System.Windows.Forms.PictureBox picScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtAngulo;
        private System.Windows.Forms.NumericUpDown txtRaio;
        private System.Windows.Forms.NumericUpDown txtPosY;
        private System.Windows.Forms.NumericUpDown txtPosX;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown txtCamPosX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtCamPosY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown txtCamAngulo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtCamZoom;
        private System.Windows.Forms.TextBox txtVisivel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown txtEscalaX;
        private System.Windows.Forms.NumericUpDown txtEscalaY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Timer tmrObjeto2D;
    }
}

