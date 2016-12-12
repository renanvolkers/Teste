using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tocaLivrosBuisness.Repositorio;
using tocaLivrosBuisness.Repositorio.UsuarioRepositorio;
using tocaLivrosModel;

namespace tocalivrosMvcWeb.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Pedido(Cliente _cliente, FormCollection colletion)
        {
            try
            {
                List<SelectListItem> listCliente = new List<SelectListItem>();
                ClienteRepositorio repositorioCliente = new ClienteRepositorio();
                var clientes = repositorioCliente.ExibirTodos();
                foreach (var item in clientes)
                {
                    listCliente.Add(new SelectListItem
                    {
                        Text = item.Nome,
                        Value = item.Id.ToString()
                    });
                }

               
                    TempData["listCliente"] = listCliente;
                return View();
                


            }
            catch (Exception e)
            {

                throw;
            }

            return View();
        }

        // GET: Pedido/Details/5
        public ActionResult ListaPedido()
        {
            PedidoRepositorio repositorio = new PedidoRepositorio();
            List<Pedido> Pedidos = new List<Pedido>();
            Pedidos = repositorio.ExibirTodos();
            return View(Pedidos);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        public ActionResult Pedido(FormCollection collection)
        {
            try
            {
                Pedido pedido = new Pedido();
                Cliente cliente = new Cliente();
                cliente.Id = Convert.ToInt32(collection["ddlCliente"]);
                pedido.Cliente = cliente;

               // Pedido = preenchePedido(collection);
                PedidoRepositorio repositorio = new PedidoRepositorio();
                repositorio.inserir(pedido);
                pedido.Id = repositorio.ultimoPedido().Id;
                pedido.Cliente = new ClienteRepositorio().consultar(cliente);

                

                TempData["listProduto"] = preecheTemData();

                // TODO: Add insert logic here
                return View ("Editar",pedido);
            }
            catch
            {
                TempData["erro"] = "Não foi possível cadastrar!";
                return View();
            }
        }

        // GET: Pedido/Edit/5
        public ActionResult Editar()
        {
            Pedido Pedido = new Pedido();
            PedidoRepositorio repositorio = new PedidoRepositorio();
            Pedido = repositorio.ultimoPedido();
         


            return View(Pedido);
        }

        public ActionResult Editar(int id)
        {
            Pedido pedido = new Pedido();
            pedido.Id = id;
            PedidoRepositorio repositorio = new PedidoRepositorio();
            pedido = repositorio.consultar(pedido);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        public ActionResult Adicionar(int _id, FormCollection collection)
        {
            try
            {
                TempData["sucesso"] = null;
                TempData["erro"] = null;
                   Pedido Pedido = new Pedido();
                var idProduto =  Convert.ToInt32(collection["ddlProduto"]);
                Pedido.Id = _id;
                PedidoRepositorio repositorio = new PedidoRepositorio();

                ItemPedidoRepositorio itemRepositorio = new ItemPedidoRepositorio();
                itemRepositorio.inserir(idProduto, _id);

                TempData["listProduto"] = preecheTemData();

                Pedido.Itens = itemRepositorio.ExibirTodos(Pedido.Id);

                return View("Editar",Pedido);
            }
            catch (SqlException e)
            {

                Pedido Pedido = new Pedido();
                var idProduto = Convert.ToInt32(collection["ddlProduto"]);
                Pedido.Id = _id;
                PedidoRepositorio repositorio = new PedidoRepositorio();

                ItemPedidoRepositorio itemRepositorio = new ItemPedidoRepositorio();

                TempData["listProduto"] = preecheTemData();
                ItemPedidoRepositorio repositorioItem = new ItemPedidoRepositorio();
                Pedido.Itens = repositorioItem.ExibirTodos(Pedido.Id);


                TempData["erro"] = "Já existi produto no pedido!";
                return View("Editar",Pedido);
            }
            catch(Exception e)
            {
                TempData["erro"] = "Não foi possível adicionar!";

                return View();
            }
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete1(int _id)
        {
            Pedido Pedido = new Pedido();
            PedidoRepositorio repositorio = new PedidoRepositorio();
            Pedido.Id = _id;
            Pedido = repositorio.consultar(Pedido);
            return View(Pedido);
        }

        // POST: Pedido/Delete/5
        
        public ActionResult Delete(int _idPedido,int _idProduto, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ItemPedidoRepositorio repositorioItem = new ItemPedidoRepositorio();
                repositorioItem.excluir(_idPedido, _idProduto);
                Pedido pedido = new Pedido();
                pedido.Id = _idPedido;
                TempData["listProduto"] = preecheTemData();
                pedido.Itens = repositorioItem.ExibirTodos(pedido.Id);


                return View("Editar",pedido);
            }
            catch
            {
                TempData["erro"] = "Não foi possível Deletar!";

                return View();
            }
        }



        public List<SelectListItem> preecheTemData()
        {
            List<SelectListItem> listProduto = new List<SelectListItem>();
            Produto produto = new Produto();
            ProdutoRepositorio repositorioProduto = new ProdutoRepositorio();
            var produtos = repositorioProduto.ExibirTodos();
            foreach (var item in produtos)
            {
                listProduto.Add(new SelectListItem
                {
                    Text = item.Nome,
                    Value = item.Id.ToString()
                });
            }

            return listProduto;
        }

    }
}
