using System.Web.Mvc;
using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Repositorios;

namespace biblioteca_en_ASP_NET.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly IPrestamoRepositorio _repo = new PrestamoRepositorio();

        public ActionResult Index()
        {
            var prestamos = _repo.ObtenerTodos();
            return View(prestamos);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Prestamo prestamo)
        {
            prestamo.UsuarioCorreo = Session["Usuario"]?.ToString();
            _repo.Registrar(prestamo);
            return RedirectToAction("Index");
        }

        public ActionResult Devolver(int id)
        {
            _repo.DevolverLibro(id);
            return RedirectToAction("Index");
        }
    }
}
