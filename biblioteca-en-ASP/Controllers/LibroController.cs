using System.Web.Mvc;
using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Repositorios;
using System.Collections.Generic;

namespace biblioteca_en_ASP_NET.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroRepositorio _libroRepositorio;

        public LibroController()
        {
            _libroRepositorio = new LibroRepositorio();
        }

        public ActionResult Index()
        {
            var libros = _libroRepositorio.ObtenerLibros() ?? new List<Libro>();
            return View(libros);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _libroRepositorio.AgregarLibro(libro);
                return RedirectToAction("Index");
            }
            return View(libro);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var libro = _libroRepositorio.ObtenerPorId(id);
            if (libro == null) return HttpNotFound();
            return View(libro);
        }

        [HttpPost]
        public ActionResult Editar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _libroRepositorio.ActualizarLibro(libro);
                return RedirectToAction("Index");
            }
            return View(libro);
        }
    }
}
