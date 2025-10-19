using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Repositorios;
using biblioteca_en_ASP_NET.Servicios;
using System.Web.Mvc;

namespace biblioteca_en_ASP_NET.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ActiveDirectoryService _adService;

        public AccountController()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
            _adService = new ActiveDirectoryService("gokupelonadmin.com");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            // Validar en Active Directory
            if (!_adService.ValidarAD(email, password))
            {
                ViewBag.Error = "Usuario o contraseña incorrectos en Active Directory.";
                return View();
            }

            // Buscar usuario en DB para rol
            var usuario = _usuarioRepositorio.ValidarUsuario(email, password);
            if (usuario == null)
            {
                ViewBag.Error = "Usuario no registrado en la base de datos.";
                return View();
            }

            Session["Usuario"] = usuario.Nombre;
            Session["Rol"] = usuario.Rol;

            // Redirigir según rol
            if (usuario.Rol == "Administrador")
                return RedirectToAction("Dashboard", "Admin");
            else if (usuario.Rol == "Profesor")
                return RedirectToAction("Dashboard", "Profesor");
            else
                return RedirectToAction("Dashboard", "Estudiante");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
