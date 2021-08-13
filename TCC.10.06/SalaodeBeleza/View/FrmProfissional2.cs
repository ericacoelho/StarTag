using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalaodeBeleza.Model;
using SalaodeBeleza.View;
using SalaodeBeleza.Dao;
using System.ServiceModel;

namespace SalaodeBeleza
{
    public partial class FrmProfissional2 : UserControl
    {
        DaoProfissional daoProf = new DaoProfissional();
        Validacao val = new Validacao();
        Profissional prof = new Profissional();
        FormRelatorio relatorio = new FormRelatorio();
        int operacao = 0;
      //  public string valor = ""; 

        public FrmProfissional2()
        {
            InitializeComponent();
            atualizardatagridview();
            preencherCbEspecialidade();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int cod = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult resultado = MessageBox.Show("Deseja realmente excluir este candidato?", "Exclusão",
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show(daoProf.excluirCandidato(cod));

                atualizardatagridview();
                relatorio.atualizarDataGridView4();

            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
            daoProf.preencherGrid(txtPesquisar.Text);
            dataGridView1.Columns[0].Visible = false;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            if (operacao == 0)
            {
                if (val.IsCpf(maskedTextBox2.Text))
                {

                    prof.Nomecliente = textBox1.Text;
                    prof.Cpfcliente = maskedTextBox2.Text;
                    prof.Ruacliente = textBox3.Text;
                    prof.Numrua = textBox4.Text;
                    prof.Compcliente = textBox5.Text;
                    prof.Cepcliente = textBox6.Text;
                    prof.Bairrocliente = textBox7.Text;
                    prof.Cidadecliente = textBox8.Text;
                    prof.Estado = textBox11.Text;
                    prof.Email = textBox10.Text;
                    prof.Datanasc = Convert.ToDateTime(dateTimePicker1.Text);
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
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    maskedTextBox2.Clear();
                    listBox1.Items.Clear();
                    atualizardatagridview();
                    relatorio.atualizarDataGridView4();

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
                    prof.Codcliente = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value);
                    prof.Nomecliente = textBox1.Text;
                    prof.Cpfcliente = maskedTextBox2.Text;
                    prof.Ruacliente = textBox3.Text;
                    prof.Numrua = textBox4.Text;
                    prof.Compcliente = textBox5.Text;
                    prof.Cepcliente = textBox6.Text;
                    prof.Bairrocliente = textBox7.Text;
                    prof.Cidadecliente = textBox8.Text;
                    prof.Estado = textBox11.Text;
                    prof.Email = textBox10.Text;
                    prof.Datanasc = Convert.ToDateTime(dateTimePicker1.Text);
                    //prof.Especialidade = comboBox1.SelectedItem.ToString();
                    if (radioButton1.Checked)
                    {
                        prof.Sexo = "Masculino";
                    }
                    else
                    {
                        prof.Sexo = "Feminino";
                    }

                    daoProf.alterar(prof);
                    MessageBox.Show("Editado com sucesso!");

                    textBox1.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    maskedTextBox2.Clear();
                    listBox1.Items.Clear();

                    atualizardatagridview();
                    relatorio.atualizarDataGridView4();
                    operacao = 0;

                }
                else
                {
                    MessageBox.Show("CPF inválido!");
                }
            }
               
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

        public void atualizardatagridview(){

            dataGridView1.DataSource =
            daoProf.preencherGrid();
            dataGridView1.Columns[0].Visible = false;
            
        }

        public void preencherCbEspecialidade()
        {
            comboBox1.Items.Clear();
            String[] lista = daoProf.carregarCbEspecialidade();

            for (int i = 0; i < lista.Length; i++)
            {
                comboBox1.Items.Add(lista[i]);

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

        private void FrmProfissional2_Load(object sender, EventArgs e)
        {
            preencherCbEspecialidade();
            atualizardatagridview();
            dataGridView1.DataSource =
            daoProf.preencherGrid();
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmEspecialidade f = new FrmEspecialidade();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // valor = textBox2.Text;
           // textBox2.Clear();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }


    }
}
