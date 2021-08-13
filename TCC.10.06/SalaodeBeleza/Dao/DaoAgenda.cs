using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SalaodeBeleza.Model;
using System.Data;
using System.Windows;

namespace SalaodeBeleza.Dao
{
    class DaoAgenda
    {

        public void cadastrar(Agenda agenda)
        {
            /////////////////Verificar//////////////////////////
            SqlCommand cmd4 = new SqlCommand
               ("SELECT codProfissional FROM tbProfissional WHERE nomeProfissional LIKE '" + agenda.Codprofissional + "%'", Conexao.strConexao);
            Conexao.conectar();
            int qtde4 = Convert.ToInt32(cmd4.ExecuteScalar());

            SqlCommand cmd00 = new SqlCommand
                ("SELECT codAgenda FROM tbAgenda WHERE codProfissional = @codprof and dataHora = @data", Conexao.strConexao);

            cmd00.Parameters.AddWithValue("@codprof", qtde4);
            cmd00.Parameters.AddWithValue("@data", agenda.Data);


            var nomes = cmd00.ExecuteReader();

            /////////////////////////////////////

            if (nomes.Read())
            {
                MessageBox.Show("Este horário está indisponível");

                Conexao.desconectar();
            }

            else
            {

                nomes.Close();
                SqlCommand cmd0 = new SqlCommand
                    ("SELECT codCliente FROM tbCliente WHERE nomeCliente LIKE '" + agenda.Codcliente + "%'", Conexao.strConexao);

                int qtde0 = Convert.ToInt32(cmd0.ExecuteScalar());

                SqlCommand cmd1 = new SqlCommand
                    ("SELECT codServico FROM tbServico WHERE descServico LIKE '" + agenda.Codservico + "%'", Conexao.strConexao);

                int qtde1 = Convert.ToInt32(cmd1.ExecuteScalar());

                SqlCommand cmd2 = new SqlCommand
                   ("SELECT codStatusAgenda FROM tbStatusAgenda WHERE descStatusAgenda LIKE '" + agenda.Codstatus + "%'", Conexao.strConexao);

                int qtde2 = Convert.ToInt32(cmd2.ExecuteScalar());

                //SqlCommand cmd3 = new SqlCommand
                //   ("SELECT codUsuario FROM tbUsuario WHERE descUsuario LIKE '" + agenda.Codusuario + "%'", Conexao.strConexao);

                //int qtde3 = Convert.ToInt32(cmd3.ExecuteScalar());



                SqlCommand cmd = new SqlCommand
                    (null, Conexao.strConexao);
                cmd.CommandText =
                    "INSERT INTO tbAgenda(codCliente, codServico, dataHora, codProfissional)" +
                    "VALUES (@cliente,@servico,@data, @prof)";

                cmd.Parameters.AddWithValue("@data", agenda.Data);
                cmd.Parameters.AddWithValue("@cliente", qtde0);
                cmd.Parameters.AddWithValue("@servico", qtde1);
                cmd.Parameters.AddWithValue("@prof", qtde4);
                //cmd.Parameters.AddWithValue("@status", agenda.Codstatus);
                //cmd.Parameters.AddWithValue("@usuario", agenda.Codusuario);

                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();
                cmd00.ExecuteNonQuery();
                MessageBox.Show("Cadastrado com Sucesso");
                Conexao.desconectar();

            }

        }

        public DataTable preencherGrid()
        {


            SqlCommand cmd = new SqlCommand
                ("SELECT codAgenda, dataHora as 'Data e Hora', nomeCliente as 'Cliente', nomeProfissional as 'Profissional', descServico as 'Serviço' FROM tbAgenda " +
                    "INNER JOIN tbCliente " +
                        "on tbAgenda.codCliente = tbCliente.codCliente " +
                            "INNER JOIN tbProfissional " +
                                "on tbAgenda.codProfissional = tbProfissional.codProfissional " +
                                    "INNER JOIN tbServico " +
                                        "on tbAgenda.codServico = tbServico.codServico ", Conexao.strConexao);
            Conexao.conectar();
            SqlDataAdapter dafab = new SqlDataAdapter(cmd);
            DataTable dtfab = new DataTable();
            dafab.Fill(dtfab);

            Conexao.desconectar();
            return dtfab;
        }

        public String[] carregarCbServico()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(codServico) FROM tbServico", Conexao.strConexao);
            Conexao.conectar();

            int qtde = Convert.ToInt32(cmd.ExecuteScalar());

            String[] listaPartido = new String[qtde];

            SqlCommand cmd2 = new SqlCommand("SELECT descServico FROM tbServico", Conexao.strConexao);

            var nomes = cmd2.ExecuteReader();

            int i = 0;
            while (nomes.Read())
            {
                listaPartido[i] = nomes["descServico"].ToString();
                i++;
                //listaPartido.Add();
            }

            Conexao.desconectar();
            return listaPartido;
        }

        public String[] carregarCbCliente()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(codCliente) FROM tbCliente", Conexao.strConexao);
            Conexao.conectar();

            int qtde = Convert.ToInt32(cmd.ExecuteScalar());

            String[] listaPartido = new String[qtde];

