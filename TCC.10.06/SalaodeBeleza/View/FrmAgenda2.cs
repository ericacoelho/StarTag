using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalaodeBeleza.Dao;
using SalaodeBeleza.View;
using System.Windows.Documents;
using System.Data.SqlClient;
using System.Drawing.Printing;
using SalaodeBeleza.Model;

namespace SalaodeBeleza.View
{
    public partial class FrmAgenda2 : UserControl
    {
        DaoAgenda dao = new DaoAgenda();
        Validacao val = new Validacao();
        SqlDataReader Leitor = null;
        int paginaAtual;
        int servicoprof = 0;
        private object Me;

        public FrmAgenda2()
        {
            InitializeComponent();
            atualizarDataGridView();
            preecherCbProf();
            //atualizarChecked();
            dao.carregarCbProf();

        }

        public void preecherCbProf()
        {
            checkedListBox1.Items.Clear();
            String[] lista = dao.carregarCbProf();

            for (int i = 0; i < lista.Length; i++)
            {
                checkedListBox1.Items.Add(lista[i]);

            }

        }

        private void FrmAgenda2_Load(object sender, EventArgs e)
        {

            //  checkedListBox1.SelectedItem = true; 
            label5.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            //checkedListBox1.BeginUpdate();
            //atualizarChecked();

            atualizarDataGridView();
            dataGridView1.DataSource =
            dao.preencherGrid();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; //aqui tira as barras entre as palavras do cabeçalhoe tbm a borda
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; //Aqui muda a cor da fonte das palavras do cabeçalho

            //int n = 0;
            //for (int i = 0; i < 1; i++)
            //{
            //    n = dataGridView1.Rows.Add();
            //    dataGridView1.Rows[n].Cells[0].Value = "08:00";
            //    dataGridView1.Rows[n].Cells[1].Value = "";
            //    dataGridView1.Rows[n].Cells[2].Value = "";
            //    n = dataGridView1.Rows.Add();
            //    dataGridView1.Rows[n].Cells[0].Value = "08:30";
            //    dataGridView1.Rows[n].Cells[1].Value = "";
            //    dataGridView1.Rows[n].Cells[2].Value = "";
            //    n = dataGridView1.Rows.Add();
            //    dataGridView1.Rows[n].Cells[0].Value = "09:00";
            //    dataGridView1.Rows[n].Cells[1].Value = "";
            //    dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "09:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "10:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "10:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "11:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "11:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "12:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "12:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "13:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "13:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "14:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "14:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "15:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "15:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "16:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "16:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "17:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "17:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "18:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "18:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "19:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "19:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "20:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "20:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "21:00";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //dataGridView1.Rows[n].Cells[0].Value = "21:30";
            //dataGridView1.Rows[n].Cells[1].Value = "";
            //dataGridView1.Rows[n].Cells[2].Value = "";
            //n = dataGridView1.Rows.Add();
            //}
        }


        //public void atualizarChecked()
        //{
        //    checkedListBox1.DataSource = dao.carregarCbProf();
        //    dataGridView1.Columns[0].Visible = false;
        //}



        private void label3_Click_1(object sender, EventArgs e)
        {
            FrmAgenda form = new FrmAgenda();
            form.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este candidato?", "Exclusão",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show(dao.excluir(cod));

                atualizarDataGridView();

            }
        }

        public void atualizarDataGridView()
        {
            dataGridView1.DataSource =
            dao.preencherGrid();
            dataGridView1.Columns[0].Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmAgenda form = new FrmAgenda();
            form.ShowDialog();
        }

