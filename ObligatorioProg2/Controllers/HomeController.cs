using Microsoft.AspNetCore.Mvc;
using Dominio;
using System.Diagnostics;

namespace ObligatorioProg2.Controllers
{
    public class HomeController : Controller
    {

        Sistema _sistema = Sistema.Instancia;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                Usuario elU = _sistema.AutenticarUsuario(email, password);
                HttpContext.Session.SetString("email", elU.Email);
                HttpContext.Session.SetString("rol", elU.Rol);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex) 
            { 
                ViewBag.Error = ex.Message;
                return View(model: email);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
