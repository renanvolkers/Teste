using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tocaLivrosBuisness.Repositorio.IURepositorio;
using tocaLivrosDataBase;
using tocaLivrosModel;

namespace tocaLivrosBuisness.Repositorio
{
   public class ItemPedidoRepositorio :IUGeneric<ItemPedido>
    {
        public ItemPedido consultar(ItemPedido _obj)
        {
            try
            {
                return null;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void editar(ItemPedido _obj)
        {
        }

        public void excluir(int _idPedido,int _idProduto)
        {
            try
            {
                ConectionDb conexao = new ConectionDb();
                
                    string sql = "delete  ItemPedido  where idPedido=" + _idPedido + "and idProduto=" + _idProduto ;
                    var dtSet = conexao.returDataSet(sql);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void excluir(int _id)
        {
            try
            {
                ConectionDb conexao = new ConectionDb();

                string sql = "delete  ItemPedidos  where idPedido=" + _id +"and ";
                var dtSet = conexao.returDataSet(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ItemPedido> ExibirTodos()
        {
            try
            {


                ConectionDb conexao = new ConectionDb();

                string sql = "Select * from ItemPedidos where "+"'";
                var dtSet = conexao.returDataSet(sql);

                //return preencheLista(dtSet);
                return null;

            }
            catch (Exception e)
            {

                throw;
            }
        }
        public List<Produto> ExibirTodos(int _idPedido)
        {
            try
            {


                ConectionDb conexao = new ConectionDb();

                string sql = "Select Produto.idProduto,Produto.nme,Produto.vlrProduto,Produto.qtd from Pedidos Inner join ItemPedido on Pedidos.idPedido = ItemPedido.idPedido ";
                sql = sql + "Inner Join Produto on Produto.idProduto = ItemPedido.idProduto where Pedidos.idPedido = " +_idPedido;
                var dtSet = conexao.returDataSet(sql);

                 return preencheLista(dtSet);
               
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void inserir(ItemPedido _obj)
        {
            try
            {


                ConectionDb conexao = new ConectionDb();
            
                    string sql = "insert into ItemPedido (idPedido,idProduto) values (" + "'" + _obj.IdPedido + "'" + "," + "'" + 1 + "'" + ")";
                    var dtSet = conexao.returDataSet(sql);
                



            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void inserir(int _idProduto,int _idPedido)
        {
            try
            {


                ConectionDb conexao = new ConectionDb();
                // ultimoPedido();
                    string sql = "insert into ItemPedido (idPedido,idProduto) values (" + "'" + _idPedido + "'" + "," + "'" + _idProduto + "'" + ")";
                    var dtSet = conexao.returDataSet(sql);



            }


            catch (Exception e)
            {

                 throw ;
            }
        }


        public List<Produto> preencheLista(DataSet _obj)
        {
            try
            {
                var meuData = _obj.Tables[0].AsEnumerable().Select(r => new Produto
                {
                   Id = r.Field<int>("idProduto"),
                   Nome= r.Field<string>("nme"),
                   QtdProduto = r.Field<int>("qtd"),
                   VlrProduto= r.Field<int>("vlrProduto"),
                });
                return meuData.ToList();
                
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
