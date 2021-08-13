using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalaodeBeleza.Model;
using System.Drawing.Drawing2D;
using SalaodeBeleza.Dao;

namespace SalaodeBeleza.View
{
    public partial class FrmAgenda : Form
    {
        DaoAgenda dao = new DaoAgenda();
         public FrmAgenda()
        {
 
            InitializeComponent();
            preecherCbDono();
            preecherCbRaca();
            preecherCbProf();
            
        }

        public void AtivarServiço()
        {
            comboBox2.Enabled = true;
            numericUpDown1.Enabled = true;
        }

        public void DesativarServiço()
        {
            comboBox2.Enabled = false;
            numericUpDown1.Enabled = false;
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

        private void pbAdicionar_Click(object sender, EventArgs e)
        {
            AtivarServiço();
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmServico frm = new FrmServico();
            frm.ShowDialog();
        }

        private void FrmAgenda_Load(object sender, EventArgs e)
        {

            ArredondaCantosdoForm();
        }

        public void preecherCbRaca()
        {
            String[] listaPartido = dao.carregarCbServico();

            for (int i = 0; i < listaPartido.Length; i++)
            {
                comboBox2.Items.Add(listaPartido[i]);

            }
            
        }

        public void preecherCbProf()
        {
            String[] lista = dao.carregarCbProf();

            for (int i = 0; i < lista.Length; i++)
            {
                comboBox3.Items.Add(lista[i]);

            }
            
        }

        public void preecherCbDono()
        {
            String[] listaPartido = dao.carregarCbCliente();

            for (int i = 0; i < listaPartido.Length; i++)
            {
                comboBox1.Items.Add(listaPartido[i]);

            }
            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            DateTime dataAtual = Convert.ToDateTime(DateTime.Now);
            DateTime dataEscolhida = Convert.ToDateTime(dateTimePicker1.Text + " " + maskedTextBox1.Text);

            if (dataEscolhida >= dataAtual)
            {
                Agenda agenda = new Agenda();

                agenda.Codprofissional = comboBox3.SelectedItem.ToString();
                agenda.Codcliente = comboBox1.SelectedItem.ToString();
                agenda.Codservico = comboBox2.SelectedItem.ToString();
                agenda.Data = Convert.ToDateTime(dateTimePicker1.Text+" "+maskedTextBox1.Text);

                textBox1.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                maskedTextBox1.Clear();

                dao.cadastrar(agenda);
            }else
            {
                MessageBox.Show("Data inválida!");
            }

            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
