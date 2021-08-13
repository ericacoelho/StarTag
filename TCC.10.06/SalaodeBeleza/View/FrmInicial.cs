using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalaodeBeleza.Dao;
using System.Windows.Media;
using SalaodeBeleza.View;

namespace SalaodeBeleza.Model
{
    public partial class FrmInicial : Form
    {
        DaoCliente daoCliente = new DaoCliente();
        DaoProfissional daoProfissional = new DaoProfissional();
        DaoServico daoServico = new DaoServico();
        DaoEstoque daoEstoque = new DaoEstoque();
       
        public FrmInicial()
        {
            InitializeComponent();

            frmAgenda21.BringToFront();
            panel3.BringToFront();
            label1.BringToFront();
            //pictureBox1.BringToFront();
            indicador.Height = btnAgenda.Height;
            indicador.Top = btnAgenda.Top;
        }
        //    panel3.Visible = false;
        //    panel4.Visible = false;
        //    panel9.Visible = true;
        //    panel11.Visible = false;

        //    gridCliente.DataSource =
        //    daoCliente.preencherGrid();
        //    gridCliente.Columns[0].Visible = false;

        //    dataGridView1.DataSource =
        //    daoProfissional.preencherGrid();
        //    dataGridView1.Columns[0].Visible = false;


        //    dataGridView4.DataSource =
        //    daoEstoque.preencherGrid();
        //    dataGridView4.Columns[0].Visible = false;
        //}

        //private void btnCliente_Click(object sender, EventArgs e)
        //{
        //    //FrmCliente cliente = new FrmCliente();
        //    //cliente.ShowDialog();
        //    panel4.Visible = true;
        //    panel3.Visible = false;
        //    panel11.Visible = false;
        //    panel9.Visible = false;
        //    gridCliente.DataSource =
        //    daoCliente.preencherGrid();
        //    gridCliente.Columns[0].Visible = false;
        //}

        private void btnSair_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }


        private void btnConta_Click(object sender, EventArgs e)
        {
            indicador.Height = button2.Height;
            indicador.Top = button2.Top;
            Caixa2 conta = new Caixa2();
            conta.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            FrmCliente f = new FrmCliente();
            f.Show();
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            FrmCliente f = new FrmCliente();
            f.Show();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            FrmCliente f = new FrmCliente();
            f.Show();
        }

        //private void gridCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int Linha = gridCliente.CurrentRow.Index;
        //    int cod = int.Parse(gridCliente.Rows[Linha].Cells[1].ToString());

        //    //codCliente = Convert.ToString(gridCliente.CurrentRow.Cells[1].Value);
        //}              
        //private void btnProfissionais_Click(object sender, EventArgs e)
        //{
            
        //}

        //private void txtPesquisa_TextChanged(object sender, EventArgs e)
        //{
        //    DaoCliente dao = new DaoCliente();
        //    gridCliente.DataSource =
        //    dao.preencherGrid(txtPesquisa.Text);
        //    gridCliente.Columns[0].Visible = false;
        //}

        //private void label3_Click(object sender, EventArgs e)
        //{
        //    FrmProfissional f = new FrmProfissional();
        //    f.ShowDialog();
        //}

        //private void pictureBox7_Click(object sender, EventArgs e)
        //{
        //    FrmProfissional f = new FrmProfissional();
        //    f.ShowDialog();
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    FrmProfissional f = new FrmProfissional();
        //    f.ShowDialog();
        //}

        //private void btnProfissionais_Click_1(object sender, EventArgs e)
        //{
        //    panel3.Visible = true;
        //    panel4.Visible = false;
        //    panel11.Visible = false;
        //    panel9.Visible = false;
        //    dataGridView1.DataSource =
        //    daoProfissional.preencherGrid();
        //    dataGridView1.Columns[0].Visible = false;
        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    dataGridView1.DataSource =
        //    daoProfissional.preencherGrid(textBox1.Text);
        //    dataGridView1.Columns[0].Visible = false;
        //}

        //private void btnServicos_Click(object sender, EventArgs e)
        //{
        //    panel3.Visible = false;
        //    panel4.Visible = false;
        //    panel11.Visible = false;
        //}

        //private void label7_Click(object sender, EventArgs e)
        //{
        //    FrmServico f = new FrmServico();
        //    f.ShowDialog();
        //}

        //private void pictureBox9_Click(object sender, EventArgs e)
        //{
        //    FrmProfissional f = new FrmProfissional();
        //    f.ShowDialog();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    FrmProfissional f = new FrmProfissional();
        //    f.ShowDialog();
        //}

        //private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        //private void textBox3_TextChanged(object sender, EventArgs e)
        //{
        //}

        //private void btnEstoque_Click(object sender, EventArgs e)
        //{
        //    panel3.Visible = false;
        //    panel4.Visible = false;
        //    panel11.Visible = true;
        //    panel9.Visible = false;
        //    dataGridView4.DataSource =
        //    daoEstoque.preencherGrid();
        //    dataGridView4.Columns[0].Visible = false;
        //}

        //private void textBox4_TextChanged(object sender, EventArgs e)
        //{
        //    dataGridView4.DataSource =
        //    daoEstoque.preencherGrid(textBox4.Text);
        //    dataGridView4.Columns[0].Visible = false;
        //}

