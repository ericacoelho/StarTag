namespace SalaodeBeleza.Model
{
    partial class FrmInicial
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicial));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.indicador = new System.Windows.Forms.Panel();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnConta = new System.Windows.Forms.Button();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.btnProfissionais = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.formRelatorio1 = new SalaodeBeleza.View.FormRelatorio();
            this.frmCliente11 = new SalaodeBeleza.View.FrmCliente1();
            this.ucServico1 = new SalaodeBeleza.View.ucServico();
            this.frmProduto21 = new SalaodeBeleza.View.FrmProduto2();
            this.frmProfissional21 = new SalaodeBeleza.FrmProfissional2();
            this.frmAgenda21 = new SalaodeBeleza.View.FrmAgenda2();
            this.comanda1 = new SalaodeBeleza.View.Comanda();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnCliente);
            this.panel1.Controls.Add(this.indicador);
            this.panel1.Controls.Add(this.btnAgenda);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.btnConta);
            this.panel1.Controls.Add(this.btnEstoque);
            this.panel1.Controls.Add(this.btnProfissionais);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(66, 616);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(12, 486);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(173, 55);
            this.button3.TabIndex = 21;
            this.button3.Text = "     Conta";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Image = global::SalaodeBeleza.Properties.Resources.icons8_letras_miúdas_32;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(12, 429);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 55);
            this.button4.TabIndex = 21;
            this.button4.Text = "     Relatórios";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Image = global::SalaodeBeleza.Properties.Resources.icons8_salário_32__1_;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(12, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 55);
            this.button2.TabIndex = 20;
            this.button2.Text = "     Comanda";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.button2.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 55);
            this.button1.TabIndex = 19;
            this.button1.Text = "     Serviços";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            this.button1.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.ForeColor = System.Drawing.Color.Transparent;
            this.btnCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnCliente.Image")));
            this.btnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCliente.Location = new System.Drawing.Point(12, 77);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(173, 55);
            this.btnCliente.TabIndex = 1;
            this.btnCliente.Text = "     Cliente";
            this.btnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            this.btnCliente.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnCliente.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // indicador
            // 
            this.indicador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(127)))));
            this.indicador.Location = new System.Drawing.Point(0, 20);
            this.indicador.Name = "indicador";
            this.indicador.Size = new System.Drawing.Size(12, 55);
            this.indicador.TabIndex = 18;
            // 
            // btnAgenda
            // 
            this.btnAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnAgenda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAgenda.FlatAppearance.BorderSize = 0;
            this.btnAgenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgenda.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgenda.ForeColor = System.Drawing.Color.Transparent;
            this.btnAgenda.Image = ((System.Drawing.Image)(resources.GetObject("btnAgenda.Image")));
            this.btnAgenda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgenda.Location = new System.Drawing.Point(12, 20);
            this.btnAgenda.Name = "btnAgenda";
            this.btnAgenda.Size = new System.Drawing.Size(173, 55);
            this.btnAgenda.TabIndex = 0;
            this.btnAgenda.Text = "     Agenda";
            this.btnAgenda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgenda.UseVisualStyleBackColor = false;
            this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click);
            this.btnAgenda.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnAgenda.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.Transparent;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(12, 555);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(173, 55);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = "     Sair";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            this.btnSair.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnSair.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnConta
            // 
            this.btnConta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnConta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConta.FlatAppearance.BorderSize = 0;
            this.btnConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConta.ForeColor = System.Drawing.Color.Transparent;
            this.btnConta.Image = global::SalaodeBeleza.Properties.Resources.icons8_caixa_registradora_26;
            this.btnConta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConta.Location = new System.Drawing.Point(12, 370);
            this.btnConta.Name = "btnConta";
            this.btnConta.Size = new System.Drawing.Size(173, 55);
            this.btnConta.TabIndex = 5;
            this.btnConta.Text = "     Caixa";
            this.btnConta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConta.UseVisualStyleBackColor = false;
            this.btnConta.Click += new System.EventHandler(this.btnConta_Click);
            this.btnConta.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnConta.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnEstoque
            // 
            this.btnEstoque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnEstoque.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEstoque.FlatAppearance.BorderSize = 0;
            this.btnEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstoque.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstoque.ForeColor = System.Drawing.Color.Transparent;
            this.btnEstoque.Image = ((System.Drawing.Image)(resources.GetObject("btnEstoque.Image")));
            this.btnEstoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstoque.Location = new System.Drawing.Point(12, 191);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(173, 55);
            this.btnEstoque.TabIndex = 4;
            this.btnEstoque.Text = "     Estoque";
            this.btnEstoque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEstoque.UseVisualStyleBackColor = false;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            this.btnEstoque.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnEstoque.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // btnProfissionais
            // 
            this.btnProfissionais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.btnProfissionais.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProfissionais.FlatAppearance.BorderSize = 0;
            this.btnProfissionais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfissionais.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfissionais.ForeColor = System.Drawing.Color.Transparent;
            this.btnProfissionais.Image = ((System.Drawing.Image)(resources.GetObject("btnProfissionais.Image")));
            this.btnProfissionais.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfissionais.Location = new System.Drawing.Point(12, 134);
            this.btnProfissionais.Name = "btnProfissionais";
            this.btnProfissionais.Size = new System.Drawing.Size(173, 55);
            this.btnProfissionais.TabIndex = 2;
            this.btnProfissionais.Text = "     Profissional";
            this.btnProfissionais.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProfissionais.UseVisualStyleBackColor = false;
            this.btnProfissionais.Click += new System.EventHandler(this.btnProfissionais_Click);
            this.btnProfissionais.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
            this.btnProfissionais.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(127)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(66, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(953, 22);
            this.panel2.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(931, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(115)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(436, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(106, 50);
            this.panel3.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // formRelatorio1
            // 
            this.formRelatorio1.BackColor = System.Drawing.Color.White;
            this.formRelatorio1.Location = new System.Drawing.Point(66, 21);
            this.formRelatorio1.Name = "formRelatorio1";
            this.formRelatorio1.Size = new System.Drawing.Size(954, 596);
            this.formRelatorio1.TabIndex = 26;
            this.formRelatorio1.Load += new System.EventHandler(this.formRelatorio1_Load);
            // 
            // frmCliente11
            // 
            this.frmCliente11.BackColor = System.Drawing.Color.White;
            this.frmCliente11.Location = new System.Drawing.Point(64, 20);
            this.frmCliente11.Name = "frmCliente11";
            this.frmCliente11.Size = new System.Drawing.Size(954, 596);
            this.frmCliente11.TabIndex = 19;
            this.frmCliente11.Load += new System.EventHandler(this.frmCliente11_Load);
            // 
            // ucServico1
            // 
            this.ucServico1.BackColor = System.Drawing.Color.White;
            this.ucServico1.Location = new System.Drawing.Point(64, 20);
            this.ucServico1.Name = "ucServico1";
            this.ucServico1.Size = new System.Drawing.Size(954, 596);
            this.ucServico1.TabIndex = 23;
            this.ucServico1.Load += new System.EventHandler(this.ucServico1_Load_1);
            // 
            // frmProduto21
            // 
            this.frmProduto21.BackColor = System.Drawing.Color.White;
            this.frmProduto21.Location = new System.Drawing.Point(64, 20);
            this.frmProduto21.Name = "frmProduto21";
            this.frmProduto21.Size = new System.Drawing.Size(954, 596);
            this.frmProduto21.TabIndex = 22;
            // 
            // frmProfissional21
            // 
            this.frmProfissional21.BackColor = System.Drawing.Color.White;
            this.frmProfissional21.Location = new System.Drawing.Point(64, 20);
            this.frmProfissional21.Name = "frmProfissional21";
            this.frmProfissional21.Size = new System.Drawing.Size(954, 596);
            this.frmProfissional21.TabIndex = 21;
            // 
            // frmAgenda21
            // 
            this.frmAgenda21.BackColor = System.Drawing.Color.White;
            this.frmAgenda21.Location = new System.Drawing.Point(64, 20);
            this.frmAgenda21.Name = "frmAgenda21";
            this.frmAgenda21.Size = new System.Drawing.Size(954, 594);
            this.frmAgenda21.TabIndex = 20;
            this.frmAgenda21.Load += new System.EventHandler(this.frmAgenda21_Load);
            // 
            // comanda1
            // 
            this.comanda1.BackColor = System.Drawing.Color.White;
            this.comanda1.Location = new System.Drawing.Point(64, 20);
            this.comanda1.Name = "comanda1";
            this.comanda1.Size = new System.Drawing.Size(954, 592);
            this.comanda1.TabIndex = 25;
            // 
            // FrmInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1019, 616);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.formRelatorio1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.frmCliente11);
            this.Controls.Add(this.ucServico1);
            this.Controls.Add(this.frmProduto21);
            this.Controls.Add(this.frmProfissional21);
            this.Controls.Add(this.frmAgenda21);
            this.Controls.Add(this.comanda1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vexor";
            this.Load += new System.EventHandler(this.FrmInicial_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnConta;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.Button btnProfissionais;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel indicador;
        private View.FrmCliente1 frmCliente11;
        private View.FrmAgenda2 frmAgenda21;
        private FrmProfissional2 frmProfissional21;
        private View.FrmProduto2 frmProduto21;
        private System.Windows.Forms.Button button1;
        private View.ucServico ucServico1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private View.Comanda comanda1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private View.FormRelatorio formRelatorio1;
    }
}