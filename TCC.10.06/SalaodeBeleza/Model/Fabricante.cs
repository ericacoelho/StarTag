using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaodeBeleza.Model
{
    class Fabricante
    {
        private int codFabricante;
        private string nomeFabricante;
        private string cnpjFabricante;

        public string CnpjFabricante
        {
            get { return cnpjFabricante; }
            set { cnpjFabricante = value; }
        }

        public int CodFabricante
        {
            get
            {
                return codFabricante;
            }

            set
            {
                codFabricante = value;
            }
        }

        public string NomeFabricante
        {
            get
            {
                return nomeFabricante;
            }

            set
            {
                nomeFabricante = value;
            }
        }
    }
}
