using System.Web.Mvc;

namespace biblioteca_en_ASP_NET.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Index()
        {
            // Redirigir al login si no hay sesión
            if (Session["Usuario"] == null)
                return RedirectToAction("Login", "Account");

            // Redirigir según rol
            string rol = Session["Rol"] as string;
            if (rol == "Administrador")
                return RedirectToAction("Dashboard", "Admin");
            else if (rol == "Profesor")
                return RedirectToAction("Dashboard", "Profesor");
            else
                return RedirectToAction("Dashboard", "Estudiante");
        }
    }
}
