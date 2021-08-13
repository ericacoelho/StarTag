using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaodeBeleza.Model;
using System.Data.SqlClient;
using System.Data;

namespace SalaodeBeleza.Dao
{
    class DaoFabricante
    {
        public void cadastrar(Fabricante f)
        {
            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "INSERT INTO tbFabricante(descFabricante, cnpjFabricante) " +
                "VALUES (@nome,@cnpj)";

            cmd.Parameters.AddWithValue("@nome", f.NomeFabricante);
            cmd.Parameters.AddWithValue("@cnpj", f.CnpjFabricante);
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

        public DataTable preencherGrid()
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codFabricante, descFabricante as 'Fabricante', cnpjFabricante as 'CNPJ/CPF' "+
                "FROM tbFabricante", Conexao.strConexao);
            Conexao.conectar();
            SqlDataAdapter dafab = new SqlDataAdapter(cmd);
            DataTable dtfab = new DataTable();
            dafab.Fill(dtfab);
            Conexao.desconectar();
            return dtfab;
        }
        public DataTable preencherGrid(String valorPesquisa)
        {

            SqlCommand cmd = new SqlCommand
                ("SELECT codFabricante, descFabricante as 'Fabricante', cnpjFabricante as 'CNPJ/CPF' " +
                "FROM tbFabricante WHERE descFabricante LIKE '" + valorPesquisa + "%'", Conexao.strConexao);
            Conexao.conectar();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable resultado = new DataTable();
            da.Fill(resultado);
            Conexao.desconectar();
            return resultado;
        }
        public String alterar(Fabricante fabricante)
        {

            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "UPDATE tbFabricante SET descFabricante = @desc, cnpjFabricante =@cnpj WHERE codFabricante = @cod";

            cmd.Parameters.AddWithValue("@cod", fabricante.CodFabricante);
            cmd.Parameters.AddWithValue("@desc", fabricante.NomeFabricante);
            cmd.Parameters.AddWithValue("@cnpj", fabricante.CnpjFabricante);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            int qtd = cmd.ExecuteNonQuery();

            Conexao.desconectar();
            if (qtd == 1)
                return ("Dados atualizados com sucesso.");
            else
                return ("Erro na atualização dos dados!");
        }

        public String excluirCandidato(int codCandidato)
        {
            SqlCommand cmd2 = new SqlCommand(null, Conexao.strConexao);
            cmd2.CommandText =
                "DELETE FROM tbProduto WHERE codFabricante = '" + codCandidato + "'";

            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "DELETE FROM tbFabricante WHERE codFabricante = '" + codCandidato + "'";
            Conexao.conectar();

            int qtd2 = cmd2.ExecuteNonQuery();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
                return ("Dados excluídos com sucesso.");
            else
                return ("Erro na exclusão dos dados!");
        }
    }
}

