using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaodeBeleza.Model;
using System.Data.SqlClient;
using System.Data;

namespace SalaodeBeleza.Dao
{
    class DaoServico
    {
        public void cadastrar(Servico servico)
        {
            SqlCommand cmd = new SqlCommand
                    (null, Conexao.strConexao);
            cmd.CommandText =
                "INSERT INTO tbServico(descServico, valor) " +
                "VALUES (@nome,@valor)";

            cmd.Parameters.AddWithValue("@nome", servico.DescServico);
            cmd.Parameters.AddWithValue("@valor", servico.Valor);
            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            //SqlCommand cmd = new SqlCommand("INSERT INTO tbPet(nomePet, idadePet, codCliente, codRaca, fotoPet) VALUES ('" + pet.Nomepet+ "', '" + pet.Idadepet+ "', '" + pet.Codcliente+ "', '" + pet.Codraca+ "','" + pet.Fotopet+ "')", Conexao.strConexao);
            //    Conexao.conectar();

            cmd.ExecuteNonQuery();
            Conexao.desconectar();
        }
        public DataTable preencherGrid()
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codServico, descServico as 'Serviço', valor as 'Valor' " +
                "FROM tbServico", Conexao.strConexao);
            Conexao.conectar();
            SqlDataAdapter dafab = new SqlDataAdapter(cmd);
            DataTable dtfab = new DataTable();
            dafab.Fill(dtfab);
            Conexao.desconectar();
            return dtfab;
        }
        public SqlDataReader listarServicos()
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codServico, descServico as 'Serviço', valor as 'Valor' " +
                "FROM tbServico", Conexao.strConexao);
            Conexao.conectar();
            SqlDataReader clientes = cmd.ExecuteReader();
            // Conexao.desconectar();
            return clientes;
        }
        public SqlDataReader listarServicosIndividual(int codservico)
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codServico, descServico as 'Serviço', valor as 'Valor' " +
                "FROM tbServico WHERE codServico = "+codservico, Conexao.strConexao);
            Conexao.conectar();
            SqlDataReader clientes = cmd.ExecuteReader();
            // Conexao.desconectar();
            return clientes;
        }

        public DataTable preencherGrid(String valorPesquisa)
        {

            SqlCommand cmd = new SqlCommand
                ("SELECT codServico, descServico as 'Serviço', valor as 'Valor' " +
                "FROM tbServico WHERE descServico LIKE '" + valorPesquisa + "%'", Conexao.strConexao);
            Conexao.conectar();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable resultado = new DataTable();
            da.Fill(resultado);
            Conexao.desconectar();
            return resultado;
        }
        public DataTable preencherList()
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codServico, descServico as 'Serviços' FROM tbServico", Conexao.strConexao);

            Conexao.conectar();
            SqlDataAdapter dafab = new SqlDataAdapter(cmd);
            DataTable dtfab = new DataTable();
            dafab.Fill(dtfab);
            Conexao.desconectar();
            return dtfab;


        }
        public DataTable preencherList(String valorPesquisa)
        {

            SqlCommand cmd = new SqlCommand
                ("SELECT codServico, descServico as 'Serviço' FROM tbServico WHERE descServico LIKE '" + valorPesquisa + "%'", Conexao.strConexao);

            Conexao.conectar();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable resultado = new DataTable();
            da.Fill(resultado);
            Conexao.desconectar();
            return resultado;
        }
        public String excluirCandidato(int codCandidato)
        {
            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "DELETE FROM tbServico WHERE codServico = '" + codCandidato + "'";
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
                return ("Dados excluídos com sucesso.");
            else
                return ("Erro na exclusão dos dados!");
        }

        public String alterar(Servico servico)
        {

            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "UPDATE tbServico SET descServico = @desc, valor = @valor WHERE codServico = @cod";

            cmd.Parameters.AddWithValue("@cod", servico.CodServico);
            cmd.Parameters.AddWithValue("@desc", servico.DescServico);
            cmd.Parameters.AddWithValue("@valor", servico.Valor);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            int qtd = cmd.ExecuteNonQuery();

            Conexao.desconectar();
            if (qtd == 1)
                return ("Dados atualizados com sucesso.");
            else
                return ("Erro na atualização dos dados!");
        }
    }
}
