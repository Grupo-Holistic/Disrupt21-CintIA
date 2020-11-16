
using Fiap.Disrupt.Web.Models;
using Fiap.Disrupt.Web.Persistencia;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fiap.Disrupt.Web.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private DisruptContext _context;
        public UsuarioRepository(DisruptContext context)
        {
            _context = context;
        }

        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public Usuario Buscar(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public IList<Usuario> BuscarPor(Expression<Func<Usuario, bool>> filtro)
        {
            return _context.Usuarios.Where(filtro).ToList();
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }

        public IList<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public object Pesquisar(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario PesquisarLogin(string email, string senha)
        {
            return _context.Usuarios.Where(u => (u.Email == email) && (u.Senha == senha)).FirstOrDefault();
        }

        public void Remover(int id)
        {
            _context.Usuarios.Remove(_context.Usuarios.Find(id));
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }
    }
}
