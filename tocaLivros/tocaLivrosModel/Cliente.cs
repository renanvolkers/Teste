using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tocaLivrosModel
{
    /// <summary>
    /// Objeto Cliente responsavel por fazer o pedido, Cliente pode ser tanto pessoa física ou jurídica
    /// </summary>
    /// <param name="nome">Nome da pessoa física ou razão social da pessoa jurídica</param>
    /// <param name="numeroDocumento">CPF pessoa física ou CNPJ pessoa jurídica </param>
    /// <param name="numeroRegistro">RG(Registro Geral) pessoa física ou IE(Inscrição Estadual) pessoa jurídica </param>
    /// <param name="numeroRegistro">RG(Registro Geral) pessoa física ou IE(Inscrição Estadual) pessoa jurídica </param>
    /// <param name="contato">Objeto com informações  do contato </param>
    public class Cliente
    {
        private int id;
        private string nome;
        private int numeroDocumento;
        private int numeroRegistro;
        private Contato contato;

        
        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public int NumeroDocumento
        {
            get
            {
                return numeroDocumento;
            }

            set
            {
                numeroDocumento = value;
            }
        }

        public int NumeroRegistro
        {
            get
            {
                return numeroRegistro;
            }

            set
            {
                numeroRegistro = value;
            }
        }

        public Contato Contato
        {
            get
            {
                return contato ;
            }

            set
            {
                contato = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}
