using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaodeBeleza.Model
{
    class Comanda1
    {
        int codComanda;

        public int CodComanda
        {
            get { return codComanda; }
            set { codComanda = value; }
        }
        DateTime dataComanda;

        public DateTime DataComanda
        {
            get { return dataComanda; }
            set { dataComanda = value; }
        }
        double valorComanda;

        public double ValorComanda
        {
            get { return valorComanda; }
            set { valorComanda = value; }
        }
        String codCliente;

        public String CodCliente
        {
            get { return codCliente; }
            set { codCliente = value; }
        }

        int codcomandaservico;

        public int Codcomandaservico
        {
            get { return codcomandaservico; }
            set { codcomandaservico = value; }
        }
        String codservico;

        public String Codservico
        {
            get { return codservico; }
            set { codservico = value; }
        }
        String codcomandaS;

        public String CodcomandaS
        {
            get { return codcomandaS; }
            set { codcomandaS = value; }
        }
        int quantidadeS;

        public int QuantidadeS
        {
            get { return quantidadeS; }
            set { quantidadeS = value; }
        }

        int codcomandaproduto;

        public int Codcomandaproduto
        {
            get { return codcomandaproduto; }
            set { codcomandaproduto = value; }
        }
        String codproduto;

        public String Codproduto
        {
            get { return codproduto; }
            set { codproduto = value; }
        }
        String codcomandaP;

        public String CodcomandaP
        {
            get { return codcomandaP; }
            set { codcomandaP = value; }
        }
        int quantidadeP;

        public int QuantidadeP
        {
            get { return quantidadeP; }
            set { quantidadeP = value; }
        }
    }
}
