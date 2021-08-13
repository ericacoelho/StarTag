using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalaodeBeleza.Dao;
using SalaodeBeleza.Model;

namespace SalaodeBeleza.View
{
    public partial class Comanda : UserControl
    {
        DaoAgenda dao = new DaoAgenda();
        DaoEntradaSaida daoPro = new DaoEntradaSaida();
        DaoComanda daoCom = new DaoComanda();
        Comanda1 com = new Comanda1();

        double subServico = 0;

        public Comanda()
        {
            InitializeComponent();
            preecherCbDono();
            preecherCbRaca();
            preencherCbProduto();
            textBox3.Text = "" + subServico;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pagamento pag = new Pagamento();
            pag.Show(); 
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox2.Text);
            com.Codservico = comboBox2.SelectedItem.ToString();
            daoCom.valorServico(com);
            subServico += com.QuantidadeS;
            textBox3.Text = ""+subServico;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(comboBox3.Text);
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pbExcluir_Click(object sender, EventArgs e)
        {
            int iCont;


            for (iCont = (listBox1.Items.Count) - 1; iCont >= 0; iCont--)
            {

                if (listBox1.GetSelected(iCont) == true)
                {
                    listBox1.Items.RemoveAt(iCont);
                    daoCom.valorServico(com);
                    subServico -= com.QuantidadeS;
                    textBox3.Text = "" + subServico;
                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int iCont;


            for (iCont = (listBox2.Items.Count) - 1; iCont >= 0; iCont--)
            {

                if (listBox2.GetSelected(iCont) == true)
                {

                    listBox2.Items.RemoveAt(iCont);

                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void preecherCbRaca()
        {
            String[] listaPartido = dao.carregarCbServico();

            for (int i = 0; i < listaPartido.Length; i++)
            {
                comboBox2.Items.Add(listaPartido[i]);

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

        public void preencherCbProduto()
        {
            comboBox3.Items.Clear();
            String[] lista = daoPro.carregarCbProduto();

            for (int i = 0; i < lista.Length; i++)
            {
                comboBox3.Items.Add(lista[i]);

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
