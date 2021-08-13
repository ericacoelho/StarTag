using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalaodeBeleza.Model;
using SalaodeBeleza.Dao;

namespace SalaodeBeleza.View
{
    public partial class FrmProduto2 : UserControl
    {
        DaoEstoque dao = new DaoEstoque();
        Produto produto = new Produto();
        int operacao = 0;


        public FrmProduto2()
        {
            InitializeComponent();
            atualizardatagridview();
            preecherCbFabricante();
        }
        //Double valor;
        private void btnNovoAgendam_Click(object sender, EventArgs e)
        {
            FrmEntradaProduto form = new FrmEntradaProduto();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSaidaProduto form = new FrmSaidaProduto();
            form.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmFabricante f = new FrmFabricante();
            f.ShowDialog();

        }

        private void FrmProduto2_Load(object sender, EventArgs e)
        {
            //txtCusto.Text = Convert.ToDouble(txtCusto.Text).ToString("C");
            preecherCbFabricante();
            atualizardatagridview();

            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; //aqui tira as barras entre as palavras do cabeçalhoe tbm a borda
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Aqui muda a cor da fonte das palavras do cabeçalho
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este candidato?", "Exclusão",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show(dao.excluirCandidato(cod));
                atualizardatagridview();

            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
            dao.preencherGrid(txtPesquisar.Text);
            dataGridView1.Columns[0].Visible = false;
        }

        public void atualizardatagridview()
        {
            dataGridView1.DataSource = dao.preencherGrid();
            dataGridView1.Columns[0].Visible = false;   
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            operacao = 1;
            txtProduto.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            txtCusto.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value));
            numericUpDown1.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value));
            comboBox1.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value));
            
        }

        public void preecherCbFabricante()
        {
            comboBox1.Items.Clear();
            String[] listaPartido = dao.carregarCbFabricante();

            for (int i = 0; i < listaPartido.Length; i++)
            {
                comboBox1.Items.Add(listaPartido[i]);

            }
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            

            
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
                dataGridView1.Enabled = true;
                if (operacao == 0)
                {
                    Produto produto = new Produto();

                    produto.DescProduto = txtProduto.Text;
                    produto.Money = Convert.ToInt32(this.txtCusto.Text);
                    produto.QuantEstoque = Convert.ToInt32(this.numericUpDown1.Text);
                    produto.CodFabricante = comboBox1.SelectedItem.ToString();

                    dao.cadastrar(produto);
                    MessageBox.Show("Cadastrado com sucesso!");

                    atualizardatagridview();

                    txtProduto.Clear();
                    txtCusto.Clear();
                }
                else
                {
                    Produto produto = new Produto();

                    produto.CodProduto = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    produto.DescProduto = txtProduto.Text;
                    produto.Money = Convert.ToInt32(this.txtCusto.Text);
                    produto.QuantEstoque = Convert.ToInt32(this.numericUpDown1.Text);
                    produto.CodFabricante = comboBox1.SelectedItem.ToString();

                    dao.alterar(produto);
                    MessageBox.Show("Cadastrado com sucesso!");

                    atualizardatagridview();
                    operacao = 0;

                    txtProduto.Clear();
                    txtCusto.Clear();

                }
        }

        private void txtCusto_TextChanged(object sender, EventArgs e)
        {
          //  txtCusto.Text = Double.Parse(txtCusto.Text).ToString("C");
            //try
            //{
            //    valor = Double.Parse(txtCusto.Text);
            //    txtCusto.Text = valor.ToString("C");
            //}
            //catch
            //{ 
            //}
        }

        private void txtCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == ',') && !(e.KeyChar == Convert.ToChar(8)))
          //  {
           //     e.Handled = true;
           // }
        }
    }
}

