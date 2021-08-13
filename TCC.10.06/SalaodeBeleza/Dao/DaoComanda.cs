using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SalaodeBeleza.Model;
using System.Data;

namespace SalaodeBeleza.Dao
{
    class DaoComanda
    {
        public void comanda(Comanda1 comanda)
        {
            SqlCommand cmd1 = new SqlCommand
                ("SELECT codCliente FROM tbCliente WHERE nomeCliente LIKE '" + comanda.CodCliente + "%'", Conexao.strConexao);
            Conexao.conectar();

            int qtde = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "insert into tbComanda(dataComanda,valorTotalComanda,codCliente) " +
                    "VALUES (@data,@valor,@codcliente)";

            cmd.Parameters.AddWithValue("@data", comanda.DataComanda.ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue("@valor", comanda.ValorComanda);
            cmd.Parameters.AddWithValue("@codcliente", qtde);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            cmd.ExecuteNonQuery();
            Conexao.desconectar();

        }

        public void servico(Comanda1 comanda)
        {
            SqlCommand cmd1 = new SqlCommand
                ("SELECT codServico FROM tbComandaServico WHERE descServico LIKE '" + comanda.Codservico + "%'", Conexao.strConexao);
            Conexao.conectar();

            int qtde = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd2 = new SqlCommand
                ("SELECT codComanda FROM tbComanda WHERE descComanda LIKE '" + comanda.CodcomandaS + "%'", Conexao.strConexao);
            Conexao.conectar();

            int qtde2 = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "insert into tbComandaServico(codServico, codComanda, quantidade) " +
                    "VALUES (@servico,@comanda,@quantidade)";

            cmd.Parameters.AddWithValue("@servico", qtde);
            cmd.Parameters.AddWithValue("@comanda", qtde2);
            cmd.Parameters.AddWithValue("@quantidade", comanda.QuantidadeS);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            cmd.ExecuteNonQuery();
            Conexao.desconectar();

        }

        public void produto(Comanda1 comanda)
        {
            SqlCommand cmd1 = new SqlCommand
                ("SELECT codProduto FROM tbComandaProduto WHERE descProduto LIKE '" + comanda.Codproduto + "%'", Conexao.strConexao);
            Conexao.conectar();

            int qtde = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd2 = new SqlCommand
                ("SELECT codComanda FROM tbComanda WHERE descComanda LIKE '" + comanda.CodcomandaP + "%'", Conexao.strConexao);
            Conexao.conectar();

            int qtde2 = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "insert into tbComandaServico(codProduto, codComanda, quantidade) " +
                    "VALUES (@servico,@comanda,@quantidade)";

            cmd.Parameters.AddWithValue("@servico", qtde);
            cmd.Parameters.AddWithValue("@comanda", qtde2);
            cmd.Parameters.AddWithValue("@quantidade", comanda.QuantidadeS);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            cmd.ExecuteNonQuery();
            Conexao.desconectar();

        }

        public Double valorServico(Comanda1 comanda)
        {
            SqlCommand cmd1 = new SqlCommand
                    ("SELECT valor FROM tbServico WHERE descServico LIKE '" + comanda.Codservico + "%'", Conexao.strConexao);
            Conexao.conectar();
            
            int qtde1 = Convert.ToInt32(cmd1.ExecuteScalar());
            comanda.QuantidadeS = qtde1;
            Conexao.desconectar();
            return qtde1;
        }
    
    }
}
