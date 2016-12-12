using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tocaLivrosBuisness.Repositorio.UsuarioRepositorio;
using tocaLivrosModel;

namespace tocalivrosMvcWeb.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Produto()
        {
            return View();
        }

        // GET: Produto/Details/5
        public ActionResult ListaProduto()
        {
            ProdutoRepositorio repositorio = new ProdutoRepositorio();
            List<Produto> Produtos = new List<Produto>();
            Produtos = repositorio.ExibirTodos();
            return View(Produtos);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Produto(FormCollection collection)
        {
            try
            {
                Produto Produto = new Produto();

                Produto = preencheProduto(collection);
                ProdutoRepositorio repositorio = new ProdutoRepositorio();
                repositorio.inserir(Produto);
                // TODO: Add insert logic here
                TempData["sucesso"] = "Produto Criado com sucesso!";
                return RedirectToAction("ListaProduto");
            }
            catch
            {
                TempData["erro"] = "Não foi possível cadastrar!";
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Editar(int _id)
        {
            Produto Produto = new Produto();
            ProdutoRepositorio repositorio = new ProdutoRepositorio();
            Produto.Id = _id;
            Produto = repositorio.consultar(Produto);
            return View(Produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Editar(int _id, FormCollection collection)
        {
            try
            {
                Produto Produto = new Produto();
                Produto = preencheProduto(collection);
                Produto.Id = _id;
                ProdutoRepositorio repositorio = new ProdutoRepositorio();
                repositorio.editar(Produto);

                // TODO: Add update logic here
                TempData["sucesso"] = "Produto Editado com sucesso!";

                return RedirectToAction("ListaProduto");
            }
            catch
            {
                TempData["erro"] = "Não foi possível Editar!";

                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int _id)
        {
            Produto Produto = new Produto();
            ProdutoRepositorio repositorio = new ProdutoRepositorio();
            Produto.Id = _id;
            Produto = repositorio.consultar(Produto);
            return View(Produto);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(int _id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ProdutoRepositorio repositorio = new ProdutoRepositorio();
                repositorio.excluir(_id);
                TempData["sucesso"] = "Produto Excluído com sucesso!";

                return RedirectToAction("ListaProduto");
            }
            catch
            {
                TempData["erro"] = "Não foi possível Deletar!";

                return View();
            }
        }

        public Produto preencheProduto(FormCollection collection)
        {
            try
            {
                Produto Produto = new Produto();

                Produto.Nome = collection["txtNome"];
                Produto.QtdProduto = Convert.ToInt32(collection["txtQtdProduto"]);
                Produto.VlrProduto = Convert.ToInt32(collection["txtVlrProduto"]);
                // TODO: Add insert logic here
                return Produto;
            }
            catch
            {
                return null;
            }

        }
    }
}
