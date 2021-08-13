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
using SalaodeBeleza.View;

namespace SalaodeBeleza.Model
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            FrmInicial cliente = new FrmInicial();
            cliente.Show();
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            FrmCadastro cadastro = new FrmCadastro();
            cadastro.Show();
        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {

            DaoUsuario daoUsuario = new DaoUsuario();
            Usuario usuario = new Usuario();
            usuario.Login = textBox1.Text;
            usuario.Senha = textBox2.Text;
            
            if (daoUsuario.verificar(usuario))
		    {
			    FrmInicial cliente = new FrmInicial();
                this.Hide();
                cliente.ShowDialog();  
		    }
		    else
		    {
			    MessageBox.Show("Usuário ou senha inválido");
		    }
            //if ()
            //{
            //    FrmInicial cliente = new FrmInicial();
            //    cliente.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Dados inválidos");
            //}
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '●';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click_2(object sender, EventArgs e)
        {
            DaoUsuario daoUsuario = new DaoUsuario();
            Usuario usuario = new Usuario();
            usuario.Login = textBox1.Text;
            usuario.Senha = textBox2.Text;

            if (daoUsuario.verificar(usuario))
            {
                FrmCaixa cliente = new FrmCaixa();
                this.Hide();
                cliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválido");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
