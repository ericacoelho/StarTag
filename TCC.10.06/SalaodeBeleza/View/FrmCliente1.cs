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
    public partial class FrmCliente1 : UserControl
    {
        DaoCliente daoCliente = new DaoCliente();
        Cliente cliente = new Cliente();
        Validacao val = new Validacao();
        SqlDataReader Leitor = null;
        int paginaAtual;

        int operacao = 0;

        public FrmCliente1()
        {
            InitializeComponent();
            atualizarDataGridView();
        }

        public void FrmCliente1_Load(object sender, EventArgs e)
        {
            atualizarDataGridView();
            dataGridView1.DataSource =
            daoCliente.preencherGrid();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; //aqui tira as barras entre as palavras do cabeçalhoe tbm a borda
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Aqui muda a cor da fonte das palavras do cabeçalho
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este candidato?", "Exclusão",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show(daoCliente.excluirCandidato(cod));

                atualizarDataGridView();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            operacao = 1;

            textBox1.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
            dateTimePicker1.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value));
            textBox10.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value));
            maskedTextBox2.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value));
            textBox3.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[6].Value));
            textBox4.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[7].Value));
            textBox5.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[8].Value));
            maskedTextBox3.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[9].Value));
            textBox7.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[10].Value));
            textBox8.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[11].Value));
            textBox11.Text = (Convert.ToString(dataGridView1.CurrentRow.Cells[12].Value));
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
            daoCliente.preencherGrid(txtPesquisar.Text);
            dataGridView1.Columns[0].Visible = false;
        }

        public void atualizarDataGridView()
        {
            dataGridView1.DataSource =
            daoCliente.preencherGrid();
            dataGridView1.Columns[0].Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox9.Text);
            textBox9.Clear();
        }

        private void pbExcluir_Click(object sender, EventArgs e)
        {
            int iCont;


            for (iCont = (listBox1.Items.Count) - 1; iCont >= 0; iCont--)
            {

                if (listBox1.GetSelected(iCont) == true)
                {

                    listBox1.Items.RemoveAt(iCont);

                }

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            if(operacao == 0){
                if (val.IsCpf(maskedTextBox2.Text))
                {
                    String[] numTelefone = new String[listBox1.Items.Count];
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        numTelefone[i] = listBox1.Items[i].ToString();
                    }
                        DaoCliente daoCliente = new DaoCliente();

                        cliente.Nomecliente = textBox1.Text;
                        cliente.Cpfcliente = maskedTextBox2.Text;
                        cliente.Ruacliente = textBox3.Text;
                        cliente.Numrua = textBox4.Text;
                        cliente.Compcliente = textBox5.Text;
                        cliente.Cepcliente = maskedTextBox3.Text;
                        cliente.Bairrocliente = textBox7.Text;
                        cliente.Cidadecliente = textBox8.Text;
                        cliente.Estadocliente = textBox11.Text;
                        cliente.Email = textBox10.Text;
                        cliente.Datanasc = Convert.ToDateTime(dateTimePicker1.Text);
                        if (radioButton1.Checked)
                        {
                            cliente.Sexo = "Masculino";
                        }
                        else
                        {
                            cliente.Sexo = "Feminino";
                        }


                        daoCliente.cadastrar(cliente, listBox1.Items.Count, numTelefone);
                        MessageBox.Show("Cadastrado com sucesso!");

                        textBox1.Clear();
                        maskedTextBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                        textBox9.Clear();
                        textBox10.Clear();
                        textBox11.Clear();
                        listBox1.Items.Clear();
                        

                        atualizarDataGridView();
                    
                }
                else
                {
                    MessageBox.Show("CPF inválido!");
                }
            }
            else
            {
                if (val.IsCpf(maskedTextBox2.Text))
                {
                    
                        DaoCliente daoCliente = new DaoCliente();

                        cliente.Codcliente = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                        cliente.Nomecliente = textBox1.Text;
                        cliente.Cpfcliente = maskedTextBox2.Text;
                        cliente.Ruacliente = textBox3.Text;
                        cliente.Numrua = textBox4.Text;
                        cliente.Compcliente = textBox5.Text;
                        cliente.Cepcliente = maskedTextBox3.Text;
                        cliente.Bairrocliente = textBox7.Text;
                        cliente.Cidadecliente = textBox8.Text;
                        cliente.Estadocliente = textBox11.Text;
                        cliente.Email = textBox10.Text;
                        cliente.Datanasc = Convert.ToDateTime(dateTimePicker1.Text);
                        if (radioButton1.Checked)
                        {
                            cliente.Sexo = "Masculino";
                        }
                        else
                        {
                            cliente.Sexo = "Feminino";
                        }


                        daoCliente.alterarCandidato(cliente);
                        MessageBox.Show("Editado com sucesso!");

                        textBox1.Clear();
                        maskedTextBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                        textBox9.Clear();
                        textBox10.Clear();
                        textBox11.Clear();
                        listBox1.Items.Clear();

                        operacao = 0;
                        atualizarDataGridView();
                    
                }
                else
                {
                    MessageBox.Show("CPF inválido!");
                } 

            }
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (maskedTextBox3.Text.Length >= 8)
            {
                try
                {

                    ServiceCorreiosCep.AtendeClienteClient consulta = new ServiceCorreiosCep.AtendeClienteClient("AtendeClientePort");
                    var resultado = consulta.consultaCEP(maskedTextBox3.Text);

                    textBox3.Text = resultado.end;
                    textBox7.Text = resultado.bairro;
                    textBox8.Text = resultado.cidade;
                    textBox11.Text = resultado.uf;
                }
                catch (FaultException)
                {
                    MessageBox.Show("CEP não encontrado ou inválido!");

                }
                catch (EndpointNotFoundException)
                {
                    MessageBox.Show("Não foi possível completar a pesquisa");
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
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
                    objPrintPreview.Text = "CLIENTES";
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

            Leitor = daoCliente.listarClientes();
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
            int x = 600;
            int y = 50;
            int width = 110;
            int height = 110;

            // Insere a imagem no relatório
            e.Graphics.DrawImage(newImage, x, y, width, height);


            //Titulo
            e.Graphics.DrawString("RELATÓRIO GERAL DE CLIENTES", FonteTitulo
                , Brushes.Black, e.MarginBounds.Left + 10, 80, new StringFormat());

            //Subtitulo
            e.Graphics.DrawString("CLIENTES - " +
                System.DateTime.Now, FonteSubTitulo, Brushes.Black,
                e.MarginBounds.Left + 120, 120, new StringFormat());

            //Campos a Serem Impressos
            e.Graphics.DrawString("Código", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 50, 170, new StringFormat());
            e.Graphics.DrawString("Nome", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 160, 170, new StringFormat());
            //e.Graphics.DrawString("Data de Nascimento", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 400, 170, new StringFormat());
            e.Graphics.DrawString("Sexo", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 50, 350, new StringFormat());
            e.Graphics.DrawString("Email", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 160, 350, new StringFormat());
            e.Graphics.DrawString("CPF", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 450, 350, new StringFormat());
            e.Graphics.DrawString("CEP", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 50, 540, new StringFormat());
            e.Graphics.DrawString("Rua", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 160, 540, new StringFormat());
            e.Graphics.DrawString("Número", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 400, 540, new StringFormat());
            e.Graphics.DrawString("Complemento", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 490, 540, new StringFormat());
            e.Graphics.DrawString("Bairro", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 50, 730, new StringFormat());
            e.Graphics.DrawString("Cidade", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 260, 730, new StringFormat());
            e.Graphics.DrawString("Estado", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 450, 730, new StringFormat());
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 150, e.MarginBounds.Right, 150);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 190, e.MarginBounds.Right, 190);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 340, e.MarginBounds.Right, 340);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 370, e.MarginBounds.Right, 370);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 530, e.MarginBounds.Right, 530);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 560, e.MarginBounds.Right, 560);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 720, e.MarginBounds.Right, 720);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 750, e.MarginBounds.Right, 750);

            //Linha por Página
            LinhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 9);

            //Aqui são lidos os Dados
            while ((LinhaAtual < LinhasPorPagina && Leitor.Read()))
            {
                //Ontém os Valores do DataReader
                Cliente cliente = new Cliente();
                cliente.Codcliente = Leitor.GetInt32(0);
                cliente.Nomecliente = Leitor.GetString(1);
                /*cliente.Datanasc = Leitor.GetDateTime(2);*/
                cliente.Sexo = Leitor.GetString(2);
                cliente.Email = Leitor.GetString(3);
                cliente.Cpfcliente = Leitor.GetString(4);
                cliente.Cepcliente = Leitor.GetString(5);
                cliente.Ruacliente = Leitor.GetString(6);
                cliente.Numrua = Leitor.GetString(7);
                cliente.Compcliente = Leitor.GetString(8);
                cliente.Bairrocliente = Leitor.GetString(9);
                cliente.Cidadecliente = Leitor.GetString(10);
                cliente.Estadocliente = Leitor.GetString(11);

                //Inicia a Impresão
                PosicaoDaLinha = e.MarginBounds.Top + 100 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
                e.Graphics.DrawString(cliente.Codcliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 50, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(cliente.Nomecliente, FonteNormal, Brushes.Black, e.MarginBounds.Left + 160, PosicaoDaLinha, new StringFormat());
                /*e.Graphics.DrawString(cliente.Datanasc.ToLongDateString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 50, PosicaoDaLinha + 180, new StringFormat());*/
                e.Graphics.DrawString(cliente.Sexo, FonteNormal, Brushes.Black, e.MarginBounds.Left + 50, PosicaoDaLinha + 180, new StringFormat());
                e.Graphics.DrawString(cliente.Email, FonteNormal, Brushes.Black, e.MarginBounds.Left + 160, PosicaoDaLinha + 180, new StringFormat());
                e.Graphics.DrawString(cliente.Cpfcliente, FonteNormal, Brushes.Black, e.MarginBounds.Left + 450, PosicaoDaLinha + 180, new StringFormat());
                e.Graphics.DrawString(cliente.Cepcliente, FonteNormal, Brushes.Black, e.MarginBounds.Left + 50, PosicaoDaLinha + 370, new StringFormat());
                e.Graphics.DrawString(cliente.Ruacliente, FonteNormal, Brushes.Black, e.MarginBounds.Left + 160, PosicaoDaLinha + 370, new StringFormat());
                e.Graphics.DrawString(cliente.Numrua, FonteNormal, Brushes.Black, e.MarginBounds.Left + 400, PosicaoDaLinha + 370, new StringFormat());
                e.Graphics.DrawString(cliente.Compcliente, FonteNormal, Brushes.Black, e.MarginBounds.Left + 490, PosicaoDaLinha + 370, new StringFormat());
                e.Graphics.DrawString(cliente.Bairrocliente, FonteNormal, Brushes.Black, e.MarginBounds.Left + 50, PosicaoDaLinha + 560, new StringFormat());
                e.Graphics.DrawString(cliente.Cidadecliente, FonteNormal, Brushes.Black, e.MarginBounds.Left + 260, PosicaoDaLinha + 560, new StringFormat());
                e.Graphics.DrawString(cliente.Estadocliente, FonteNormal, Brushes.Black, e.MarginBounds.Left + 450, PosicaoDaLinha + 560, new StringFormat());

                LinhaAtual += 1;
            }

            //Rodapé
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, e.MarginBounds.Bottom, e.MarginBounds.Right, e.MarginBounds.Bottom);

            e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom, new StringFormat());

            LinhaAtual += Convert.ToInt32(FonteNormal.GetHeight(e.Graphics));
            LinhaAtual += 1;
            e.Graphics.DrawString("Página :" + paginaAtual, FonteRodape, Brushes.Black, e.MarginBounds.Right - 50, e.MarginBounds.Bottom, new StringFormat());

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
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
                    objPrintPreview.Text = "CLIENTES";
                    objPrintPreview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}