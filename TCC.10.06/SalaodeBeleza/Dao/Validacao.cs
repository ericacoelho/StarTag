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
    class Validacao
    {
        public bool cpfRep(string cpf)
        {
            try
            {
                SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
                cmd.CommandText =
                    "Select codCliente from tbCliente where cpfCliente = '" + cpf + "'";
                Conexao.conectar();

                SqlDataReader adapter = cmd.ExecuteReader();

                while (adapter.Read())
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro");
                return false;
            }
            finally
            {
                Conexao.desconectar();
            }

        }

        public bool cpfRepP(string cpf)
        {
            try
            {
                SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
                cmd.CommandText =
                    "Select codProfissional from tbProfissional where cpfProfissional = '" + cpf + "'";
                Conexao.conectar();

                SqlDataReader adapter = cmd.ExecuteReader();

                while (adapter.Read())
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro");
                return false;
            }
            finally
            {
                Conexao.desconectar();
            }

        }



        public bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            int soma;
            string digito;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);

        }
    }
}