        private void label10_Click(object sender, EventArgs e)
        {
            FrmProduto f = new FrmProduto();
            f.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            FrmProduto f = new FrmProduto();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmProduto f = new FrmProduto();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            Dispose();
            f.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // indicador.Height = btHome.Height;
           // indicador.Top = btHome.Top;
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            
            frmAgenda21.BringToFront();
            panel3.BringToFront();
            label1.BringToFront();
           // pictureBox1.BringToFront();
            indicador.Height = btnAgenda.Height;
            indicador.Top = btnAgenda.Top;
            atualizarUc();
            
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            indicador.Height = btnCliente.Height;
            indicador.Top = btnCliente.Top;
            atualizarUc();
            frmCliente11.BringToFront();
            panel3.BringToFront();
            label1.BringToFront();
           // pictureBox1.BringToFront();
        }

        private void btnProfissionais_Click(object sender, EventArgs e)
        {
            indicador.Height = btnProfissionais.Height;
            indicador.Top = btnProfissionais.Top;
            frmProfissional21.BringToFront();
            panel3.BringToFront();
            label1.BringToFront();
            //pictureBox1.BringToFront();
            atualizarUc();
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            frmProduto21.BringToFront();
            panel3.BringToFront();
            label1.BringToFront();
           // pictureBox1.BringToFront();
            indicador.Height = btnEstoque.Height;
            indicador.Top = btnEstoque.Top;
            atualizarUc();
        }

        

        //private void btnAgenda_Click(object sender, EventArgs e)
        //{
        //    panel3.Visible = false;
        //    panel4.Visible = false;
        //    panel9.Visible = true;
        //    panel11.Visible = false;
        //}

        //private void pbExcluir_Click(object sender, EventArgs e)
        //{
        //    DialogResult resultado = MessageBox.Show("Deseja realmente excluir este candidato?", "Exclusão",
        //                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (resultado == DialogResult.Yes)
        //    {
        //        MessageBox.Show(daoEstoque.excluir(codCandidato));
        //        dataGridView4.DataSource = daoEstoque.preencherGrid();

        //    }
            

        //}


        //private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    codCandidato = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);

        //}

        //private void pictureBox16_Click(object sender, EventArgs e)
        //{
        //    DialogResult resultado = MessageBox.Show("Deseja realmente excluir este candidato?", "Exclusão",
        //                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //    //codCliente = Convert.ToString(gridCliente.CurrentRow.Cells[1].Value);
        //    if (resultado == DialogResult.Yes)
        //    {
        //        daoCliente.excluir(codCliente);
                
        //        gridCliente.DataSource =
        //        daoCliente.preencherGrid();
        //        gridCliente.Columns[0].Visible = false;

        //    }
        //}

        //private void pictureBox12_Click(object sender, EventArgs e)
        //{
        //    DialogResult resultado = MessageBox.Show("Deseja realmente excluir este candidato?", "Exclusão",
        //                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    if (resultado == DialogResult.Yes)
        //    {
        //        MessageBox.Show(daoProfissional.excluir(codProf));
        //        dataGridView1.DataSource = daoProfissional.preencherGrid();

        //    }
        //}


        private void btn_MouseEnter(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.None;
            panel1.Dock = DockStyle.Left;
            panel1.BringToFront();
            panel1.Width = 173;
            
        }


        private void btn_MouseLeave(object sender, EventArgs e)
        {
            panel2.Dock = DockStyle.None;
            panel1.Dock = DockStyle.Left;
            panel1.BringToFront();
            panel1.Width = 67;
        }

        private void FrmInicial_Load(object sender, EventArgs e)
        {

        }

        private void frmAgenda21_Load(object sender, EventArgs e)
        {

        }

        private void frmProduto21_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            indicador.Height = button1.Height;
            indicador.Top = button1.Top;
            ucServico1.BringToFront();
            panel3.BringToFront();
            label1.BringToFront();
            //pictureBox1.BringToFront();
        }

        private void ucServico1_Load(object sender, EventArgs e)
        {
            
        }

        private void atualizarUc() 
        {
            frmProfissional21.preencherCbEspecialidade();
            frmCliente11.atualizarDataGridView();
            frmAgenda21.atualizarDataGridView();
            frmProduto21.atualizardatagridview();
            frmProduto21.preecherCbFabricante();
            frmProfissional21.atualizardatagridview();
            frmAgenda21.preecherCbProf();
            formRelatorio1.atualizarDataGridView1();
            formRelatorio1.atualizarDataGridView2();
            formRelatorio1.atualizarDataGridView3();
            formRelatorio1.atualizarDataGridView4();

        }

        private void ucServico1_Load_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = (DateTime.Now.ToString("HH:mm"));
        }

        private void frmCliente11_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            indicador.Height = button2.Height;
            indicador.Top = button2.Top;
            comanda1.BringToFront();
            panel3.BringToFront();
            label1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            indicador.Height = button3.Height;
            indicador.Top = button3.Top;
            FrmConta contaa = new FrmConta();
            contaa.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            indicador.Height = button4.Height;
            indicador.Top = button4.Top;
            formRelatorio1.BringToFront();
            panel3.BringToFront();
            label1.BringToFront();
        }

        private void formRelatorio1_Load(object sender, EventArgs e)
        {

        }

    }
}
 