using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalaodeBeleza.Model;
using SalaodeBeleza.Dao;

namespace SalaodeBeleza.View
{
    public partial class FrmMarca : Form
    {
        int operacao = 0;
        Fabricante fab = new Fabricante();
        DaoFabricante dao = new DaoFabricante();
        public FrmMarca()
        {
            InitializeComponent();
            dataGridView1.DataSource =
            dao.preencherGrid();
            dataGridView1.Columns[0].Visible = false;
            desabilitarEdicao();
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (operacao == 0)
            {
                fab.NomeFabricante = textBox1.Text;

                dao.cadastrar(fab);
                MessageBox.Show("cadastrou");

                dataGridView1.DataSource =
                dao.preencherGrid();
                dataGridView1.Columns[0].Visible = false;
                desabilitarEdicao();
            }
            else
            {
                fab.CodFabricante = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                fab.NomeFabricante = textBox1.Text;

                dao.alterar(fab);

                dataGridView1.DataSource =
                dao.preencherGrid();
                dataGridView1.Columns[0].Visible = false;
                desabilitarEdicao();
           }
        }
        public void habilitarEdicao()
        {
            
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            textBox1.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        public void desabilitarEdicao()
        {
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            textBox1.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            textBox1.Clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            operacao = 0;
            habilitarEdicao();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            operacao = 1;
            habilitarEdicao();

            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este candidato?", "Exclusão",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show(dao.excluirCandidato(cod));

                dataGridView1.DataSource = dao.preencherGrid();
                dataGridView1.Columns[0].Visible = false;

                desabilitarEdicao();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            desabilitarEdicao();
        }
    }
}
