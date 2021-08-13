using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaodeBeleza.Model;
using System.Data.SqlClient;
using System.Data;

namespace SalaodeBeleza.Dao
{
    class DaoUsuario
    {
        public void cadastrar(Usuario u)
        {
            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "INSERT INTO tbUsuario(nomeUsuario, loginUsuario, senhaUsuario) " +
                "VALUES (@nome,@login,@senha)";

            cmd.Parameters.AddWithValue ("@nome", u.Nome);
            cmd.Parameters.AddWithValue("@login", u.Login);
            cmd.Parameters.AddWithValue("@senha", u.Senha);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            //SqlParameter nome = new SqlParameter
            //    ("@nome", SqlDbType.Text, 50);
            //nome.Value = f.NomeFabricante;
            //cmd.Parameters.Add(nome);
            //Conexao.conectar();
            //cmd.Prepare();

            cmd.ExecuteNonQuery();
            Conexao.desconectar();
        }

        public bool verificar(Usuario u)
        {
            bool result = false;
            SqlCommand cmd = new SqlCommand (null, Conexao.strConexao);
            cmd.CommandText = "SELECT * FROM tbUsuario WHERE loginUsuario = @login AND senhaUsuario = @senha";

            cmd.Parameters.AddWithValue("@login", u.Login);
            cmd.Parameters.AddWithValue("@senha", u.Senha);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            SqlDataReader dados = cmd.ExecuteReader();
            result = dados.HasRows;
            Conexao.desconectar();
            
            return result;
            

            //SqlParameter nome = new SqlParameter
            //    ("@nome", SqlDbType.Text, 50);
            //nome.Value = f.NomeFabricante;
            //cmd.Parameters.Add(nome);
            //Conexao.conectar();
            //cmd.Prepare();

            //var resultado = cmd.ExecuteScalar();
            //Conexao.desconectar();

            //if (resultado is DBNull) // Se não retornar nada é porque o usuário é inválido
            //{
            //    return false; 
            //}
            //else
            //{
            //    return true; 
            //}
        }

        //bool VerificaLogin()
        //{
        //    bool result = false;
        //    SqlCommand cmd = new SqlCommand
        //        (null, Conexao.strConexao);
        //    cmd.CommandText = "SELECT * FROM tbUsuario WHERE loginUsuario = @login AND senhaUsuario = @senha";
        //    string StringDeConexao = @Data Source=localhost;Initial Catalog=tempdb;User Id=sa;Password=minhasenha;”;
            
        //    using (SqlConnection cn = new SqlConnection())
        //    {
        //        cn.ConnectionString = StringDeConexao;

        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand(“select * from login where usuario = ‘” + txtUsuario.Text + “‘ and senha = ‘” + txtSenha.Text + “‘;”, cn);
        //            cn.Open();
        //            SqlDataReader dados = cmd.ExecuteReader();
        //            result = dados.HasRows;

        //        }
        //        catch (SqlException e)
        //        {
        //            throw new Exception(e.Message);
        //        }
        //        finally
        //        {
        //            cn.Close();
        //        }
        //        return result;
        //    }

        //}

    }
}
