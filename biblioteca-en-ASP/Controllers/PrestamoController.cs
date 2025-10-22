using System;
using System.Web.Mvc;
using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Repositorios;

namespace biblioteca_en_ASP_NET.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly IPrestamoRepositorio _prestamoRepo;
        private readonly ILibroRepositorio _libroRepo;

        public PrestamoController()
        {
            _prestamoRepo = new PrestamoRepositorio();
            _libroRepo = new LibroRepositorio();
        }

        public ActionResult Index()
        {
            var prestamos = _prestamoRepo.ObtenerPrestamos();
            return View(prestamos);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            ViewBag.Libros = _libroRepo.ObtenerLibros();
            return View();
        }

        [HttpPost]
        public ActionResult Crear(int libroId)
        {
            if (Session["UsuarioId"] == null)
                return RedirectToAction("Login", "Account");

            var nuevoPrestamo = new Prestamo
            {
                UsuarioId = Convert.ToInt32(Session["UsuarioId"]),
                LibroId = libroId,
                FechaPrestamo = DateTime.Now,
                FechaDevolucion = DateTime.Now.AddDays(7)
            };

            _prestamoRepo.CrearPrestamo(nuevoPrestamo);
            TempData["Mensaje"] = "Préstamo registrado correctamente.";
            return RedirectToAction("Index");
        }
    }
}
