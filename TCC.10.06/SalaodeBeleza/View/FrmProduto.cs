using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalaodeBeleza.Dao;
using SalaodeBeleza.Model;

namespace SalaodeBeleza.Model
{
    public partial class FrmProduto : Form
    {
        DaoEstoque daoProduto = new DaoEstoque();
        DaoFabricante dao = new DaoFabricante();
        public FrmProduto()
        {
            InitializeComponent();
            preecherCbFabricante();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            produto.DescProduto = txtProduto.Text;
            produto.Money = Convert.ToInt32(this.txtCusto.Text);

            produto.QuantEstoque = Convert.ToInt32(this.numericUpDown1.Text);
            produto.Marca = txtLinha.Text;
            produto.Linha = textBox2.Text;
            daoProduto.cadastrar(produto);
            MessageBox.Show("Cadastrado com sucesso!");

            txtProduto.Clear();
            txtCusto.Clear();
            txtLinha.Clear();
            textBox2.Clear();
            

        }

        public void preecherCbFabricante()
        {
            //String[] listaPartido = daoProduto.carregarCbFabricante();

            //for (int i = 0; i < listaPartido.Length; i++)
            //{
            //    comboBoxFornecedor.Items.Add(listaPartido[i]);

            //}
            //comboBoxFornecedor.Items.Add(daoProduto.carregarCbFabricante());
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmFabricante f = new FrmFabricante();
            f.ShowDialog();

            //label4.Visible = true;
            //panel6.Visible = true;
            //textBox1.Visible = true;
            //button3.Visible = true;
            //button4.Visible = true;

            //txtCusto.Enabled = false;
            //txtLinha.Enabled = false;
            //txtProduto.Enabled = false;
            //numericUpDown1.Enabled = false;
            //comboBoxFornecedor.Enabled = false;
            //txtProduto.BackColor = Color.White;
            //txtLinha.BackColor = Color.White;
            //txtCusto.BackColor = Color.White;
            //numericUpDown1.BackColor = Color.White;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            panel6.Visible = false;
            textBox1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

            txtCusto.Enabled = true;
            txtLinha.Enabled = true;
            txtProduto.Enabled = true;
            numericUpDown1.Enabled = true;
            //comboBoxFornecedor.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Fabricante f = new Fabricante();
            f.NomeFabricante = textBox1.Text;
            dao.cadastrar(f);
            MessageBox.Show("cadastrou");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
