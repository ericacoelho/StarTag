using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalaodeBeleza.Model;
using System.Data.SqlClient;
using System.Data;

namespace SalaodeBeleza.Dao
{
    class DaoEspecialidade
    {
        public void cadastrar(Especialidade es)
        {

            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "INSERT INTO tbEspecialidade(descEspecialidade)" +
                "VALUES (@desc)";

            cmd.Parameters.AddWithValue("@desc", es.Descricao);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();
            cmd.ExecuteNonQuery();
            Conexao.desconectar();

        }

        public String excluir(int cod)
        {
            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "DELETE FROM tbEspecialidade WHERE codEspecialidade = '" + cod + "'";
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
                return ("Dados excluídos com sucesso.");
            else
                return ("Erro na exclusão dos dados!");
        }

        public String alterar(Especialidade es)
        {

            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "UPDATE tbEspecialidade SET descEspecialidade = @desc WHERE codEspecialidade = @cod";

            cmd.Parameters.AddWithValue("@cod", es.Codespecialidade);
            cmd.Parameters.AddWithValue("@desc", es.Descricao);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            int qtd = cmd.ExecuteNonQuery();

            Conexao.desconectar();
            if (qtd == 1)
                return ("Dados atualizados com sucesso.");
            else
                return ("Erro na atualização dos dados!");
        }

        public List<Especialidade> listar()
        {
            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "SELECT descEspecialidade FROM tbEspecialidade";

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();
            var reader = cmd.ExecuteReader();

            List<Especialidade> es = new List<Especialidade>();
            while (reader.Read())
            {
               
                //aaaaaaaaaaaaaaaah
            }

            return es;

        }
    }
}
