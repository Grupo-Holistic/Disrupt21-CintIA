using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Disrupt.Web.Models;
using Fiap.Disrupt.Web.Repositories;
using Fiap.Disrupt.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Disrupt.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Remover(int id)
        {
            _usuarioRepository.Remover(id);
            _usuarioRepository.Salvar();
            TempData["msg"] = "Usuario Removido";

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            

            var usuario = _usuarioRepository.Pesquisar(id);

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            _usuarioRepository.Atualizar(usuario);
            _usuarioRepository.Salvar();
            TempData["msg"] = "Usuario Atualizado";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            
            return View();
        }

        

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);
            _usuarioRepository.Salvar();
            TempData["msg"] = "Usuario Cadastrado";

            return RedirectToAction("Login", "Usuario");

        }
        public IActionResult Login(string email, string senha)
        {
            var login = _usuarioRepository.PesquisarLogin(email, senha);
            ViewBag.Log = login;

            if (login != null)
            {
                
                return RedirectToAction("Watson", "Usuario");

            }
            else
            {
                TempData["msg"] = "Usuario ou senha inválido";
            }
            return View();
        }
        public IActionResult Index()
        {

            var lista = _usuarioRepository.Listar();
            var model = new IndexUsuarioViewModel
            {
                Usuarios = lista
            };

            return View(model);
        }

        public IActionResult Watson()
        {
            return View();
        }
    }
}
