using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SalaodeBeleza
{
    static class Conexao
    {
        // public static SqlConnection strConexao = new SqlConnection(@"Server=DESKTOP-TFIQCO8\SQLEXPRESS; Database=bdSalao2; Integrated Security=SSPI");
        //public static SqlConnection strConexao = new SqlConnection(@"Server=ISABELLA; Database=bdSalao3; Integrated Security=SSPI");  
        //public static SqlConnection strConexao = new SqlConnection(@"Server=(local); Database=bdSalao3; Integrated Security=SSPI");
        // public static SqlConnection strConexao = new SqlConnection(@"Server=JESSICA-PC\SQLEXPRESS; Database=bdSalao2; Integrated Security=SSPI");
        public static SqlConnection strConexao = new SqlConnection(@"Server=DESKTOP-IAKCRTT; Database=bdSalao2; Integrated Security=SSPI");
        public static String conectar()
        {
            try
            {
                strConexao.Open();
                return ("Conexão realizada com sucesso");
            }
            catch (SqlException e)

            {
                return (e.ToString());
            }
        }
        public static String desconectar()
        {
            try
            {
                strConexao.Close();
                return ("Conexão encerrada com sucesso");
            }
            catch (SqlException e)
            {
                return (e.ToString());
            }
        }
    }
}