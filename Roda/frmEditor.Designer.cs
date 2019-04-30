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
            this.tmrRender = new System.Windows.Forms.Timer(this.components);
            this.btnTriangulo = new System.Windows.Forms.Button();
            this.btnPentagono = new System.Windows.Forms.Button();
            this.btnCirculo = new System.Windows.Forms.Button();
            this.btnQuadrado = new System.Windows.Forms.Button();
            this.picDesign = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAngulo = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtRaio = new System.Windows.Forms.NumericUpDown();
            this.txtPosY = new System.Windows.Forms.NumericUpDown();
            this.txtPosX = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picDesign)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAngulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosX)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrRender
            // 
            this.tmrRender.Enabled = true;
            this.tmrRender.Interval = 10;
            this.tmrRender.Tick += new System.EventHandler(this.TmrRender_Tick);
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
            // picDesign
            // 
            this.picDesign.BackColor = System.Drawing.Color.White;
            this.picDesign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDesign.Location = new System.Drawing.Point(259, 3);
            this.picDesign.Name = "picDesign";
            this.picDesign.Size = new System.Drawing.Size(538, 444);
            this.picDesign.TabIndex = 2;
            this.picDesign.TabStop = false;
            this.picDesign.Paint += new System.Windows.Forms.PaintEventHandler(this.PicDesign_Paint);
            this.picDesign.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicDesign_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PosX:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "PosY:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picDesign, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPosX);
            this.panel1.Controls.Add(this.txtPosY);
            this.panel1.Controls.Add(this.txtRaio);
            this.panel1.Controls.Add(this.txtAngulo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNome);
            this.panel1.Controls.Add(this.lblNome);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnQuadrado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCirculo);
            this.panel1.Controls.Add(this.btnTriangulo);
            this.panel1.Controls.Add(this.btnPentagono);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 444);
            this.panel1.TabIndex = 0;
            // 
            // txtAngulo
            // 
            this.txtAngulo.Location = new System.Drawing.Point(58, 170);
            this.txtAngulo.Name = "txtAngulo";
            this.txtAngulo.Size = new System.Drawing.Size(59, 20);
            this.txtAngulo.TabIndex = 16;
            this.txtAngulo.ValueChanged += new System.EventHandler(this.TxtAngulo_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Raio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ângulo:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(58, 103);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(172, 20);
            this.txtNome.TabIndex = 10;
            this.txtNome.TextChanged += new System.EventHandler(this.TxtNome_TextChanged);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(9, 106);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 9;
            this.lblNome.Text = "Nome:";
            // 
            // txtRaio
            // 
            this.txtRaio.Location = new System.Drawing.Point(171, 170);
            this.txtRaio.Name = "txtRaio";
            this.txtRaio.Size = new System.Drawing.Size(59, 20);
            this.txtRaio.TabIndex = 17;
            this.txtRaio.ValueChanged += new System.EventHandler(this.TxtRaio_ValueChanged);
            // 
            // txtPosY
            // 
            this.txtPosY.Location = new System.Drawing.Point(171, 137);
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.Size = new System.Drawing.Size(59, 20);
            this.txtPosY.TabIndex = 18;
            this.txtPosY.ValueChanged += new System.EventHandler(this.TxtPosY_ValueChanged);
            // 
            // txtPosX
            // 
            this.txtPosX.Location = new System.Drawing.Point(58, 137);
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.Size = new System.Drawing.Size(59, 20);
            this.txtPosX.TabIndex = 19;
            this.txtPosX.ValueChanged += new System.EventHandler(this.TxtPosX_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.picDesign)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAngulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRaio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrRender;
        private System.Windows.Forms.Button btnTriangulo;
        private System.Windows.Forms.Button btnPentagono;
        private System.Windows.Forms.Button btnCirculo;
        private System.Windows.Forms.Button btnQuadrado;
        private System.Windows.Forms.PictureBox picDesign;
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
    }
}

