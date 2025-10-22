using System;
using System.Web.Mvc;
using biblioteca_en_ASP_NET.Interfaces;
using biblioteca_en_ASP_NET.Repositorios;
using biblioteca_en_ASP_NET.Models;
using biblioteca_en_ASP_NET.Servicios;

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

        // Buscar usuario en la base de datos
        var usuario = _usuarioRepositorio.ValidarUsuario(email, password);

        if (usuario == null)
        {
            // Redirigir a registro de perfil si no existe
            TempData["EmailAD"] = email;
            TempData["PasswordAD"] = password;
            return RedirectToAction("RegistrarPerfil");
        }

        // Guardar sesión
        Session["Usuario"] = usuario.Persona.Nombre;
        Session["Rol"] = usuario.Rol;

        // Redirigir según rol
        switch (usuario.Rol)
        {
            case "Administrador":
                return RedirectToAction("Dashboard", "Admin"); // AdminController
            case "Profesor":
                return RedirectToAction("Dashboard", "Profesor"); // ProfesorController
            case "Estudiante":
                return RedirectToAction("Dashboard", "Estudiante"); // EstudianteController
            default:
                ViewBag.Error = "Rol no válido";
                return View("Login");
        }
    }

    [HttpGet]
    public ActionResult RegistrarPerfil()
    {
        ViewBag.Email = TempData["EmailAD"];
        ViewBag.Password = TempData["PasswordAD"];
        return View();
    }

    [HttpPost]
    public ActionResult RegistrarPerfil(string nombre, string apellido, DateTime FechaNacimiento, string email, string password)
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
            FechaNacimiento = FechaNacimiento,
            TipoPersona = "Estudiante"
        });

        // Crear usuario
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
