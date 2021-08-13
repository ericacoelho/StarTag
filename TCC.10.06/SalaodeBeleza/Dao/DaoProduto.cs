using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaodeBeleza.Model;
using System.Data.SqlClient;
using System.Data;

namespace SalaodeBeleza.Dao
{
    class DaoProduto
    {
        public void cadastrar(Produto produtos)
        {
            Conexao.conectar();
            try
            {
                SqlCommand cmd = new SqlCommand
               (null, Conexao.strConexao);
                cmd.CommandText =
                    "INSERT INTO tbProduto(descProduto, quantEstoque) " +
                    "VALUES (@descProduto,@quantEstoque)";

                cmd.Parameters.AddWithValue("@descProduto", produtos.DescProduto);
                cmd.Parameters.AddWithValue("@quantEstoque", produtos.QuantEstoque);
                cmd.CommandType = CommandType.Text;


                cmd.ExecuteNonQuery();
                //return true;
            }
            catch
            {
            }
            finally
            {
                Conexao.desconectar();
            }
            //return false;
        }


        public DataSet PreencherComboBox()
        {
            Conexao.conectar();

            SqlCommand comando = new SqlCommand("SELECT codProduto, descProduto from tbProduto", Conexao.strConexao);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);
            Conexao.desconectar();
            return ds;
        }

        public Boolean saidaProduto(Produto produto)
        {
            Conexao.conectar();
            try
            {
                SqlCommand comando = new SqlCommand("UPDATE tbProduto SET quantEstoque = quantEstoque - @quantEstoque WHERE codProduto = @codProduto", Conexao.strConexao);
                comando.Parameters.AddWithValue("@quantEstoque", produto.QuantEstoque);
                comando.Parameters.AddWithValue("@codProduto", produto.CodProduto);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
            }
            finally
            {
                Conexao.desconectar();
            }

            return false;
        }

        public Boolean entradaProduto(Produto produto)
        {
            Conexao.conectar();
            try
            {
                SqlCommand comando = new SqlCommand("UPDATE tbProduto SET quantEstoque = quantEstoque + @quantEstoque WHERE codProduto = @codProduto", Conexao.strConexao);
                comando.Parameters.AddWithValue("@quantEstoque", produto.QuantEstoque);
                comando.Parameters.AddWithValue("@codProduto", produto.CodProduto);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
            }
            finally
            {
                Conexao.desconectar();
            }

            return false;
        }

    }
}

