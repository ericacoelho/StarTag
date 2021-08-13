using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaodeBeleza.Model
{
    class Usuario
    {
        private String nome;
        private String login;

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
         public String Login
        {
            get { return login; }
            set { login = value; }
        }
         private String senha;

         public String Senha
         {
             get { return senha; }
             set { senha = value; }
         }
    }
}
