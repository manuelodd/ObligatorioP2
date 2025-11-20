using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ObligatorioProg2.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult MyPayments()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver esa pagina";
                return RedirectToAction("Login", "Home");
            }
            List<Pago> listaPagos = Sistema.Instancia.GetPagosPorEmail(HttpContext.Session.GetString("email"));

            List<Pago> listaFiltrada = new List<Pago>();

            DateTime hoy = DateTime.Today;
            DateTime inicioMesActual = new DateTime(hoy.Year, hoy.Month, 1);
            DateTime finMesActual = new DateTime(hoy.Year, hoy.Month, DateTime.DaysInMonth(hoy.Year, hoy.Month));

            foreach (Pago unP in listaPagos)
            {
                if (unP is PagoUnico unPU && unPU.Fecha >= inicioMesActual && unPU.Fecha <= finMesActual)
                {
                    listaFiltrada.Add(unPU);
                }
                else if (unP is PagoRecurrente unPR && unPR.Hasta >= inicioMesActual && unPR.Desde <= finMesActual)
                {
                    listaFiltrada.Add(unPR);
                }
            }
            return View(listaFiltrada);
        }

        public IActionResult AllPayments() 
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver esa pagina";
                return RedirectToAction("Login", "Home");
            }

            Usuario usuLogeado = Sistema.Instancia.GetUsuarioPorEmail(HttpContext.Session.GetString("email"));
            List<Pago> listado = Sistema.Instancia.GetPagosPorEquipo(usuLogeado.Equipo.Nombre);

            return View(listado);
        }


        public IActionResult SelectPaymentType()
        {
            return View();
        }

        public IActionResult CreateSinglePayment()
        {
            ViewBag.TipoDeGastos = Sistema.Instancia.GetTipoGastos();
            return View();
        }

        [HttpPost]
        public IActionResult CreateSinglePayment(PagoUnico pago, string tipoGastoNombre)
        {
            try 
            {
            pago.Usuario = Sistema.Instancia.GetUsuarioPorEmail(HttpContext.Session.GetString("email"));
            pago.TipoGasto = Sistema.Instancia.GetTipoGastoPorNombre(tipoGastoNombre);
            pago.Validar();
            Sistema.Instancia.AgregarPago(pago);
                ViewBag.Exito = "Pago registrado con éxito!";
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            ViewBag.TipoDeGastos = Sistema.Instancia.GetTipoGastos();

            return View();
        }
    }
}