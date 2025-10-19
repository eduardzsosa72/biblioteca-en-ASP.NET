using System.Web.Mvc;

namespace biblioteca_en_ASP_NET.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Dashboard()
        {
            if (Session["Rol"] == null || Session["Rol"].ToString() != "Administrador")
                return RedirectToAction("Login", "Account");

            ViewBag.Usuario = Session["Usuario"];
            return View();
        }
    }
}
