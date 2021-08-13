using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaodeBeleza.Model;
using System.Data.SqlClient;
using System.Data;

namespace SalaodeBeleza.Dao
{
    class DaoProfissional
    {
        public void cadastrar(Profissional pro)
        {
            SqlCommand cmd1 = new SqlCommand
                ("SELECT codEspecialidade FROM tbEspecialidade WHERE descEspecialidade LIKE '" + pro.Especialidade + "%'", Conexao.strConexao);
            Conexao.conectar();

            int qtde = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "INSERT INTO tbProfissional(nomeProfissional,cpfProfissional,ruaProfissional,numRuaProfissional, compProfissional, cepProfissional, bairroProfissional, cidadeProfissional, estado, sexo, email, dataNasc, codEspecialidade)" +
                "VALUES (@nome,@cpf,@rua,@num,@comp,@cep,@bairro,@cidade,@estado,@sexo,@email,@dataNasc, @cod)";

            cmd.Parameters.AddWithValue("@dataNasc", pro.Datanasc);
            cmd.Parameters.AddWithValue("@nome", pro.Nomecliente);
            cmd.Parameters.AddWithValue("@cpf", pro.Cpfcliente);
            cmd.Parameters.AddWithValue("@rua", pro.Ruacliente);
            cmd.Parameters.AddWithValue("@num", pro.Numrua);
            cmd.Parameters.AddWithValue("@comp", pro.Compcliente);
            cmd.Parameters.AddWithValue("@cep", pro.Cepcliente);
            cmd.Parameters.AddWithValue("@bairro", pro.Bairrocliente);
            cmd.Parameters.AddWithValue("@cidade", pro.Cidadecliente);
            cmd.Parameters.AddWithValue("@estado", pro.Estado);
            cmd.Parameters.AddWithValue("@sexo", pro.Sexo);
            cmd.Parameters.AddWithValue("@email", pro.Email);
            cmd.Parameters.AddWithValue("@cod", qtde);

            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            Conexao.desconectar();

        }

        public String excluirCandidato(int codCandidato)
        {
            SqlCommand cmd2 = new SqlCommand(null, Conexao.strConexao);
            cmd2.CommandText =
                "DELETE FROM tbProfissional WHERE codProfissional = '" + codCandidato + "'";

            Conexao.conectar();

            int qtd = cmd2.ExecuteNonQuery();
            Conexao.desconectar();

            if (qtd > 0)
                return ("Dados excluídos com sucesso.");
            else
                return ("Erro na exclusão dos dados!");
        }

