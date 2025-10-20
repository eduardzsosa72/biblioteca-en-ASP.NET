using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Repositorios;
using biblioteca_en_ASP_NET.Servicios;
using biblioteca_en_ASP_NET.Models;
using System;
using System.Reflection;
using System.Web.Mvc;



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

        // Buscar usuario en la DB
        var usuario = _usuarioRepositorio.ValidarUsuario(email, password);

        if (usuario == null)
        {
            // Redirigir a registro de perfil
            TempData["EmailAD"] = email;  // pasar email a la vista de registro
            TempData["PasswordAD"] = password;
            return RedirectToAction("RegistrarPerfil");
        }

        // Guardar sesión
        Session["Usuario"] = usuario.Nombre;
        Session["Rol"] = usuario.Rol;

        // Redirigir según rol
        return RedirectToAction("Dashboard", usuario.Rol);
    }

    [HttpGet]
    public ActionResult RegistrarPerfil()
    {
        ViewBag.Email = TempData["EmailAD"];
       ViewBag.Password = TempData["PasswordAD"];
        return View();
    }

    [HttpPost]
    public ActionResult RegistrarPerfil(string nombre, string apellido,DateTime FechaNacimiento, string email, string password)
    {
        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
        {
            ViewBag.Error = "Nombre y apellido son obligatorios.";
            return View();
        }

        // Crear persona
        var personaId = _usuarioRepositorio.CrearPersona(new Persona
        {
            Nombre = nombre,
            Apellido = apellido,
            Correo = email,
            FechaNacimiento =FechaNacimiento,
            TipoPersona = "Estudiante"
        });

        _usuarioRepositorio.CrearUsuario(new Usuario
        {
            PersonaId = personaId,
            Rol = "Estudiante",
            Password = password
        });

        // Guardar sesión
        Session["Usuario"] = nombre;
        Session["Rol"] = "Estudiante";

        return RedirectToAction("Dashboard", "Estudiante");
    }

    public ActionResult Logout()
    {
        Session.Clear();
        return RedirectToAction("Login");
    }
}
