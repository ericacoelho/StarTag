namespace SalaodeBeleza.View
{
    partial class FrmEspecialidade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCadastroCliente = new System.Windows.Forms.Label();
            this.lblFechar = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.panel1.Controls.Add(this.lblCadastroCliente);
            this.panel1.Controls.Add(this.lblFechar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 38);
            this.panel1.TabIndex = 53;
            // 
            // lblCadastroCliente
            // 
            this.lblCadastroCliente.AutoSize = true;
            this.lblCadastroCliente.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadastroCliente.ForeColor = System.Drawing.Color.White;
            this.lblCadastroCliente.Location = new System.Drawing.Point(12, 9);
            this.lblCadastroCliente.Name = "lblCadastroCliente";
            this.lblCadastroCliente.Size = new System.Drawing.Size(113, 23);
            this.lblCadastroCliente.TabIndex = 17;
            this.lblCadastroCliente.Text = "Especialidade";
            // 
            // lblFechar
            // 
            this.lblFechar.AutoSize = true;
            this.lblFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblFechar.Font = new System.Drawing.Font("Berlin Sans FB Demi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblFechar.Location = new System.Drawing.Point(283, 12);
            this.lblFechar.Name = "lblFechar";
            this.lblFechar.Size = new System.Drawing.Size(17, 18);
            this.lblFechar.TabIndex = 16;
            this.lblFechar.Text = "X";
            this.lblFechar.Click += new System.EventHandler(this.lblFechar_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::SalaodeBeleza.Properties.Resources.mas__2_;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(260, 78);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.TabIndex = 94;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SalaodeBeleza.Properties.Resources.borrar;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(260, 163);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 25);
            this.pictureBox1.TabIndex = 92;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::SalaodeBeleza.Properties.Resources.lapiz_boton_de_editar__2_;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(260, 133);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.TabIndex = 93;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 100;
            this.label3.Text = "Descrição:";
            // 
            // panel12
            // 
            this.panel12.BackgroundImage = global::SalaodeBeleza.Properties.Resources.text_box_png_181;
            this.panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel12.Controls.Add(this.txtPesquisar);
            this.panel12.Location = new System.Drawing.Point(85, 74);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(169, 24);
            this.panel12.TabIndex = 101;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPesquisar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(6, 4);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(157, 16);
            this.txtPesquisar.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(85, 117);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(169, 134);
            this.listBox1.TabIndex = 102;
            // 
            // FrmEspecialidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 290);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEspecialidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEspecialidade";
            this.Load += new System.EventHandler(this.FrmEspecialidade_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCadastroCliente;
        private System.Windows.Forms.Label lblFechar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtPesquisar;
    }
}