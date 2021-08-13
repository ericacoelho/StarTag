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

namespace SalaodeBeleza.Model
{
    public partial class FrmCadastro : Form
    {
        public FrmCadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DaoUsuario daoUsuario = new DaoUsuario();
            Usuario usuario = new Usuario();
            usuario.Nome = txtNome.Text;
            usuario.Login = txtUsuario.Text;
            usuario.Senha = txtSenha.Text;

            daoUsuario.cadastrar(usuario);
            MessageBox.Show("Cadastrado com sucesso!");
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = '*';
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide(); // use dessa maneira.
        }
    }
}