        public String alterar(Profissional pro)
        {

            //SqlCommand cmd1 = new SqlCommand
            //    ("SELECT codEspecialidade FROM tbEspecialidade WHERE descEspecialidade LIKE '" + pro.Especialidade + "%'", Conexao.strConexao);
            Conexao.conectar();

            //int qtde = Convert.ToInt32(cmd1.ExecuteScalar());

            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "UPDATE tbProfissional SET nomeProfissional = @nome, dataNasc = @data, " +
                "cpfProfissional = @cpf, ruaProfissional = @rua, numRuaProfissional = @num, compProfissional = @comp, cepProfissional = @cep, bairroProfissional = @bairro, cidadeProfissional = @cidade, estado = @estado, email = @email, sexo = @sexo" +
                " WHERE codProfissional = @cod";

            cmd.Parameters.AddWithValue("@cod", pro.Codcliente);
            cmd.Parameters.AddWithValue("@data", pro.Datanasc);
            cmd.Parameters.AddWithValue("@nome", pro.Nomecliente);
            cmd.Parameters.AddWithValue("@cpf", pro.Cpfcliente);
            cmd.Parameters.AddWithValue("@rua", pro.Ruacliente);
            cmd.Parameters.AddWithValue("@num", pro.Numrua);
            cmd.Parameters.AddWithValue("@comp", pro.Compcliente);
            cmd.Parameters.AddWithValue("@cep", pro.Cepcliente);
            cmd.Parameters.AddWithValue("@bairro", pro.Bairrocliente);
            cmd.Parameters.AddWithValue("@cidade", pro.Cidadecliente);
            cmd.Parameters.AddWithValue("@estado", pro.Estado);
            cmd.Parameters.AddWithValue("@email", pro.Email);
            cmd.Parameters.AddWithValue("@sexo", pro.Sexo);
            //cmd.Parameters.AddWithValue("@especialidade", qtde);

            cmd.CommandType = CommandType.Text;

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
                ("SELECT codProfissional, nomeProfissional as 'Nome', dataNasc as 'Data de Nasc.', "+
                "sexo as 'Sexo', email as 'E-mail', cpfProfissional as 'CPF', ruaProfissional as 'Rua', "+
                "numRuaProfissional as 'Número', compProfissional as 'Complemento', cepProfissional as 'CEP', " +
                "bairroProfissional as 'Bairro', cidadeProfissional as 'Cidade', estado as 'Estado' " +
                "FROM tbProfissional", Conexao.strConexao);

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
                ("SELECT codProfissional, nomeProfissional as 'Nome', cpfProfissional as 'CPF' FROM tbProfissional", Conexao.strConexao);

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
                ("SELECT codProfissional, nomeProfissional as 'Nome', cpfProfissional as 'CPF' FROM tbProfissional WHERE nomeProfissional LIKE '" + valorPesquisa + "%'", Conexao.strConexao);

            Conexao.conectar();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable resultado = new DataTable();
            da.Fill(resultado);
            Conexao.desconectar();
            return resultado;
        }
        public SqlDataReader listarProfissionais()
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codProfissional, nomeProfissional as 'Nome', dataNasc," +
                "sexo as 'Sexo', email as 'E-mail', cpfProfissional as 'CPF', cepProfissional as 'CEP', ruaProfissional as 'Rua', " +
                "numRuaProfissional as 'Número', compProfissional as 'Complemento', " +
                "bairroProfissional as 'Bairro', cidadeProfissional as 'Cidade', estado as 'Estado' " +
                "FROM tbProfissional", Conexao.strConexao);
            Conexao.conectar();
            SqlDataReader profissional = cmd.ExecuteReader();
            // Conexao.desconectar();
            return profissional;
        }
        public SqlDataReader listarProfissionaisIndividual(int profind)
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codProfissional, nomeProfissional as 'Nome', dataNasc," +
                "sexo as 'Sexo', email as 'E-mail', cpfProfissional as 'CPF', cepProfissional as 'CEP', ruaProfissional as 'Rua', " +
                "numRuaProfissional as 'Número', compProfissional as 'Complemento', " +
                "bairroProfissional as 'Bairro', cidadeProfissional as 'Cidade', estado as 'Estado' " +
                "FROM tbProfissional WHERE codProfissional = " + profind, Conexao.strConexao);
            Conexao.conectar();
            SqlDataReader profissional = cmd.ExecuteReader();
            // Conexao.desconectar();
            return profissional;
        }
        public DataTable preencherGrid(String valorPesquisa)
        {

            SqlCommand cmd = new SqlCommand
                ("SELECT codProfissional, nomeProfissional as 'Nome', dataNasc as 'Data de Nasc.', "+
                "sexo as 'Sexo', email as 'E-mail', cpfProfissional as 'CPF', ruaProfissional as 'Rua', "+
                "numRuaProfissional as 'Número', compProfissional as 'Complemento', cepProfissional as 'CEP', " +
                "bairroProfissional as 'Bairro', cidadeProfissional as 'Cidade', estado as 'Estado' " +
                "FROM tbProfissional WHERE nomeProfissional LIKE '" + valorPesquisa + "%'", Conexao.strConexao);

            Conexao.conectar();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable resultado = new DataTable();
            da.Fill(resultado);
            Conexao.desconectar();
            return resultado;
        }

        public String[] carregarCbEspecialidade()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(codEspecialidade) FROM tbEspecialidade", Conexao.strConexao);
            Conexao.conectar();

            int qtde = Convert.ToInt32(cmd.ExecuteScalar());

            String[] lista = new String[qtde];

            SqlCommand cmd2 = new SqlCommand("SELECT descEspecialidade FROM tbEspecialidade", Conexao.strConexao);

            var nomes = cmd2.ExecuteReader();

            int i = 0;
            while (nomes.Read())
            {
                lista[i] = nomes["descEspecialidade"].ToString();
                i++;
            }

            Conexao.desconectar();
            return lista;
        }
    }
}
