using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tocaLivrosBuisness.Repositorio.IURepositorio;
using tocaLivrosDataBase;
using tocaLivrosModel;

namespace tocaLivrosBuisness.Repositorio.UsuarioRepositorio
{
    public class ProdutoRepositorio : IUGeneric<Produto>
    {
        public Produto consultar(Produto _obj)
        {
            try
            {


                ConectionDb conexao = new ConectionDb();

                string sql = "Select * from Produto where idProduto=" + _obj.Id;
                var dtSet = conexao.returDataSet(sql);
                return preencheLista(dtSet).Single();

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void editar(Produto _obj)
        {
            try
            {
                ConectionDb conexao = new ConectionDb();

                string sql = "update  Produto set nme=" + "'" + _obj.Nome + "'" + ",vlrProduto=" + "'" + _obj.VlrProduto + "'" + ",qtd=" + "'" + _obj.QtdProduto +  " where idProduto=" + _obj.Id + "";
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

                string sql = "delete  Produto  where idProduto=" + _id;
                var dtSet = conexao.returDataSet(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Produto> ExibirTodos()
        {
            try
            {


                ConectionDb conexao = new ConectionDb();

                string sql = "Select * from Produto";
                var dtSet = conexao.returDataSet(sql);

                return preencheLista(dtSet);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void inserir(Produto _obj)
        {
            try
            {


                ConectionDb conexao = new ConectionDb();

                string sql = "insert into Produto (nme,vlrProduto,qtd) values (" + "'" + _obj.Nome + "'" + "," + "'" + _obj.VlrProduto + "'" + "," + "'" + _obj.QtdProduto + "'" + ")";
                var dtSet = conexao.returDataSet(sql);



            }
            catch (Exception e)
            {

                throw;
            }
        }

        public List<Produto> preencheLista(DataSet _obj)
        {
            try
            {
                var meuData = _obj.Tables[0].AsEnumerable().Select(r => new Produto
                {
                    Id = r.Field<int>("idProduto"),
                    Nome = r.Field<string>("nme"),
                    VlrProduto = r.Field<int>("vlrProduto"),
                    QtdProduto = r.Field<int>("qtd")

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
