using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tocaLivrosModel
{
   public class Produto
    {
        /// <summary>
        /// Autor:Renan
        /// Data:10/12/2016
        /// Descrição: Objeto Cliente responsavel por fazer o pedido, Cliente pode ser tanto pessoa física ou jurídica
        /// </summary>
        /// <param name="nome">Nome Produto</param>
        /// <param name="qtdProduto">Quantidade Produto</param>
        /// <param name="vlrProduto">Valor Unitário do Produto </param>
        /// 
        private int id;
        private string nome;
        private int qtdProduto;
        private double vlrProduto;

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

        public string Nome {
            get { return this.nome; }
            set { this.nome = value; }
        }
        public int QtdProduto {
            get { return this.qtdProduto; }
            set { this.qtdProduto =value; }
        }
        public double VlrProduto {
            get { return this.vlrProduto; }
            set { this.vlrProduto = value; }
        }

    }
}
