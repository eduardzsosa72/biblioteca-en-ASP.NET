using System.Web.Mvc;
using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Repositorios;

namespace biblioteca_en_ASP_NET.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroRepositorio _repo = new LibroRepositorio();

        public ActionResult Index()
        {
            var libros = _repo.ObtenerTodos();
            return View(libros);
        }

        [HttpGet]
        public ActionResult Crear() => View();

        [HttpPost]
        public ActionResult Crear(Libro libro)
        {
            if (!ModelState.IsValid)
                return View(libro);

            _repo.Agregar(libro);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var libro = _repo.ObtenerPorId(id);
            return View(libro);
        }

        [HttpPost]
        public ActionResult Editar(Libro libro)
        {
            _repo.Editar(libro);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            _repo.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
