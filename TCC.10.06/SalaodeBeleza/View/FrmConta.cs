using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;

namespace SalaodeBeleza
{
    public partial class FrmConta : Form
    {

        public FrmConta()
        {
           
            InitializeComponent();
            SqlConnection cl = new SqlConnection();
            cl.ConnectionString = ("Server=DESKTOP-IAKCRTT; Database=bdSalao2; Integrated Security=SSPI");
            cl.Open();
            SqlCommand com = new SqlCommand();
            com.CommandText = "SELECT nomeUsuario, loginUsuario FROM tbUsuario";
            com.Connection = cl;
            Conexao.conectar();
            SqlDataReader rd = com.ExecuteReader();


            while (rd.Read())
            {

                nome = rd["nomeUsuario"].ToString();
                login = rd["loginUsuario"].ToString();

            }
            label5.Text = "" + nome + "";
            label6.Text = "" + login + "";
            label7.Text = "***********";
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

        private void FrmConta_Load(object sender, EventArgs e)
        {
            ArredondaCantosdoForm();
        }
    }
}
