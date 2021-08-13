﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SalaodeBeleza.Model;
using SalaodeBeleza.Dao;

namespace SalaodeBeleza
{
    public partial class FrmSaidaProduto : Form
    {

        DaoEntradaSaida daoPro = new DaoEntradaSaida();
        public FrmSaidaProduto()
        {
            InitializeComponent();
            preencherCbProduto();
        }

        public void ArredondaCantosdoForm()
        {

            GraphicsPath PastaGrafica = new GraphicsPath();
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, this.Size.Width, this.Size.Height));

            //Arredondar canto superior esquerdo        
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, 1, 10, 10));
            PastaGrafica.AddPie(1, 1, 20, 20, 180, 90);

            //Arredondar canto superior direito
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(this.Width - 12, 1, 12, 13));
            PastaGrafica.AddPie(this.Width - 24, 1, 24, 26, 270, 90);

            //Arredondar canto inferior esquerdo
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(1, this.Height - 10, 10, 10));
            PastaGrafica.AddPie(1, this.Height - 20, 20, 20, 90, 90);

            //Arredondar canto inferior direito
            PastaGrafica.AddRectangle(new System.Drawing.Rectangle(this.Width - 12, this.Height - 13, 13, 13));
            PastaGrafica.AddPie(this.Width - 24, this.Height - 26, 24, 26, 0, 90);

            PastaGrafica.SetMarkers();
            this.Region = new Region(PastaGrafica);
        }

        public void preencherCbProduto()
        {
            comboBox1.Items.Clear();
            String[] lista = daoPro.carregarCbProduto();

            for (int i = 0; i < lista.Length; i++)
            {
                comboBox1.Items.Add(lista[i]);

            }
        }
        private void FrmSaidaProduto_Load(object sender, EventArgs e)
        {
            ArredondaCantosdoForm();
            button2.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            EntradaProduto entrada = new EntradaProduto();
            DateTime dataAtual = Convert.ToDateTime(DateTime.Now);
            entrada.Data = dataAtual;
            entrada.Produto = comboBox1.SelectedItem.ToString();
            entrada.Qntd = Convert.ToInt32(this.numericUpDown1.Text);

            daoPro.saida(entrada);
            MessageBox.Show("Saida de produto realizada!");
        }
    }
}