using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tocaLivrosBuisness.Repositorio.IURepositorio
{
   public interface IUGeneric<T>
    {
        List<T> ExibirTodos();
        void inserir(T _obj);
        void excluir(int _id);
        void editar(T _obj);
        T consultar(T _obj);
    }
}
