using Microsoft.AspNetCore.Mvc;

namespace ObligatorioProg2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            if(HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver esa pagina";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
    }
}
