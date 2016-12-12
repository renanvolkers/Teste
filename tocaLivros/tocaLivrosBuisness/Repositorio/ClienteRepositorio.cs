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
    public class ClienteRepositorio : IUGeneric<Cliente>
    {
        public Cliente consultar(Cliente _obj)
        {
            try
            {


                ConectionDb conexao = new ConectionDb();

                string sql = "Select * from Cliente where idCliente="+_obj.Id;
                var dtSet = conexao.returDataSet(sql);
                return preencheLista(dtSet).Single();

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void editar(Cliente _obj)
        {
            try
            {
                ConectionDb conexao = new ConectionDb();

                string sql = "update  Cliente set nme=" + "'" + _obj.Nome + "'" + ",numDoc=" + "'" + _obj.NumeroDocumento + "'" + ",numRegis=" + "'" + _obj.NumeroRegistro + "'" + ",email=" + "'" + _obj.Contato.Email + "'" + ",tel=" + "'" + _obj.Contato.Telefone + "'" + ",cep=" + "'" + _obj.Contato.Cep + "'" + " where idCliente=" + _obj.Id + "";
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

                string sql = "delete  Cliente  where idCliente=" + _id ;
                var dtSet = conexao.returDataSet(sql);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Cliente> ExibirTodos()
        {
            try
            {


                ConectionDb conexao = new ConectionDb();

                string sql = "Select * from Cliente";
                var dtSet = conexao.returDataSet(sql);

                return preencheLista(dtSet);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void inserir(Cliente _obj)
        {
            try
            {


                ConectionDb conexao = new ConectionDb();

                string sql = "insert into Cliente (nme,numDoc,numRegis,email,tel,cep) values (" +"'"+ _obj.Nome + "'" + "," + "'" + _obj.NumeroDocumento + "'" + "," + "'" + _obj.NumeroRegistro + "'" + "," + "'" + _obj.Contato.Email + "'" + "," + "'" + _obj.Contato.Telefone + "'" + "," + "'" + _obj.Contato.Cep + "'" + ")";
                var dtSet = conexao.returDataSet(sql);



            }
            catch (Exception e)
            {

                throw;
            }
        }

        public List<Cliente> preencheLista(DataSet _obj)
        {
            try
            {
                var meuData = _obj.Tables[0].AsEnumerable().Select(r => new Cliente
                {
                    Id = r.Field<int>("idCliente"),
                    Nome = r.Field<string>("nme"),
                    NumeroDocumento = r.Field<int>("numDoc"),
                    NumeroRegistro = r.Field<int>("numRegis"),
                    Contato = new Contato(r.Field<int>("tel"), r.Field<string>("email"), r.Field<int>("cep"))

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
