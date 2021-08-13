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
using System.ServiceModel;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace SalaodeBeleza.View
{
    public partial class FormRelatorio : UserControl
    {
        DaoCliente daoCliente = new DaoCliente();
        DaoServico daoServicos = new DaoServico();
        DaoEstoque daoEstoque = new DaoEstoque();
        DaoProfissional daoProfissional = new DaoProfissional();
        Validacao val = new Validacao();
        SqlDataReader Leitor = null;
        int paginaAtual;
        int profind = 0;
        int prodcod = 0;
        int servcod = 0;
        int cliencod = 0;

        public FormRelatorio()
        {
            InitializeComponent();
            desabilitarEdicao();
        }

        private void FormRelatorio_Load(object sender, EventArgs e)
        {
            atualizarDataGridView1();
            atualizarDataGridView2();
            atualizarDataGridView3();
            atualizarDataGridView4();

            dataGridView1.DataSource =
            daoCliente.preencherList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; //aqui tira as barras entre as palavras do cabeçalhoe tbm a borda
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Aqui muda a cor da fonte das palavras do cabeçalho
            //
            dataGridView2.DataSource =
            daoServicos.preencherList();
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; //aqui tira as barras entre as palavras do cabeçalhoe tbm a borda
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Aqui muda a cor da fonte das palavras do cabeçalho
            //
            dataGridView3.DataSource =
            daoEstoque.preencherList();
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.BorderStyle = BorderStyle.None;
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; //aqui tira as barras entre as palavras do cabeçalhoe tbm a borda
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Aqui muda a cor da fonte das palavras do cabeçalho
            //                                                                     //
            dataGridView4.DataSource =
            daoProfissional.preencherList();
            dataGridView4.Columns[0].Visible = false;
            dataGridView4.BorderStyle = BorderStyle.None;
            dataGridView4.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView4.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView4.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView4.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; //aqui tira as barras entre as palavras do cabeçalhoe tbm a borda
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Aqui muda a cor da fonte das palavras do cabeçalho
        }
        public void atualizarDataGridView1()
        {
            dataGridView1.DataSource =
            daoCliente.preencherList();
            dataGridView1.Columns[0].Visible = false;
        }
        public void atualizarDataGridView2()
        {
            dataGridView2.DataSource =
            daoProfissional.preencherList();
            dataGridView2.Columns[0].Visible = false;
        }
        public void atualizarDataGridView3()
        {
            dataGridView3.DataSource =
            daoEstoque.preencherList();
            dataGridView3.Columns[0].Visible = false;
        }
        public void atualizarDataGridView4()
        {
            dataGridView4.DataSource =
            daoProfissional.preencherList();
            dataGridView4.Columns[0].Visible = false;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            desabilitarEdicao();
        }
        private void txtPesquisar1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
            daoCliente.preencherList(txtPesquisar1.Text);
            dataGridView1.Columns[0].Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource =
            daoServicos.preencherList(textBox2.Text);
            dataGridView2.Columns[0].Visible = false;
        }
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView3.DataSource =
            daoEstoque.preencherList(textBox3.Text);
            dataGridView3.Columns[0].Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView4.DataSource =
            daoProfissional.preencherList(textBox4.Text);
            dataGridView4.Columns[0].Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Define os objetos printdocument e os Eventos Associados
            PrintDocument pd = new PrintDocument();
            //IMPORTANTE - Definimos 3 eventos para tratar a 
            //Impressão: PringPage , BeginPrint e EndPrint
            pd.PrintPage += new PrintPageEventHandler(this.printDocument2_PrintPage);
            pd.BeginPrint += new PrintEventHandler(this.printDocument2_BeginPrint);
            pd.EndPrint += new PrintEventHandler(this.printDocument2_EndPrint);
            //Define o Objeto para visualizar a impressão
            PrintPreviewDialog objPrintPreview = new PrintPreviewDialog();
            try
            {
                //Define o formulário como Maximizado e com Zoom
                {
                    objPrintPreview.Document = pd;
                    objPrintPreview.WindowState = FormWindowState.Maximized;
                    objPrintPreview.PrintPreviewControl.Zoom = 1;
                    objPrintPreview.Text = "Relatório de Clientes";
                    objPrintPreview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void printDocument2_BeginPrint(object sender, PrintEventArgs e)
        {
            if (radioButton2.Checked)
            {
                Leitor = daoServicos.listarServicos();
                //.conectar();
                paginaAtual = 1;
            }
            else if (dataGridView2.Enabled == true)
            {

                Leitor = daoServicos.listarServicosIndividual(servcod);
                //.conectar();
                paginaAtual = 1;
            }

            //.conectar();
            paginaAtual = 1;
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Variáveis das Linhas
            float LinhasPorPagina = 0;
            float PosicaoDaLinha = 0;
            int LinhaAtual = 0;

            //Variável para passar um traço
            Pen Risco = new Pen(Color.Black, 1);

            //Define as Fontes
            Font FonteNegrito = new Font("Arial", 9, FontStyle.Bold);
            Font FonteTitulo = new Font("Arial", 15, FontStyle.Bold);
            Font FonteSubTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font FonteRodape = new Font("Arial", 8);
            Font FonteNormal = new Font("Arial", 9);

            //Cabeçalho
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 60, e.MarginBounds.Right, 60);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 160, e.MarginBounds.Right, 160);

            // criando uma imagem
            Image newImage = Image.FromFile("logocomnome.png");

            // tamanhos e posicionamento da imagem
            int x = 540;
            int y = 50;
            int width = 110;
            int height = 110;
            // Insere a imagem no relatório
            e.Graphics.DrawImage(newImage, x, y, width, height);


            //Titulo
            e.Graphics.DrawString("Relatório de Serviços", FonteTitulo
                , Brushes.Black, e.MarginBounds.Left + 10, 80, new StringFormat());

            //Subtitulo
            e.Graphics.DrawString("Serviços - " +
                System.DateTime.Now, FonteSubTitulo, Brushes.Black,
                e.MarginBounds.Left + 120, 120, new StringFormat());

            //Campos a Serem Impressos

            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 150, e.MarginBounds.Right, 150);

           
            //Linha por Página
            LinhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 9);

            //Aqui são lidos os Dados
            while ((LinhaAtual < LinhasPorPagina && Leitor.Read()))
            {
                Servico servico = new Servico();
                
                //Ontém os Valores do DataReader
                servico.CodServico = Leitor.GetInt32(0);
                servico.DescServico = Leitor.GetString(1);
                servico.Valor = Leitor.GetDecimal(2);


                //Inicia a Impresão 
                
                PosicaoDaLinha = e.MarginBounds.Top + 100 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));

                e.Graphics.DrawString("Código:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString("Descrição:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 150, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString("Valor:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 415, PosicaoDaLinha, new StringFormat());

                e.Graphics.DrawString(servico.CodServico.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 90, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(servico.DescServico, FonteNormal, Brushes.Black, e.MarginBounds.Left + 220, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(servico.Valor.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 455, PosicaoDaLinha, new StringFormat());

                e.Graphics.DrawLine(Risco, e.MarginBounds.Left, PosicaoDaLinha + 30, e.MarginBounds.Right, PosicaoDaLinha + 30);
                LinhaAtual += 5;
            }

            //Rodapé
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, e.MarginBounds.Bottom, e.MarginBounds.Right, e.MarginBounds.Bottom);

            e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom, new StringFormat());

            LinhaAtual += Convert.ToInt32(FonteNormal.GetHeight(e.Graphics));
            LinhaAtual += 1;
            e.Graphics.DrawString("Página: " + paginaAtual, FonteRodape, Brushes.Black, e.MarginBounds.Right - 50, e.MarginBounds.Bottom, new StringFormat());

            //Incrementa o Número da Pagina
            paginaAtual += 1;

            //Verifica se Continua Imprimindo
            if ((LinhaAtual > LinhasPorPagina))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }

        }

        private void printDocument2_EndPrint(object sender, PrintEventArgs e)
        {
            //Fecha o DataReader
            Leitor.Close();
            //Fecha a Conexão
            Conexao.desconectar();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void habilitarEdicao()
        {
            label3.Enabled = true;
            txtPesquisar1.Enabled = true;
            dataGridView1.Enabled = true;

            label6.Enabled = true;
            textBox2.Enabled = true;
            dataGridView2.Enabled = true;

            label8.Enabled = true;
            textBox3.Enabled = true;
            dataGridView3.Enabled = true;

            label10.Enabled = true;
            textBox4.Enabled = true;
            dataGridView4.Enabled = true;
        }

        public void desabilitarEdicao()
        {
            //   btnPesquisar.Enabled = false;
            label3.Enabled = false;
            txtPesquisar1.Enabled = false;
            dataGridView1.Enabled = false;


            label6.Enabled = false;
            textBox2.Enabled = false;
            dataGridView2.Enabled = false;

            label8.Enabled = false;
            textBox3.Enabled = false;
            dataGridView3.Enabled = false;

            label10.Enabled = false;
            textBox4.Enabled = false;
            dataGridView4.Enabled = false;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //if(radioButton1.Checked)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Define os objetos printdocument e os Eventos Associados
            PrintDocument pd = new PrintDocument();
            //IMPORTANTE - Definimos 3 eventos para tratar a 
            //Impressão: PringPage , BeginPrint e EndPrint
            pd.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
            pd.BeginPrint += new PrintEventHandler(this.printDocument1_BeginPrint);
            pd.EndPrint += new PrintEventHandler(this.printDocument1_EndPrint);
            //Define o Objeto para visualizar a impressão
            PrintPreviewDialog objPrintPreview = new PrintPreviewDialog();
            try
            {
                //Define o formulário como Maximizado e com Zoom
                {
                    objPrintPreview.Document = pd;
                    objPrintPreview.WindowState = FormWindowState.Maximized;
                    objPrintPreview.PrintPreviewControl.Zoom = 1;
                    objPrintPreview.Text = "Relatório de Clientes";
                    objPrintPreview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            if (radioButton1.Checked)
            {
                Leitor = daoCliente.listarClientes();
                //.conectar();
                paginaAtual = 1;
            }
            else if (dataGridView1.Enabled == true)
            {
                Leitor = daoCliente.listarClientesIndividual(cliencod);
                //.conectar();
                paginaAtual = 1;
            }

            //.conectar();
            paginaAtual = 1;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Variáveis das Linhas

            float LinhasPorPagina = 0;
            float PosicaoDaLinha = 0;
            int LinhaAtual = 0;

            //Variável para passar um traço
            Pen Risco = new Pen(Color.Black, 1);

            //Define as Fontes
            Font FonteNegrito = new Font("Arial", 9, FontStyle.Bold);
            Font FonteTitulo = new Font("Arial", 15, FontStyle.Bold);
            Font FonteSubTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font FonteRodape = new Font("Arial", 8);
            Font FonteNormal = new Font("Arial", 9);

            //Cabeçalho
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 60, e.MarginBounds.Right, 60);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 160, e.MarginBounds.Right, 160);

            // criando uma imagem
            Image newImage = Image.FromFile("logocomnome.png");

            // tamanhos e posicionamento da imagem
            int x = 540;
            int y = 50;
            int width = 110;
            int height = 110;
            // Insere a imagem no relatório
            e.Graphics.DrawImage(newImage, x, y, width, height);


            //Titulo
            e.Graphics.DrawString("Relatório de Clientes", FonteTitulo
                , Brushes.Black, e.MarginBounds.Left + 10, 80, new StringFormat());

            //Subtitulo
            e.Graphics.DrawString("Clientes - " +
                System.DateTime.Now, FonteSubTitulo, Brushes.Black,
                e.MarginBounds.Left + 120, 120, new StringFormat());

            //Campos a Serem Impressos

            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 150, e.MarginBounds.Right, 150);

           
            //Linha por Página
            LinhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 9);

            //Aqui são lidos os Dados
            while ((LinhaAtual < LinhasPorPagina && Leitor.Read()))
            {
                Cliente cliente = new Cliente();
                /*SELECT tbCliente.codCliente, nomeCliente as 'Nome', cpfCliente as 'CPF', cepCliente as 'CEP', ruaCliente as 'Rua'," + 
                "numRuaCliente as 'Número', compCliente as 'Complemento', bairroCliente as 'Bairro'," +
                " cidadeCliente as 'Cidade', numFoneCliente as 'Telefone' " +
                "FROM tbFoneCliente inner join tbCliente on tbCliente.codCliente = tbFoneCliente.*/

                //Ontém os Valores do DataReader
                cliente.Codcliente = Leitor.GetInt32(0);
                cliente.Nomecliente = Leitor.GetString(1);
                cliente.Datanasc = Leitor.GetDateTime(2);

                cliente.Sexo = Leitor.GetString(3);
                cliente.Email = Leitor.GetString(4);
                cliente.Cpfcliente = Leitor.GetString(5);

                cliente.Cepcliente = Leitor.GetString(6);
                cliente.Ruacliente = Leitor.GetString(7);
                cliente.Numrua = Leitor.GetString(8);
                cliente.Compcliente = Leitor.GetString(9);

                cliente.Bairrocliente = Leitor.GetString(10);
                cliente.Cidadecliente = Leitor.GetString(11);
                cliente.Estadocliente = Leitor.GetString(12);

                //Inicia a Impresão
                //Inicia a Impresão
                PosicaoDaLinha = e.MarginBounds.Top + 100 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));

                e.Graphics.DrawString("Código:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString("Nome:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 130, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString("Data de Nasc.:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 425, PosicaoDaLinha, new StringFormat());

                e.Graphics.DrawString("Sexo:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString("Email:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 170, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString("CPF:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 450, PosicaoDaLinha + 35, new StringFormat());

                e.Graphics.DrawString("CEP:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString("Rua:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 160, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString("Número:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 400, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString("Comp:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 510, PosicaoDaLinha + 70, new StringFormat());

                e.Graphics.DrawString("Bairro:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha + 105, new StringFormat());
                e.Graphics.DrawString("Cidade:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 300, PosicaoDaLinha + 105, new StringFormat());
                e.Graphics.DrawString("Estado:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 470, PosicaoDaLinha + 105, new StringFormat());


                e.Graphics.DrawString(cliente.Codcliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 90, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(cliente.Nomecliente, FonteNormal, Brushes.Black, e.MarginBounds.Left + 180, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(cliente.Datanasc.ToString("dd/mm/yyyy"), FonteNormal, Brushes.Black, e.MarginBounds.Left + 510, PosicaoDaLinha, new StringFormat());

                e.Graphics.DrawString(cliente.Sexo.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 80, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString(cliente.Email.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 215, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString(cliente.Cpfcliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 480, PosicaoDaLinha + 35, new StringFormat());

                e.Graphics.DrawString(cliente.Cepcliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 80, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString(cliente.Ruacliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 200, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString(cliente.Numrua.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 455, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString(cliente.Compcliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 560, PosicaoDaLinha + 70, new StringFormat());

                e.Graphics.DrawString(cliente.Bairrocliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 90, PosicaoDaLinha + 105, new StringFormat());
                e.Graphics.DrawString(cliente.Cidadecliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 350, PosicaoDaLinha + 105, new StringFormat());
                e.Graphics.DrawString(cliente.Estadocliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 520, PosicaoDaLinha + 105, new StringFormat());
                e.Graphics.DrawLine(Risco, e.MarginBounds.Left, PosicaoDaLinha + 150, e.MarginBounds.Right, PosicaoDaLinha + 150);
                LinhaAtual += 13;

            }

            //Rodapé
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, e.MarginBounds.Bottom, e.MarginBounds.Right, e.MarginBounds.Bottom);

            e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom, new StringFormat());

            LinhaAtual += Convert.ToInt32(FonteNormal.GetHeight(e.Graphics));
            LinhaAtual += 1;
            e.Graphics.DrawString("Página: " + paginaAtual, FonteRodape, Brushes.Black, e.MarginBounds.Right - 50, e.MarginBounds.Bottom, new StringFormat());

            //Incrementa o Número da Pagina
            paginaAtual += 1;

            //Verifica se Continua Imprimindo
            if ((LinhaAtual > LinhasPorPagina))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }

        }
       

        private void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            //Fecha o DataReader
            Leitor.Close();
            //Fecha a Conexão
            Conexao.desconectar();

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }
        private void PictureBox4_Click(object sender, EventArgs e)
        {
            //Define os objetos printdocument e os Eventos Associados
            PrintDocument pd = new PrintDocument();
            //IMPORTANTE - Definimos 3 eventos para tratar a 
            //Impressão: PringPage , BeginPrint e EndPrint
            pd.PrintPage += new PrintPageEventHandler(this.printDocument3_PrintPage);
            pd.BeginPrint += new PrintEventHandler(this.printDocument3_BeginPrint);
            pd.EndPrint += new PrintEventHandler(this.printDocument3_EndPrint);
            //Define o Objeto para visualizar a impressão
            PrintPreviewDialog objPrintPreview = new PrintPreviewDialog();
            try
            {
                //Define o formulário como Maximizado e com Zoom
                {
                    objPrintPreview.Document = pd;
                    objPrintPreview.WindowState = FormWindowState.Maximized;
                    objPrintPreview.PrintPreviewControl.Zoom = 1;
                    objPrintPreview.Text = "Relatório de Profissionais";
                    objPrintPreview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void printDocument3_BeginPrint(object sender, PrintEventArgs e)
        {
            if (radioButton4.Checked) { 
            Leitor = daoProfissional.listarProfissionais();
            //.conectar();
            paginaAtual = 1;
        }
            else if (dataGridView4.Enabled == true) {
                
                Leitor = daoProfissional.listarProfissionaisIndividual(profind);
                //.conectar();
                paginaAtual = 1;
            }
        }
        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Variáveis das Linhas
            float LinhasPorPagina = 0;
            float PosicaoDaLinha = 0;
            int LinhaAtual = 0;

            //Variável para passar um traço
            Pen Risco = new Pen(Color.Black, 1);

            //Define as Fontes
            Font FonteNegrito = new Font("Arial", 9, FontStyle.Bold);
            Font FonteTitulo = new Font("Arial", 15, FontStyle.Bold);
            Font FonteSubTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font FonteRodape = new Font("Arial", 8);
            Font FonteNormal = new Font("Arial", 9);

            //Cabeçalho
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 60, e.MarginBounds.Right, 60);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 160, e.MarginBounds.Right, 160);

            // criando uma imagem
            Image newImage = Image.FromFile("logocomnome.png");

            // tamanhos e posicionamento da imagem
            int x = 540;
            int y = 50;
            int width = 110;
            int height = 110;
            // Insere a imagem no relatório
            e.Graphics.DrawImage(newImage, x, y, width, height);

            //Titulo
            e.Graphics.DrawString("Relatório de Profissionais", FonteTitulo
                , Brushes.Black, e.MarginBounds.Left + 10, 80, new StringFormat());

            //Subtitulo
            e.Graphics.DrawString("Proofissionais - " +
                System.DateTime.Now, FonteSubTitulo, Brushes.Black,
                e.MarginBounds.Left + 120, 120, new StringFormat());

            //Campos a Serem Impressos

            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 150, e.MarginBounds.Right, 150);

            //e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 340, e.MarginBounds.Right, 340);

            //Linha por Página
            LinhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 9);

            //Aqui são lidos os Dados
            while ((LinhaAtual < LinhasPorPagina && Leitor.Read()))
            {
                Profissional prof = new Profissional();
                
                //Ontém os Valores do DataReader
                prof.Codcliente = Leitor.GetInt32(0);
                prof.Nomecliente = Leitor.GetString(1);
                prof.Datanasc = Leitor.GetDateTime(2);
                prof.Sexo = Leitor.GetString(3);
                prof.Email = Leitor.GetString(4);
                prof.Cpfcliente = Leitor.GetString(5);
                prof.Cepcliente = Leitor.GetString(6);
                prof.Ruacliente = Leitor.GetString(7);
                prof.Numrua = Leitor.GetString(8);
                prof.Compcliente = Leitor.GetString(9);
                prof.Bairrocliente = Leitor.GetString(10);
                prof.Cidadecliente = Leitor.GetString(11);
                prof.Estadocliente = Leitor.GetString(12);

                //Inicia a Impresão
                PosicaoDaLinha = e.MarginBounds.Top + 100 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));

                e.Graphics.DrawString("Código:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString("Nome:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 130, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString("Data de Nasc.:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 425, PosicaoDaLinha, new StringFormat());

                e.Graphics.DrawString("Sexo:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString("Email:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 170, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString("CPF:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 450, PosicaoDaLinha + 35, new StringFormat());

                e.Graphics.DrawString("CEP:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString("Rua:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 160, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString("Número:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 400, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString("Comp:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 510, PosicaoDaLinha + 70, new StringFormat());

                e.Graphics.DrawString("Bairro:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha + 105, new StringFormat());
                e.Graphics.DrawString("Cidade:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 300, PosicaoDaLinha + 105, new StringFormat());
                e.Graphics.DrawString("Estado:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 470, PosicaoDaLinha + 105, new StringFormat());
                

                e.Graphics.DrawString(prof.Codcliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 90, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(prof.Nomecliente, FonteNormal, Brushes.Black, e.MarginBounds.Left + 180, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(prof.Datanasc.ToString("dd/mm/yyyy"), FonteNormal, Brushes.Black, e.MarginBounds.Left + 510, PosicaoDaLinha, new StringFormat());

                e.Graphics.DrawString(prof.Sexo.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 80, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString(prof.Email.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 215, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString(prof.Cpfcliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 480, PosicaoDaLinha + 35, new StringFormat());

                e.Graphics.DrawString(prof.Cepcliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 80, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString(prof.Ruacliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 200, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString(prof.Numrua.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 455, PosicaoDaLinha + 70, new StringFormat());
                e.Graphics.DrawString(prof.Compcliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 560, PosicaoDaLinha + 70, new StringFormat());

                e.Graphics.DrawString(prof.Bairrocliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 90, PosicaoDaLinha + 105, new StringFormat());
                e.Graphics.DrawString(prof.Cidadecliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 350, PosicaoDaLinha + 105, new StringFormat());
                e.Graphics.DrawString(prof.Estadocliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 520, PosicaoDaLinha + 105, new StringFormat());

                /* e.Graphics.DrawString(cliente.CodPet.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 140, PosicaoDaLinha + 105, new StringFormat());
                 e.Graphics.DrawString(cliente.NomePet.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 400, PosicaoDaLinha + 105, new StringFormat());
                 */

                e.Graphics.DrawLine(Risco, e.MarginBounds.Left, PosicaoDaLinha + 150, e.MarginBounds.Right, PosicaoDaLinha + 150);


                LinhaAtual += 13;

            }

            //Rodapé
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, e.MarginBounds.Bottom, e.MarginBounds.Right, e.MarginBounds.Bottom);

            e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom, new StringFormat());

            LinhaAtual += Convert.ToInt32(FonteNormal.GetHeight(e.Graphics));
            LinhaAtual += 1;
            e.Graphics.DrawString("Página: " + paginaAtual, FonteRodape, Brushes.Black, e.MarginBounds.Right - 50, e.MarginBounds.Bottom, new StringFormat());

            //Incrementa o Número da Pagina
            paginaAtual += 1;

            //Verifica se Continua Imprimindo
            if ((LinhaAtual > LinhasPorPagina))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }

        }

        private void printDocument3_EndPrint(object sender, PrintEventArgs e)
        {
            //Fecha o DataReader
            Leitor.Close();
            //Fecha a Conexão
            Conexao.desconectar();


        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            //Define os objetos printdocument e os Eventos Associados
            PrintDocument pd = new PrintDocument();
            //IMPORTANTE - Definimos 3 eventos para tratar a 
            //Impressão: PringPage , BeginPrint e EndPrint
            pd.PrintPage += new PrintPageEventHandler(this.printDocument4_PrintPage);
            pd.BeginPrint += new PrintEventHandler(this.printDocument4_BeginPrint);
            pd.EndPrint += new PrintEventHandler(this.printDocument4_EndPrint);
            //Define o Objeto para visualizar a impressão
            PrintPreviewDialog objPrintPreview = new PrintPreviewDialog();
            try
            {
                //Define o formulário como Maximizado e com Zoom
                {
                    objPrintPreview.Document = pd;
                    objPrintPreview.WindowState = FormWindowState.Maximized;
                    objPrintPreview.PrintPreviewControl.Zoom = 1;
                    objPrintPreview.Text = "Relatório de Produtos";
                    objPrintPreview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void printDocument4_BeginPrint(object sender, PrintEventArgs e)
        {
            if (radioButton3.Checked)
            {
                Leitor = daoEstoque.listarEstoque();
                //.conectar();
                paginaAtual = 1;
            }
            else if (dataGridView3.Enabled == true)
            {

                Leitor = daoEstoque.listarEstoqueIndividual(prodcod);
                //.conectar();
                paginaAtual = 1;
            }

            //.conectar();
            paginaAtual = 1;
        }

        private void printDocument4_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Variáveis das Linhas
            float LinhasPorPagina = 0;
            float PosicaoDaLinha = 0;
            int LinhaAtual = 0;

            //Variável para passar um traço
            Pen Risco = new Pen(Color.Black, 1);

            //Define as Fontes
            Font FonteNegrito = new Font("Arial", 9, FontStyle.Bold);
            Font FonteTitulo = new Font("Arial", 15, FontStyle.Bold);
            Font FonteSubTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font FonteRodape = new Font("Arial", 8);
            Font FonteNormal = new Font("Arial", 9);

            //Cabeçalho
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 60, e.MarginBounds.Right, 60);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 160, e.MarginBounds.Right, 160);

            // criando uma imagem
            Image newImage = Image.FromFile("logocomnome.png");

            // tamanhos e posicionamento da imagem
            int x = 540;
            int y = 50;
            int width = 110;
            int height = 110;
            // Insere a imagem no relatório
            e.Graphics.DrawImage(newImage, x, y, width, height);


            //Titulo
            e.Graphics.DrawString("Relatório de Produtos", FonteTitulo
                , Brushes.Black, e.MarginBounds.Left + 10, 80, new StringFormat());

            //Subtitulo
            e.Graphics.DrawString("Produtos - " +
                System.DateTime.Now, FonteSubTitulo, Brushes.Black,
                e.MarginBounds.Left + 120, 120, new StringFormat());

            //Campos a Serem Impressos

            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 150, e.MarginBounds.Right, 150);

            //e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 340, e.MarginBounds.Right, 340);




            //Linha por Página
            LinhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 9);

            //Aqui são lidos os Dados
            while ((LinhaAtual < LinhasPorPagina && Leitor.Read()))
            {
               Produto produto =  new Produto();
                /*SELECT tbCliente.codCliente, nomeCliente as 'Nome', cpfCliente as 'CPF', cepCliente as 'CEP', ruaCliente as 'Rua'," + 
                "numRuaCliente as 'Número', compCliente as 'Complemento', bairroCliente as 'Bairro'," +
                " cidadeCliente as 'Cidade', numFoneCliente as 'Telefone' " +
                "FROM tbFoneCliente inner join tbCliente on tbCliente.codCliente = tbFoneCliente.*/

                //Ontém os Valores do DataReader
                produto.CodProduto = Leitor.GetInt32(0);
                produto.DescProduto = Leitor.GetString(1);
                produto.QuantEstoque = Leitor.GetInt32(2);
                produto.Money = Convert.ToDouble(Leitor.GetDecimal(3));
                produto.CodFabricante = Leitor.GetString(4);
                

                //Inicia a Impresão
                PosicaoDaLinha = e.MarginBounds.Top + 100 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));

                e.Graphics.DrawString("Código:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString("Descrição:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 150, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString("Quantidade:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 415, PosicaoDaLinha, new StringFormat());

                e.Graphics.DrawString("Preço:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString("Fabricante:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 170, PosicaoDaLinha + 35, new StringFormat());
                
                e.Graphics.DrawString(produto.CodProduto.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 90, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(produto.DescProduto, FonteNormal, Brushes.Black, e.MarginBounds.Left + 220, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(produto.QuantEstoque.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 495, PosicaoDaLinha, new StringFormat());

                e.Graphics.DrawString(produto.Money.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 90, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString(produto.CodFabricante, FonteNormal, Brushes.Black, e.MarginBounds.Left + 245, PosicaoDaLinha + 35, new StringFormat());
                
                /* e.Graphics.DrawString(cliente.CodPet.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 140, PosicaoDaLinha + 105, new StringFormat());
                 e.Graphics.DrawString(cliente.NomePet.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 400, PosicaoDaLinha + 105, new StringFormat());
                 */

                e.Graphics.DrawLine(Risco, e.MarginBounds.Left, PosicaoDaLinha + 60, e.MarginBounds.Right, PosicaoDaLinha + 60);
                LinhaAtual +=8;
             }

            //Rodapé
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, e.MarginBounds.Bottom, e.MarginBounds.Right, e.MarginBounds.Bottom);

            e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom, new StringFormat());

            LinhaAtual += Convert.ToInt32(FonteNormal.GetHeight(e.Graphics));
            LinhaAtual += 1;
            e.Graphics.DrawString("Página: " + paginaAtual, FonteRodape, Brushes.Black, e.MarginBounds.Right - 50, e.MarginBounds.Bottom, new StringFormat());

            //Incrementa o Número da Pagina
            paginaAtual += 1;

            //Verifica se Continua Imprimindo
            if ((LinhaAtual > LinhasPorPagina))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }

        }
        private void printDocument4_EndPrint(object sender, PrintEventArgs e)
        {
            //Fecha o DataReader
            Leitor.Close();
            //Fecha a Conexão
            Conexao.desconectar();

        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            desabilitarEdicao();
        }

        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            profind = Convert.ToInt16(dataGridView4.CurrentRow.Cells[0].Value);
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            prodcod = Convert.ToInt16(dataGridView3.CurrentRow.Cells[0].Value);
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            servcod = Convert.ToInt16(dataGridView2.CurrentRow.Cells[0].Value);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cliencod = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            habilitarEdicao();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            desabilitarEdicao();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            desabilitarEdicao();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            habilitarEdicao();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            habilitarEdicao();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            habilitarEdicao();
        }

    }
    
}