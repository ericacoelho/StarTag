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
using System.ServiceModel;

namespace SalaodeBeleza.Model
{
    public partial class FrmProfissional : Form
    {
        Validacao val = new Validacao();
        DaoProfissional daoProf = new DaoProfissional();
        Profissional prof = new Profissional();
      
        public FrmProfissional()
        {
            InitializeComponent();
            ArredondaCantosdoForm();
            preencherCbEspecialidade();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DateTime resultado = DateTime.MinValue;

            if (val.IsCpf(textBox2.Text))
            {
                if (DateTime.TryParse(this.maskedTextBox1.Text.Trim(), out resultado))
                {
                    
                    prof.Nomecliente = textBox1.Text;
                    prof.Cpfcliente = textBox2.Text;
                    prof.Ruacliente = textBox3.Text;
                    prof.Numrua = textBox4.Text;
                    prof.Compcliente = textBox5.Text;
                    prof.Cepcliente = textBox6.Text;
                    prof.Bairrocliente = textBox7.Text;
                    prof.Cidadecliente = textBox8.Text;
                    prof.Estado = textBox11.Text;
                    prof.Email = textBox10.Text;
                    prof.Datanasc = Convert.ToDateTime(maskedTextBox1.Text);
                    prof.Especialidade = comboBox1.SelectedItem.ToString();
                    if (radioButton1.Checked)
                    {
                        prof.Sexo = "Masculino";
                    }
                    else
                    {
                        prof.Sexo = "Feminino";
                    }

                    daoProf.cadastrar(prof);
                    MessageBox.Show("Cadastrado com sucesso!");

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    maskedTextBox1.Clear();
                    listBox1.Items.Clear();
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

        private void textBox6_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 8)
            {
                try
                {
                    ServiceCorreiosCep.AtendeClienteClient consulta = new ServiceCorreiosCep.AtendeClienteClient("AtendeClientePort");
                    var resultado = consulta.consultaCEP(textBox6.Text);

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

        private void button1_Click(object sender, EventArgs e)
        {
           
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

        private void textBox6_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            if (textBox6.Text.Length >= 8)
            {
                try
                {
                    ServiceCorreiosCep.AtendeClienteClient consulta = new ServiceCorreiosCep.AtendeClienteClient("AtendeClientePort");
                    var resultado = consulta.consultaCEP(textBox6.Text);

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

        public void preencherCbEspecialidade()
        {
            String[] lista = daoProf.carregarCbEspecialidade();

            for (int i = 0; i < lista.Length; i++)
            {
                comboBox1.Items.Add(lista[i]);

            }
            comboBox1.Items.Add(daoProf.carregarCbEspecialidade());
        }

        private void FrmProfissional_Load(object sender, EventArgs e)
        {

        }

    }
}
