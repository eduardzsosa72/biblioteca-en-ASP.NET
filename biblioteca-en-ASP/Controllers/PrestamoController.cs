using System.Web.Mvc;
using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Repositorios;
using System.Collections.Generic;

namespace biblioteca_en_ASP_NET.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly IPrestamoRepositorio _prestamoRepositorio;

        public PrestamoController()
        {
            _prestamoRepositorio = new PrestamoRepositorio();
        }

        public ActionResult Index()
        {
            var prestamos = _prestamoRepositorio.ObtenerPrestamos() ?? new List<Prestamo>();
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
            if (ModelState.IsValid)
            {
                _prestamoRepositorio.AgregarPrestamo(prestamo);
                return RedirectToAction("Index");
            }
            return View(prestamo);
        }
    }
}
