using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tocaLivrosBuisness.Repositorio.UsuarioRepositorio;
using tocaLivrosModel;

namespace tocalivrosMvcWeb.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Cliente()
        {
            return View();
        }

        // GET: Cliente/Details/5
        public ActionResult ListaCliente()
        {
            ClienteRepositorio repositorio = new ClienteRepositorio();
            List<Cliente> clientes = new List<Cliente>();
            clientes = repositorio.ExibirTodos();
            return View(clientes);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Cliente(FormCollection collection)
        {
            try
            {
                Cliente cliente = new Cliente();

                cliente = preencheCliente(collection);
                ClienteRepositorio repositorio = new ClienteRepositorio();
                repositorio.inserir(cliente);
                // TODO: Add insert logic here
                TempData["sucesso"]= "Cliente Criado com sucesso!";
                return RedirectToAction("ListaCliente");
            }
            catch
            {
                TempData["erro"]  = "Não foi possível cadastrar!";
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Editar(int _id)
        {
            Cliente cliente = new Cliente();
            ClienteRepositorio repositorio = new ClienteRepositorio();
            cliente.Id = _id;
            cliente = repositorio.consultar(cliente);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Editar(int _id, FormCollection collection)
        {
            try
            {
                Cliente cliente = new Cliente();               
                cliente = preencheCliente(collection);
                cliente.Id = _id;
                ClienteRepositorio repositorio = new ClienteRepositorio();
                repositorio.editar(cliente);

                // TODO: Add update logic here
                TempData["sucesso"] = "Cliente Editado com sucesso!";

                return RedirectToAction("ListaCliente");
            }
            catch
            {
                TempData["erro"] = "Não foi possível Editar!";

                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int _id)
        {
            Cliente cliente = new Cliente();
            ClienteRepositorio repositorio = new ClienteRepositorio();
            cliente.Id = _id;
            cliente = repositorio.consultar(cliente);
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int _id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ClienteRepositorio repositorio = new ClienteRepositorio();
                repositorio.excluir(_id);
                TempData["sucesso"] = "Cliente Excluído com sucesso!";

                return RedirectToAction("ListaCliente");
            }
            catch
            {
                TempData["erro"] = "Não foi possível Deletar!";

                return View();
            }
        }

        public Cliente preencheCliente(FormCollection collection)
        {
            try
            {
                Cliente cliente = new Cliente();
                Contato contato = new Contato();

                cliente.Nome = collection["txtNome"];
                cliente.NumeroDocumento = Convert.ToInt32(collection["txtNumeroDocumento"]);
                cliente.NumeroRegistro = Convert.ToInt32(collection["txtNumeroRegistro"]);
                contato.Email = collection["txtEmail"];
                contato.Telefone = Convert.ToInt32(collection["txtTelefone"]);
                contato.Cep = Convert.ToInt32(collection["txtCep"]);
                cliente.Contato = contato;

                // TODO: Add insert logic here
                return cliente;
            }
            catch
            {
                return null;
            }

        }
    }
}
