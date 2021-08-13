using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaodeBeleza.Model
{
    class Agenda
    {
        private String codprofissional;

        public String Codprofissional
        {
            get { return codprofissional; }
            set { codprofissional = value; }
        }

        private int codagenda;

        public int Codagenda
        {
            get { return codagenda; }
            set { codagenda = value; }
        }
        private String codcliente;

        public String Codcliente
        {
            get { return codcliente; }
            set { codcliente = value; }
        }
        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        private String codservico;

        public String Codservico
        {
            get { return codservico; }
            set { codservico = value; }
        }
        private int codusuario;

        public int Codusuario
        {
            get { return codusuario; }
            set { codusuario = value; }
        }

        private int codstatus;

        public int Codstatus
        {
            get { return codstatus; }
            set { codstatus = value; }
        }
    }
}
