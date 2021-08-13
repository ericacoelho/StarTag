using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaodeBeleza.Model
{
    class Caixa
    {
        private int codCaixa;
        public int Codcaixa
        {
            get { return codCaixa; }
            set { codCaixa = value; }
        }

        private double valorInicial;
        public double Valorinicial
        {
            get { return valorInicial; }
            set { valorInicial = value; }
        }
        private double valorFinal;
        public double Valorfinal
        {
            get { return valorFinal; }
            set { valorFinal = value; }
        }
        private String descCaixa;
        public String Desccaixa
        {
            get { return descCaixa; }
            set { descCaixa = value; }
        }
        private Boolean statusCaixa;
        public Boolean Statuscaixa
        {
            get { return statusCaixa; }
            set { statusCaixa = value; }
        }
    }
}