            SqlCommand cmd2 = new SqlCommand("SELECT nomeCliente FROM tbCliente", Conexao.strConexao);

            var nomes = cmd2.ExecuteReader();

            int i = 0;
            while (nomes.Read())
            {
                listaPartido[i] = nomes["nomeCliente"].ToString();
                i++;
                //listaPartido.Add();
            }

            Conexao.desconectar();
            return listaPartido;
        }

        public String[] carregarCbProf()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(codProfissional) FROM tbProfissional", Conexao.strConexao);
            Conexao.conectar();

            int qtde = Convert.ToInt32(cmd.ExecuteScalar());

            String[] lista = new String[qtde];

            SqlCommand cmd2 = new SqlCommand("SELECT nomeProfissional FROM tbProfissional", Conexao.strConexao);

            var nomes = cmd2.ExecuteReader();

            int i = 0;
            while (nomes.Read())
            {
                lista[i] = nomes["nomeProfissional"].ToString();
                i++;
                //listaPartido.Add();
            }

            Conexao.desconectar();
            return lista;
        }

        public DataTable preencherGrid(String valorPesquisa)
        {

            SqlCommand cmd = new SqlCommand
                ("SELECT codAgenda, dataHora as 'Data e Hora', nomeCliente as 'Cliente', nomeProfissional as 'Profissional', descServico as 'Serviço' FROM tbAgenda " +
                    "INNER JOIN tbCliente " +
                        "on tbAgenda.codCliente = tbCliente.codCliente " +
                            "INNER JOIN tbProfissional " +
                                "on tbAgenda.codProfissional = tbProfissional.codProfissional " +
                                    "INNER JOIN tbServico " +
                                        "on tbAgenda.codServico = tbServico.codServico " +
                                            "WHERE nomeProfissional LIKE '" + valorPesquisa + "%'", Conexao.strConexao);
            Conexao.conectar();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable resultado = new DataTable();
            da.Fill(resultado);
            Conexao.desconectar();
            return resultado;
        }


        public String excluir(int cod)
        {
            SqlCommand cmd = new SqlCommand(null, Conexao.strConexao);
            cmd.CommandText =
                "DELETE FROM tbAgenda WHERE codAgenda = '" + cod + "'";

            Conexao.conectar();

            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
                return ("Dados excluídos com sucesso.");
            else
                return ("Erro na exclusão dos dados!");
        }
        public SqlDataReader listarServicos()
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codAgenda, dataHora as 'Data e Hora', nomeProfissional, nomeCliente, descServico as 'Serviço' FROM tbAgenda " +
                   "INNER JOIN tbProfissional " +
                        "on tbAgenda.codProfissional = tbProfissional.codProfissional " +
                             "INNER JOIN tbCliente " +
                                    "on tbAgenda.codCliente = tbCliente.codCliente " +
                                        "INNER JOIN tbServico " +
                                                    "on tbAgenda.codServico = tbServico.codServico " +
                                                        "order by dataHora", Conexao.strConexao);
            Conexao.conectar();
            SqlDataReader clientes = cmd.ExecuteReader();
            // Conexao.desconectar();
            return clientes;
        }

        public SqlDataReader listarServicos(String servicoprof)
        {
            SqlCommand cmd = new SqlCommand
                ("SELECT codAgenda, dataHora as 'Data e Hora', nomeProfissional, nomeCliente, descServico as 'Serviço' FROM tbAgenda " +
                     "INNER JOIN tbCliente " +
                       " on tbAgenda.codCliente = tbCliente.codCliente " +
                           "INNER JOIN tbProfissional " +
                                "on tbAgenda.codProfissional = tbProfissional.codProfissional " +
                                    "INNER JOIN tbServico " +
                                        "on tbAgenda.codServico = tbServico.codServico WHERE nomeProfissional LIKE '" + servicoprof + "% order by dataHora'", Conexao.strConexao);
            Conexao.conectar();
            SqlDataReader clientes = cmd.ExecuteReader();
            // Conexao.desconectar();
            return clientes;
        }

        public DataSet listarData(DateTime data)
        {
            string data2 = Convert.ToString(data);
            string dia, mes;
            dia = data2.Substring(0,2);
            mes = data2.Substring(3, 2);

            SqlCommand cmd = new SqlCommand
                ("SELECT codAgenda, dataHora as 'Data e Hora', nomeProfissional as 'Profissional', nomeCliente as 'Cliente', descServico as 'Serviço' FROM tbAgenda " +
                     "INNER JOIN tbCliente " +
                       " on tbAgenda.codCliente = tbCliente.codCliente " +
                           "INNER JOIN tbProfissional " +
                                "on tbAgenda.codProfissional = tbProfissional.codProfissional " +
                                    "INNER JOIN tbServico " +
                                        "on tbAgenda.codServico = tbServico.codServico WHERE DAY(dataHora) = " + dia + " and MONTH(datahora) = "+ mes +" order by dataHora", Conexao.strConexao);

            Conexao.conectar();
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            // DataSet clientes = cmd.ExecuteReader();
            // Conexao.desconectar();
            Conexao.desconectar();
            return ds;
        }
    }
}