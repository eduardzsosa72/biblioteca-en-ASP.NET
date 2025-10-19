using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Repositorio;
using biblioteca_en_ASP_NET.Repositorios;
using System.Collections.Generic;
using System.Web.Mvc;

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
            // Obtener lista de usuarios
            var usuarios = _usuarioRepositorio.ObtenerUsuarios();

            // Asegurarse que nunca sea null
            if (usuarios == null)
                usuarios = new List<Usuario>();

            return View(usuarios);
        }
    }
}
