using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaodeBeleza.Model
{
    class Produto
    {
        private String marca;
        public String Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        private String linha;
        public String Linha
        {
            get { return linha; }
            set { linha = value; }
        }

        private int codProduto;

        public int CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }
        private String descProduto;

        public String DescProduto
        {
            get { return descProduto; }
            set { descProduto = value; }
        }
        private double money;

        public double Money
        {
            get { return money; }
            set { money = value; }
        }
        private String codFabricante;

        public String CodFabricante
        {
            get { return codFabricante; }
            set { codFabricante = value; }
        }
        private int quantEstoque;

        public int QuantEstoque
        {
            get { return quantEstoque; }
            set { quantEstoque = value; }
        }
    }
}
