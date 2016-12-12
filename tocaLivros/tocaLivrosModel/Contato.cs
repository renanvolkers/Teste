using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tocaLivrosModel
{
   public class Contato
    {
        private int telefone;
        private string email;
        private int cep;

        public Contato(int _telefone, string _email,int _cep)
        {
            this.telefone = _telefone;
            this.email = _email;
            this.cep = _cep;
        }
        public Contato()
        {
            this.telefone = 0;
            this.email = "";
            this.cep = 0;
        }

        public int Telefone
        {
            get
            {
                return telefone;
            }

            set
            {
                telefone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public int Cep
        {
            get
            {
                return cep;
            }

            set
            {
                cep = value;
            }
        }
    }
}
