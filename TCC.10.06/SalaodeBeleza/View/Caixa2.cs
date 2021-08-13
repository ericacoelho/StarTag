using SalaodeBeleza.Dao;
using SalaodeBeleza.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SalaodeBeleza.View
{
    public partial class Caixa2 : Form
    {
        DaoCaixa daoCaixa = new DaoCaixa();
        Caixa caixa = new Caixa();
        double valor = 0;
        public Caixa2()
        {
            InitializeComponent();

            SqlConnection cl = new SqlConnection();
            cl.ConnectionString = ("Server=(local); Database=bdSalao2; Integrated Security=SSPI");
            cl.Open();
            SqlCommand com = new SqlCommand();
            com.CommandText = "SELECT valorInicial FROM tbCaixa";
            com.Connection = cl;
            Conexao.conectar();
            SqlDataReader rd = com.ExecuteReader();


            while (rd.Read())
            {

                valor = Convert.ToDouble(rd["valorInicial"].ToString());

            }
            txtValorInicial.Text = "$" + valor + "";
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Caixa2_Load(object sender, EventArgs e)
        {

        }
    }
}
