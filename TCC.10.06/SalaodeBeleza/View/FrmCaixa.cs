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

namespace SalaodeBeleza.View
{
    public partial class FrmCaixa : Form
    {
        double guardar;
        public FrmCaixa()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DaoCaixa cai = new DaoCaixa();
            Caixa caixa = new Caixa();

            caixa.Valorinicial = Convert.ToDouble(txtCaixaInicial.Text);

            cai.cadastrar(caixa);

            FrmInicial cliente = new FrmInicial();
            this.Hide();
            cliente.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void FrmCaixa_Load(object sender, EventArgs e)
        {

        }
    }
}
