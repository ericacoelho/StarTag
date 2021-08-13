using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaodeBeleza.Model;
using System.Data.SqlClient;
using System.Data;

namespace SalaodeBeleza.Dao
{
    class DaoCliente
    {
        public void cadastrar(Cliente cliente, int numVetor, String[] numTelefone)
        {

            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "INSERT INTO tbCliente(nomeCliente, cpfCliente, ruaCliente, numRuaCliente, compCliente, cepCliente, bairroCliente, cidadeCliente, estadoCliente, email, sexo, dataNasc)" +
                "VALUES (@nome,@cpf,@rua,@num,@comp,@cep,@bairro,@cidade,@estado,@email,@sexo,@dataNasc)";

            cmd.Parameters.AddWithValue("@dataNasc", cliente.Datanasc.ToString("yyyy/MM/dd"));
            cmd.Parameters.AddWithValue ("@nome", cliente.Nomecliente);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpfcliente);
            cmd.Parameters.AddWithValue("@rua", cliente.Ruacliente);
            cmd.Parameters.AddWithValue("@num", cliente.Numrua);
            cmd.Parameters.AddWithValue("@comp", cliente.Compcliente);
            cmd.Parameters.AddWithValue("@cep", cliente.Cepcliente);
            cmd.Parameters.AddWithValue("@bairro", cliente.Bairrocliente);
            cmd.Parameters.AddWithValue("@cidade", cliente.Cidadecliente);
            cmd.Parameters.AddWithValue("@estado", cliente.Estadocliente);
            cmd.Parameters.AddWithValue("@email", cliente.Email);
            cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            int qtd = cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("SELECT MAX (codCliente) from tbCliente", Conexao.strConexao);
            int codCliente = Convert.ToInt32(cmd2.ExecuteScalar());

            int qtd2 = 0;
            for (int i = 0; i < numVetor; i++)
            {

                SqlCommand cmd3 = new SqlCommand
                    (null, Conexao.strConexao);
                cmd3.CommandText =
                    "INSERT INTO tbFoneCliente(numFoneCliente, codCliente)" +
                    "VALUES (@num,@cod)";
                cmd3.Parameters.AddWithValue("@num", numTelefone[i]);
                cmd3.Parameters.AddWithValue("@cod", codCliente);

                qtd2 = cmd3.ExecuteNonQuery();
            }

            Conexao.desconectar();

        }

