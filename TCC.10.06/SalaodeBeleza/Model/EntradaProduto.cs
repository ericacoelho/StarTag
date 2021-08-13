using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaodeBeleza.Model
{
    class EntradaProduto
    {
        int cod;

        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }
        DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        String produto;

        public String Produto
        {
            get { return produto; }
            set { produto = value; }
        }
        int qntd;

        public int Qntd
        {
            get { return qntd; }
            set { qntd = value; }
        }
    }
}
