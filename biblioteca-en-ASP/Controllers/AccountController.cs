using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Repositorio;
using biblioteca_en_ASP_NET.Repositorios;
using System.Web.Mvc;

namespace biblioteca_en_ASP_NET.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AccountController()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var usuario = _usuarioRepositorio.ValidarUsuario(email, password);

            if (usuario == null)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos.";
                return View();
            }

            Session["Usuario"] = usuario.Nombre;
            Session["Rol"] = usuario.Rol;

            if (usuario.Rol == "Administrador")
                return RedirectToAction("Dashboard", "Admin");
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