        public SqlDataReader listarClientes()
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codCliente, nomeCliente as 'Nome', dataNasc as 'Data de Nascimento', sexo as 'Sexo', email as 'E-mail', cpfCliente as 'CPF', cepCliente as 'CEP', ruaCliente as 'Rua', numRuaCliente as 'Número', compCliente as 'Complemento', bairroCliente as 'Bairro', cidadeCliente as 'Cidade', estadoCliente as 'Estado' FROM tbCliente", Conexao.strConexao);
            Conexao.conectar();
            SqlDataReader clientes = cmd.ExecuteReader();
            // Conexao.desconectar();
            return clientes;
        }

        public SqlDataReader listarClientesIndividual(int cliencod)
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codCliente, nomeCliente as 'Nome', dataNasc as 'Data de Nascimento', sexo as 'Sexo', email as 'E-mail', cpfCliente as 'CPF', cepCliente as 'CEP', ruaCliente as 'Rua', numRuaCliente as 'Número', compCliente as 'Complemento', bairroCliente as 'Bairro', cidadeCliente as 'Cidade', estadoCliente as 'Estado' FROM tbCliente WHERE codCliente = " + cliencod, Conexao.strConexao);
            Conexao.conectar();
            SqlDataReader clientes = cmd.ExecuteReader();
            // Conexao.desconectar();
            return clientes;
        }

        public String alterarCandidato(Cliente cliente)
        {

            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "UPDATE tbCliente SET nomeCliente = @nome, dataNasc = @data, " +
                "cpfCliente = @cpf, ruaCliente = @rua, numRuaCliente = @num, compCliente = @comp, cepCliente = @cep, bairroCliente = @bairro, cidadeCliente = @cidade, estadoCliente = @estado, email = @email, sexo = @sexo" +
                " WHERE codCliente = @cod";

            cmd.Parameters.AddWithValue("@cod", cliente.Codcliente);
            cmd.Parameters.AddWithValue("@data", cliente.Datanasc);
            cmd.Parameters.AddWithValue("@nome", cliente.Nomecliente);
            cmd.Parameters.AddWithValue("@cpf", cliente.Cpfcliente);
            cmd.Parameters.AddWithValue("@rua", cliente.Ruacliente);
            cmd.Parameters.AddWithValue("@num", cliente.Numrua);
            cmd.Parameters.AddWithValue("@comp", cliente.Compcliente);
            cmd.Parameters.AddWithValue("@cep", cliente.Cepcliente);
            cmd.Parameters.AddWithValue("@bairro", cliente.Bairrocliente);
            cmd.Parameters.AddWithValue("@cidade", cliente.Cidadecliente);
            cmd.Parameters.AddWithValue("@estado", cliente.Estadocliente);
            cmd.Parameters.AddWithValue("@email", cliente.Email);
            cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            int qtd = cmd.ExecuteNonQuery();

            

            Conexao.desconectar();
            if (qtd == 1)
                return ("Dados atualizados com sucesso.");
            else
                return ("Erro na atualização dos dados!");
        }
        
        public DataTable preencherGrid()
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT tbCliente.codCliente, nomeCliente as 'Nome', dataNasc as 'Data de Nasc.', "+
                "sexo as 'Sexo', email as 'E-mail', cpfCliente as 'CPF', ruaCliente as 'Rua', "+
                "numRuaCliente as 'Número', compCliente as 'Complemento', cepCliente as 'CEP', "+
                "bairroCliente as 'Bairro', cidadeCliente as 'Cidade', estadoCliente as 'Estado' "+
                "FROM tbCliente", Conexao.strConexao);
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
                ("SELECT codCliente, nomeCliente as 'Nome', cpfCliente as 'CPF' FROM tbCliente", Conexao.strConexao);

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
                ("SELECT codCliente, nomeCliente as 'Nome' FROM tbCliente WHERE nomeCliente LIKE '" + valorPesquisa + "%'", Conexao.strConexao);

            Conexao.conectar();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable resultado = new DataTable();
            da.Fill(resultado);
            Conexao.desconectar();
            return resultado;
        }
        public String excluirCandidato(int codCandidato)
        {
            SqlCommand cmd2 = new SqlCommand(null, Conexao.strConexao);
            cmd2.CommandText =
                "DELETE FROM tbFoneCliente WHERE codCliente = '" + codCandidato + "'";

            Conexao.conectar();

            SqlCommand cmd3 = new SqlCommand(null, Conexao.strConexao);
            cmd3.CommandText =
                "DELETE FROM tbFoneCliente WHERE codCliente = '" + codCandidato + "'";

            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "DELETE FROM tbCliente WHERE codCliente = '" + codCandidato + "'";

            int qtd3 = cmd3.ExecuteNonQuery();
            int qtd2 = cmd2.ExecuteNonQuery();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
                return ("Dados excluídos com sucesso.");
            else
                return ("Erro na exclusão dos dados!");
        }

        public DataTable preencherGrid(String valorPesquisa)
        {

            SqlCommand cmd = new SqlCommand
                ("SELECT tbCliente.codCliente, nomeCliente as 'Nome', dataNasc as 'Data de Nasc.', sexo as 'Sexo', email as 'E-mail', cpfCliente as 'CPF', ruaCliente as 'Rua', numRuaCliente as 'Número', compCliente as 'Complemento', cepCliente as 'CEP', bairroCliente as 'Bairro', cidadeCliente as 'Cidade', estadoCliente as 'Estado' FROM tbCliente WHERE nomeCliente LIKE '" + valorPesquisa + "%'", Conexao.strConexao);
            
            Conexao.conectar();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable resultado = new DataTable();
            da.Fill(resultado);
            Conexao.desconectar();
            return resultado;
        }

    }
}