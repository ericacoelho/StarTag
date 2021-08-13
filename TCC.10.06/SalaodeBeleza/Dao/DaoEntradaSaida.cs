using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaodeBeleza.Model;
using System.Data.SqlClient;
using System.Data;

namespace SalaodeBeleza.Dao
{
    class DaoEntradaSaida
    {
        public void entrada(EntradaProduto entrada)
        {
            SqlCommand cmd0 = new SqlCommand
                            ("SELECT codProduto FROM tbProduto WHERE descProduto LIKE '" + entrada.Produto + "%'", Conexao.strConexao);
            Conexao.conectar();

            int qtde1 = Convert.ToInt32(cmd0.ExecuteScalar());

            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "INSERT INTO tbEntradaproduto(dataEntradaProduto, codProduto, qtdeEntradaProduto)" +
                "VALUES (@data,@produto,@qntd)";

            cmd.Parameters.AddWithValue("@data", entrada.Data);
            cmd.Parameters.AddWithValue("@produto", qtde1);
            cmd.Parameters.AddWithValue("@qntd", entrada.Qntd);

            cmd.CommandType = CommandType.Text;

            //SqlCommand cmd = new SqlCommand("INSERT INTO tbCliente2(nomeCliente, cpfCliente, ruaCliente, numRuaCliente, compCliente, cepCliente, bairroCliente, cidadeCliente)"+
            //        "VALUES ('" + cliente.Nomecliente+ "', '" + cliente.Cpfcliente+ "', '" + cliente.Ruacliente+ "', '" + cliente.Numrua+ "','" + cliente.Compcliente+ "','" + cliente.Cepcliente+ "', '" + cliente.Bairrocliente+ "', '" + cliente.Cidadecliente+ "')", Conexao.strConexao);

            cmd.ExecuteNonQuery();
            Conexao.desconectar();

        }

        public void saida(EntradaProduto entrada)
        {
            SqlCommand cmd0 = new SqlCommand
                            ("SELECT codProduto FROM tbProduto WHERE descProduto LIKE '" + entrada.Produto + "%'", Conexao.strConexao);
            Conexao.conectar();

            int qtde1 = Convert.ToInt32(cmd0.ExecuteScalar());

            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "INSERT INTO tbSaidaProduto(dataSaidaProduto, codProduto, qtdeSaidaProduto)" +
                "VALUES (@data,@produto,@qntd)";

            cmd.Parameters.AddWithValue("@data", entrada.Data);
            cmd.Parameters.AddWithValue("@produto", qtde1);
            cmd.Parameters.AddWithValue("@qntd", entrada.Qntd);

            cmd.CommandType = CommandType.Text;

            //SqlCommand cmd = new SqlCommand("INSERT INTO tbCliente2(nomeCliente, cpfCliente, ruaCliente, numRuaCliente, compCliente, cepCliente, bairroCliente, cidadeCliente)"+
            //        "VALUES ('" + cliente.Nomecliente+ "', '" + cliente.Cpfcliente+ "', '" + cliente.Ruacliente+ "', '" + cliente.Numrua+ "','" + cliente.Compcliente+ "','" + cliente.Cepcliente+ "', '" + cliente.Bairrocliente+ "', '" + cliente.Cidadecliente+ "')", Conexao.strConexao);

            //cmd.ExecuteNonQuery();
            Conexao.desconectar();

        }


        public String[] carregarCbProduto()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(codProduto) FROM tbProduto", Conexao.strConexao);
            Conexao.conectar();

            int qtde = Convert.ToInt32(cmd.ExecuteScalar());

            String[] listaPartido = new String[qtde];

            SqlCommand cmd2 = new SqlCommand("SELECT descProduto FROM tbProduto", Conexao.strConexao);

            var nomes = cmd2.ExecuteReader();

            int i = 0;
            while (nomes.Read())
            {
                listaPartido[i] = nomes["descProduto"].ToString();
                i++;
                //listaPartido.Add();
            }

            Conexao.desconectar();
            return listaPartido;

        }
    }
}
