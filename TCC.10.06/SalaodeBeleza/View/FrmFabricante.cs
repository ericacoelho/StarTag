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
    public partial class FrmFabricante : Form
    {
        int operacao = 0;
        DaoFabricante dao = new DaoFabricante();
        Fabricante fab = new Fabricante();

        public FrmFabricante()
        {
            InitializeComponent();
            ArredondaCantosdoForm();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
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

        private void lblFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmFabricante_Load(object sender, EventArgs e)
        {
            atalizardatagridview();

            //dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; //aqui tira as barras entre as palavras do cabeçalhoe tbm a borda
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Aqui muda a cor da fonte das palavras do cabeçalho
        
        }

        public void atalizardatagridview()
        {
            dataGridView1.DataSource = dao.preencherGrid();
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            if (operacao == 0)
            {
                Fabricante especie = new Fabricante();
                especie.NomeFabricante = txtProduto.Text;
                especie.CnpjFabricante = textBox1.Text;

                dao.cadastrar(especie);
                MessageBox.Show("Cadastrado com sucesso!");

                atalizardatagridview();
                                
            }
            else
            {
                Fabricante especie = new Fabricante();
                especie.CodFabricante = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                especie.NomeFabricante = txtProduto.Text;
                especie.CnpjFabricante = textBox1.Text;

                dao.alterar(especie);

                atalizardatagridview();
                operacao = 0;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            operacao = 1;
            dataGridView1.Enabled = false;
            txtProduto.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
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

            }
        }

    }
}
