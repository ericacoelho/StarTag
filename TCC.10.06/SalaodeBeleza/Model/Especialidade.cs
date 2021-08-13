using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaodeBeleza.Model
{
    class Especialidade
    {
        private int codespecialidade;

        public int Codespecialidade
        {
            get { return codespecialidade; }
            set { codespecialidade = value; }
        }
        private String descricao;

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
