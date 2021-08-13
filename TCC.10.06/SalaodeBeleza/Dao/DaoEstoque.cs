using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaodeBeleza.Model;
using System.Data.SqlClient;
using System.Data;

namespace SalaodeBeleza.Dao
{
    class DaoEstoque
    {
        public void cadastrar(Produto produto)
        {
            SqlCommand cmd0 = new SqlCommand
                            ("SELECT codFabricante FROM tbFabricante WHERE descFabricante LIKE '" + produto.CodFabricante + "%'", Conexao.strConexao);
            Conexao.conectar();

            int qtde1 = Convert.ToInt32(cmd0.ExecuteScalar());

            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "INSERT INTO tbProduto(descProduto, valor, codFabricante, quantEstoque)" +
                "VALUES (@nome,@valor,@fab,@quant)";

            cmd.Parameters.AddWithValue("@nome", produto.DescProduto);
            cmd.Parameters.AddWithValue("@quant", produto.QuantEstoque);
            cmd.Parameters.AddWithValue("@valor", produto.Money);
            cmd.Parameters.AddWithValue("@fab", qtde1);

            cmd.CommandType = CommandType.Text;

            //SqlCommand cmd = new SqlCommand("INSERT INTO tbCliente2(nomeCliente, cpfCliente, ruaCliente, numRuaCliente, compCliente, cepCliente, bairroCliente, cidadeCliente)"+
            //        "VALUES ('" + cliente.Nomecliente+ "', '" + cliente.Cpfcliente+ "', '" + cliente.Ruacliente+ "', '" + cliente.Numrua+ "','" + cliente.Compcliente+ "','" + cliente.Cepcliente+ "', '" + cliente.Bairrocliente+ "', '" + cliente.Cidadecliente+ "')", Conexao.strConexao);

            cmd.ExecuteNonQuery();
            Conexao.desconectar();
            
        }
        public DataTable preencherGrid()
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codProduto, descProduto as 'Produto', valor as 'Valor', quantEstoque as 'Quantidade', descFabricante as 'Fabricante' FROM tbProduto "+
                    "inner join tbFabricante " +
                        "on tbFabricante.codFabricante = tbProduto.codFabricante", Conexao.strConexao);
            Conexao.conectar();
            SqlDataAdapter dafab = new SqlDataAdapter(cmd);
            DataTable dtfab = new DataTable();
            dafab.Fill(dtfab);
            Conexao.desconectar();
            return dtfab;

        }
        public DataTable preencherList()
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codProduto, descProduto as 'Produtos' FROM tbProduto", Conexao.strConexao);

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
                ("SELECT codProduto, descProduto as 'Descrição' FROM tbProduto WHERE descProduto LIKE '" + valorPesquisa + "%'", Conexao.strConexao);

            Conexao.conectar();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable resultado = new DataTable();
            da.Fill(resultado);
            Conexao.desconectar();
            return resultado;
        }
        public SqlDataReader listarEstoque()
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codProduto, descProduto, quantEstoque, valor, descFabricante FROM tbProduto " +
                    "inner join tbFabricante " +
                        "on tbFabricante.codFabricante = tbProduto.codFabricante", Conexao.strConexao);
            Conexao.conectar();
            SqlDataReader clientes = cmd.ExecuteReader();
            // Conexao.desconectar();
            return clientes;
        }

        public SqlDataReader listarEstoqueIndividual(int codprod)
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codProduto, descProduto, quantEstoque, valor, descFabricante FROM tbProduto " +
                    "inner join tbFabricante " +
                        "on tbFabricante.codFabricante = tbProduto.codFabricante "+
                        "WHERE codProduto = "+codprod, Conexao.strConexao);
            Conexao.conectar();
            SqlDataReader clientes = cmd.ExecuteReader();
            // Conexao.desconectar();
            return clientes;
        }

        public String excluirCandidato(int codCandidato)
        {
            SqlCommand cmd2 = new SqlCommand(null, Conexao.strConexao);
            cmd2.CommandText =
                "DELETE FROM tbProduto WHERE codProduto = '" + codCandidato + "'";

            Conexao.conectar();

            int qtd = cmd2.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
                return ("Dados excluídos com sucesso.");
            else
                return ("Erro na exclusão dos dados!");
        }

        public String[] carregarCbFabricante()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(codFabricante) FROM tbFabricante", Conexao.strConexao);
            Conexao.conectar();

            int qtde = Convert.ToInt32(cmd.ExecuteScalar());

            String[] listaPartido = new String[qtde];

            SqlCommand cmd2 = new SqlCommand("SELECT descFabricante FROM tbFabricante", Conexao.strConexao);

            var nomes = cmd2.ExecuteReader();

            int i = 0;
            while (nomes.Read())
            {
                listaPartido[i] = nomes["descFabricante"].ToString();
                i++;
                //listaPartido.Add();
            }

            Conexao.desconectar();
            return listaPartido;
        }

        public DataTable preencherGrid(String valorPesquisa)
        {

            SqlCommand cmd = new SqlCommand
                ("SELECT codProduto, descProduto as 'Produto', valor as 'Valor', quantEstoque as 'Quantidade', descFabricante as 'Fabricante' FROM tbProduto "+
                    "inner join tbFabricante "+
		                "on tbFabricante.codFabricante = tbProduto.codFabricante "+
                            "WHERE descProduto LIKE '" + valorPesquisa + "%'", Conexao.strConexao);
            Conexao.conectar();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable resultado = new DataTable();
            da.Fill(resultado);
            Conexao.desconectar();
            return resultado;
        }

        public String alterar(Produto produto)
        {
            SqlCommand cmd0 = new SqlCommand
               ("SELECT codFabricante FROM tbFabricante WHERE descFabricante LIKE '" + produto.CodFabricante + "%'", Conexao.strConexao);
            Conexao.conectar();

            int qtde1 = Convert.ToInt32(cmd0.ExecuteScalar());

            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "UPDATE tbProduto SET descProduto = @desc, valor = @valor, codFabricante = @fab, quantEstoque = @quant WHERE codProduto = @cod";

            cmd.Parameters.AddWithValue("@cod", produto.CodProduto);
            cmd.Parameters.AddWithValue("@desc", produto.DescProduto);
            cmd.Parameters.AddWithValue("@quant", produto.QuantEstoque);
            cmd.Parameters.AddWithValue("@valor", produto.Money);
            cmd.Parameters.AddWithValue("@fab", qtde1);

            cmd.CommandType = CommandType.Text;

            int qtd = cmd.ExecuteNonQuery();

            Conexao.desconectar();
            if (qtd == 1)
                return ("Dados atualizados com sucesso.");
            else
                return ("Erro na atualização dos dados!");
        }

    }
}