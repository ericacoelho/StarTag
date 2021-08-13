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
using System.Drawing.Drawing2D;

namespace SalaodeBeleza.Model
{
    public partial class FrmServico : Form
    {
        DaoServico dao = new DaoServico();
        int operacao = 0;
        public FrmServico()
        {
            InitializeComponent(); 
            dataGridView1.DataSource =
            dao.preencherGrid();
            dataGridView1.Columns[0].Visible = false;
            desabilitarEdicao();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (operacao == 0)
            {
                DaoServico daoCliente = new DaoServico();
                Servico cliente = new Servico();
                cliente.DescServico = textBox1.Text;
                cliente.Valor = Convert.ToInt64(textBox2.Text);


                daoCliente.cadastrar(cliente);
                MessageBox.Show("Cadastrado com sucesso!");

                textBox1.Clear();
                textBox2.Clear();

                dataGridView1.DataSource =
                dao.preencherGrid();
                dataGridView1.Columns[0].Visible = false;
                desabilitarEdicao();

            }
            else
            {
                DaoServico daoCliente = new DaoServico();
                Servico pet = new Servico();
                pet.CodServico = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                pet.DescServico = textBox1.Text;
                pet.Valor = Convert.ToInt32(textBox2.Text);

                daoCliente.alterar(pet);
                MessageBox.Show("cadastrou");

                dataGridView1.DataSource =
                daoCliente.preencherGrid();
                dataGridView1.Columns[0].Visible = false;
                desabilitarEdicao();
            }
            
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

        private void FrmServico_Load(object sender, EventArgs e)
        {
            ArredondaCantosdoForm();
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
            textBox2.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value));
        }
        public void habilitarEdicao()
        {
            // btnPesquisar.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox1.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        public void desabilitarEdicao()
        {
            // btnPesquisar.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox1.Enabled = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
