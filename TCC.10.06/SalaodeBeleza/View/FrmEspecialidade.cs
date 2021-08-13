using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalaodeBeleza.Model;
using SalaodeBeleza.Dao;

namespace SalaodeBeleza.View
{
    public partial class FrmEspecialidade : Form
    {
        Especialidade es = new Especialidade();
        DaoEspecialidade dao = new DaoEspecialidade();
        int operacao = 0;
        public FrmEspecialidade()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(txtPesquisar.Text);
            if (operacao == 0)
            {
                es.Descricao = txtPesquisar.Text;
                
                dao.cadastrar(es);

                txtPesquisar.Clear();
                operacao = 0;
            }
            else
            {
                es.Descricao = txtPesquisar.Text;
                dao.alterar(es);


                txtPesquisar.Clear();
                operacao = 0;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            operacao = 1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void FrmEspecialidade_Load(object sender, EventArgs e)
        {
            //FrmProfissional2 importe = new FrmProfissional2();
            //label1.Text = importe.valor;
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

    }
}
