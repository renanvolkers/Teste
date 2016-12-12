using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tocaLivrosModel
{
   public class Pedido
    {
        /// <summary>
        /// Autor:Renan
        /// 
        /// Descrição: Objeto Cliente responsavel por fazer o pedido, Cliente pode ser tanto pessoa física ou jurídica
        /// </summary>
        /// <param name="Cliente">Objeto Produto</param>
        /// <param name="Produtos">Lista de Objetos de produtos</param>
        /// 
        private int id;
        private Cliente cliente;
        private List<Produto> itens;

        public Pedido()
        {
            this.cliente = new Cliente();
            this.Itens = new List<Produto>();
        }

        public Cliente Cliente
        {
            get
            {
                return this.cliente;
            }

            set
            {
                cliente = value;
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

        public List<Produto> Itens
        {
            get
            {
                return itens;
            }

            set
            {
                itens = value;
            }
        }
    }
}
