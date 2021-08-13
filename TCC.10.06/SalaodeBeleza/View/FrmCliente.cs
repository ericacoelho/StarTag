using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Text;
using System.Windows.Forms;
using SalaodeBeleza.Dao;
using SalaodeBeleza.Model;
using SalaodeBeleza.View;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.ServiceModel;

namespace SalaodeBeleza.Model
{
    public partial class FrmCliente : Form
    {
        DaoCliente daoCliente = new DaoCliente();
        Validacao val = new Validacao();
        Cliente cliente = new Cliente();

        public FrmCliente()
        {
            InitializeComponent();
            ArredondaCantosdoForm();
            //gridCliente.DataSource =
            //daoCliente.preencherGrid();
            //gridCliente.Columns[0].Visible = false;
            //desabilitarEdicao();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            FrmCliente1 f = new FrmCliente1();
            f.atualizarDataGridView();
            DateTime resultado = DateTime.MinValue;
            if (val.IsCpf(maskedTextBox2.Text))
            {
                if (DateTime.TryParse(this.maskedTextBox1.Text.Trim(), out resultado))
                {
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
                    cliente.Datanasc = Convert.ToDateTime(maskedTextBox1.Text);
                    if (radioButton1.Checked)
                    {
                        cliente.Sexo = "Masculino";
                    }
                    else
                    {
                        cliente.Sexo = "Feminino";
                    }


                    //daoCliente.cadastrar(cliente, listBox1.Items.Count, numTelefone);
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
                    maskedTextBox1.Clear();

                }
                else
                {
                    MessageBox.Show("Data Inválida");
                }
            }
            else 
            {
                MessageBox.Show("CPF inválido!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmCliente f = new FrmCliente();
            
            Dispose();
           
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "jpg|*.jpg";
            if (file.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = file.FileName;
            }
        }


        private void lblFechar_Click(object sender, EventArgs e)
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
                
        private void button2_Click(object sender, EventArgs e)
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

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            

            textBox1.Text = cliente.Nomecliente;
            //maskedTextBox2.Clear();
            //textBox3.Clear();
            //textBox4.Clear();
            //textBox5.Clear();
            //textBox6.Clear();
            //textBox7.Clear();
            //textBox8.Clear();
            //textBox9.Clear();
            //textBox10.Clear();
            //textBox11.Clear();
            //listBox1.Items.Clear();
            //maskedTextBox1.Clear();
        }
    }
}
