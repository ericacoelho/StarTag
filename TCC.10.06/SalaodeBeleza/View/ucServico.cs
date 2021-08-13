using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalaodeBeleza.Dao;
using SalaodeBeleza.Model;

namespace SalaodeBeleza.View
{
    public partial class ucServico : UserControl
    {
        DaoServico daoServico = new DaoServico();
        Servico servico = new Servico();
        int operacao = 0;
        public string valor;
        public ucServico()
        {
            InitializeComponent();
            atualizardatagridview();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;

            if (operacao == 0)
            {
                DaoServico daoCliente = new DaoServico();
                Servico cliente = new Servico();
                cliente.DescServico = textBox3.Text;
                cliente.Valor = Convert.ToDecimal(textBox2.Text);


                daoCliente.cadastrar(cliente);
                MessageBox.Show("Cadastrado com sucesso!");

                textBox3.Clear();
                textBox2.Clear();

                atualizardatagridview();

            }
            else
            {
                DaoServico daoCliente = new DaoServico();
                Servico pet = new Servico();
                pet.CodServico = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                pet.DescServico = textBox3.Text;
                pet.Valor = Convert.ToInt32(textBox2.Text);

                daoCliente.alterar(pet);
                MessageBox.Show("Editado com sucesso!");

                atualizardatagridview();
                operacao = 0;
            }
        }

        public void atualizardatagridview()
        {
            dataGridView1.DataSource =
            daoServico.preencherGrid();
            dataGridView1.Columns[0].Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            operacao = 1;
            textBox3.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox2.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este candidato?", "Exclusão",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show(daoServico.excluirCandidato(cod));

                atualizardatagridview();
            }
        }

        private void ucServico_Load(object sender, EventArgs e)
        {
            atualizardatagridview();

            //dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; //aqui tira as barras entre as palavras do cabeçalhoe tbm a borda
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Aqui muda a cor da fonte das palavras do cabeçalho
        
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
            daoServico.preencherGrid(txtPesquisar.Text);
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
