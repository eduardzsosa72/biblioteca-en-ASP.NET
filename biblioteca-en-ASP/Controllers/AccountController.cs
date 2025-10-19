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
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Debe ingresar correo y contraseña.";
                return View();
            }

            if (_usuarioRepositorio == null)
            {
                ViewBag.Error = "Repositorio no inicializado.";
                return View();
            }

            var usuario = _usuarioRepositorio.ValidarUsuario(email, password);

            if (usuario == null)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos.";
                return View();
            }

            Session["Usuario"] = usuario.Nombre;
            Session["Rol"] = usuario.Rol;

            switch (usuario.Rol)
            {
                case "Administrador":
                    return RedirectToAction("Dashboard", "Admin");
                case "Profesor":
                case "Estudiante":
                    return RedirectToAction("Index", "Home"); // o "Libro"
                default:
                    ViewBag.Error = "Rol no reconocido.";
                    return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
