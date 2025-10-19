using System.Web.Mvc;
using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Repositorios;
using biblioteca_en_ASP_NET.Models;
using System.Collections.Generic;

namespace biblioteca_en_ASP_NET.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AdminController()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public ActionResult Dashboard()
        {
            var usuarios = _usuarioRepositorio.ObtenerUsuarios() ?? new List<Usuario>();
            return View(usuarios);
        }
    }
}