        private void btnNovoAgendam_Click(object sender, EventArgs e)
        {
            FrmAgenda form = new FrmAgenda();
            form.ShowDialog();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // string linguagem = string.Empty;
            // foreach (string s in checkedListBox1.CheckedItems)
            // {
            //     linguagem += s.ToString() + Environment.NewLine;
            //}
            //if(linguagem != string.Empty)
            // {

            dataGridView1.DataSource = dao.preencherGrid(checkedListBox1.SelectedItem.ToString());
            dataGridView1.Columns[0].Visible = false;

            // }
            //for (int i = 0; i < checkedListBox1.Items.Count; i++)
            //  {
            //      if (checkedListBox1.Items[i].Selected)
            //      {
            //          dataGridView1.DataSource =
            //          dao.preencherGrid();
            //          dataGridView1.Columns[0].Visible = false;
            //          //Recupera o valor através do CheckBoxList1.Items[i].Value;
            //      }
            //  }


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PictureBox3_Click(object sender, EventArgs e)
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
                    objPrintPreview.Text = "Relatório de Agenda";
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
            Boolean erro = false;
            for (int i = 0; i <= checkedListBox1.Items.Count - 1; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    erro = true;
                    break;
                }
            }
            if (erro == false)
            {
                Leitor = dao.listarServicos();
                //.conectar();
                paginaAtual = 1;
            }
            else
            {
                String servicoprof;
                Leitor = dao.listarServicos(pictureBox1.Text);
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
            int x = 500;
            int y = 50;
            int width = 100;
            int height = 100;
            // Insere a imagem no relatório
            e.Graphics.DrawImage(newImage, x, y, width, height);


            //Titulo
            e.Graphics.DrawString("Relatório de Agendamentos", FonteTitulo
                , Brushes.Black, e.MarginBounds.Left + 10, 80, new StringFormat());

            //Subtitulo
            e.Graphics.DrawString("Agenda - " +
                System.DateTime.Now, FonteSubTitulo, Brushes.Black,
                e.MarginBounds.Left + 120, 120, new StringFormat());

            //Campos a Serem Impressos

            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 150, e.MarginBounds.Right, 150);


            //Linha por Página
            LinhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 9);

            //Aqui são lidos os Dados
            while ((LinhaAtual < LinhasPorPagina && Leitor.Read()))
            {
                Agenda agenda = new Agenda();

                //Ontém os Valores do DataReader
                agenda.Codagenda = Leitor.GetInt32(0);
                agenda.Data = Leitor.GetDateTime(1);
                agenda.Codprofissional = Leitor.GetString(2);
                agenda.Codcliente = Leitor.GetString(3);
                agenda.Codservico = Leitor.GetString(4);


                //Inicia a Impresão
                PosicaoDaLinha = e.MarginBounds.Top + 80 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));

                e.Graphics.DrawString("Código:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString("Data e Hora:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 130, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString("Profissional:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 360, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString("Cliente:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 40, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString("Serviço:", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 380, PosicaoDaLinha + 35, new StringFormat());

                e.Graphics.DrawString(agenda.Codagenda.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 90, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(agenda.Data.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 210, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(agenda.Codprofissional.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 440, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(agenda.Codcliente.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 90, PosicaoDaLinha + 35, new StringFormat());
                e.Graphics.DrawString(agenda.Codservico.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 435, PosicaoDaLinha + 35, new StringFormat());

                e.Graphics.DrawLine(Risco, e.MarginBounds.Left, PosicaoDaLinha + 80, e.MarginBounds.Right, PosicaoDaLinha + 80);
                LinhaAtual += 8;
            }

            //Rodapé
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, e.MarginBounds.Bottom, e.MarginBounds.Right, e.MarginBounds.Bottom);

            e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom, new StringFormat());

            LinhaAtual += Convert.ToInt32(FonteNormal.GetHeight(e.Graphics));
            LinhaAtual += 1;
            e.Graphics.DrawString("Página: " + paginaAtual, FonteRodape, Brushes.Black, e.MarginBounds.Right - 40, e.MarginBounds.Bottom, new StringFormat());

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
            //Conexao.desconectar();
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //Criei um DataSet para receber o resultado do metodo consultarRegistrosData() no banco
            DataSet ds = new DataSet();
            ////Aqui vou preencher o DataSet com o retorno do método consultarRegistrosData();
            ////Estou passando como parâmetro para a minha consulta SQl a data selecionada no momento em que a pessoa clica no dia
            ds = dao.listarData(monthCalendar1.SelectionStart);
            ////Nesta parte pego o DataSet ja preenchido com o retorno do metodo e associo ele ao meu GridView
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].TableName;
            dataGridView1.Columns[0].Visible = false;
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            atualizarDataGridView();
        }
    }
}