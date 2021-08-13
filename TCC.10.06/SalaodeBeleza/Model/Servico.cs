using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaodeBeleza.Model
{
    class Servico
    {
        private int codServico;

        public int CodServico
        {
            get { return codServico; }
            set { codServico = value; }
        }
        private String descServico;

        public String DescServico
        {
            get { return descServico; }
            set { descServico = value; }
        }
        private decimal valor;

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }
    }
}
