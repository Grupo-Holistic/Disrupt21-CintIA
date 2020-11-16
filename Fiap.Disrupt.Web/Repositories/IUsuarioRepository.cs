
using Fiap.Disrupt.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Disrupt.Web.Repositories
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(int id);
        Usuario Buscar(int id);
        IList<Usuario> Listar();
        IList<Usuario> BuscarPor(Expression<Func<Usuario, bool>> filtro);
        Usuario PesquisarLogin(string email, string senha);
        void Salvar();
        object Pesquisar(int id);
    }
}
