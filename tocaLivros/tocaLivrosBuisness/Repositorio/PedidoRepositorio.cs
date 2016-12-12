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
   public class PedidoRepositorio :IUGeneric<Pedido>
    {
        public Pedido consultar(Pedido _obj)
        {
            try
            {


                ConectionDb conexao = new ConectionDb();

                string sql = "Select * from Pedido where idPedido=" + _obj.Id;
                var dtSet = conexao.returDataSet(sql);
                return preencheLista(dtSet).Single();

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void editar(Pedido _obj)
        {
        }

        public void excluir(int _id)
        {
            try
            {
                ConectionDb conexao = new ConectionDb();

                string sql = "delete  Pedidos  where idPedido=" + _id;
                var dtSet = conexao.returDataSet(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Pedido> ExibirTodos()
        {
            try
            {


                ConectionDb conexao = new ConectionDb();

                string sql = "Select * from Pedidos";
                var dtSet = conexao.returDataSet(sql);

                return preencheLista(dtSet);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void inserir(Pedido _obj)
        {
            try
            {
                ItemPedidoRepositorio itemRepos = new ItemPedidoRepositorio();
                

                ConectionDb conexao = new ConectionDb();

                string sql = "insert into Pedidos (idCliente,data) values (" + "'" + _obj.Cliente.Id + "'"+"," + "'" + DateTime.Now + "'" + ")";
                var dtSet = conexao.returDataSet(sql);

              //  itemRepos.inserir(_obj.Id, _obj.Cliente.Id);
               




            }
            catch (Exception e)
            {

                throw;
            }
        }

        public List<Pedido> preencheLista(DataSet _obj)
        {
            try
            {
                var meuData = _obj.Tables[0].AsEnumerable().Select(r => new Pedido
                {
                    Id = r.Field<int>("idPedido")
                    //,
                    //Cliente = r.Field<string>("nme"),
                    //NumeroDocumento = r.Field<int>("numDoc"),
                    //NumeroRegistro = r.Field<int>("numRegis"),
                    //Contato = new Contato(r.Field<int>("tel"), r.Field<string>("email"), r.Field<int>("cep"))

                });
                return meuData.ToList();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Pedido ultimoPedido()
        {
            try
            {


                ConectionDb conexao = new ConectionDb();
                string sql = "select Max(idPedido) as idPedido,idCliente  from Pedidos group by idCliente";
                var dtSet = conexao.returDataSet(sql);
                var meuData = dtSet.Tables[0].AsEnumerable().Select(r => new Pedido()
                {
                    Id = r.Field<int>("idPedido"),
                    Cliente = new Cliente { Id = r.Field<int>("idCliente") }



                }).Single();
                return meuData;

            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}
