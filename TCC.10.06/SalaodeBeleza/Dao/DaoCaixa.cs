using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SalaodeBeleza.Model;
using System.Data;

namespace SalaodeBeleza.Dao
{
    class DaoCaixa
    {
        public void cadastrar(Caixa c)
        {
            SqlCommand cmd = new SqlCommand
                (null, Conexao.strConexao);
            cmd.CommandText =
                "UPDATE tbCaixa SET valorInicial = (@valor) where codCaixa = 3 "
                ;

            cmd.Parameters.AddWithValue("@valor", c.ValorInicial);

            cmd.CommandType = CommandType.Text;
            Conexao.conectar();

            //SqlParameter nome = new SqlParameter
            //    ("@nome", SqlDbType.Text, 50);
            //nome.Value = f.NomeFabricante;
            //cmd.Parameters.Add(nome);
            //Conexao.conectar();
            //cmd.Prepare();

            cmd.ExecuteNonQuery();
            Conexao.desconectar();
        }

    }

}
