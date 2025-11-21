using Dominio;
using Microsoft.AspNetCore.Components.Forms;
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


        public IActionResult AllPayments(int? mes, int? anio) 
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                TempData["login"] = "Debes iniciar sesion para ver esa pagina";
                return RedirectToAction("Login", "Home");
            }

            Usuario usuLogeado = Sistema.Instancia.GetUsuarioPorEmail(HttpContext.Session.GetString("email"));

            DateTime hoy = DateTime.Today;
            int mesBuscado = mes.GetValueOrDefault(hoy.Month);
            int anioBuscado = anio.GetValueOrDefault(hoy.Year);

            DateTime inicioMes = new DateTime(anioBuscado, mesBuscado, 1);
            DateTime finMes = new DateTime(anioBuscado, mesBuscado, DateTime.DaysInMonth(anioBuscado, mesBuscado));

            List<Pago> pagosEquipo = Sistema.Instancia.GetPagosPorEquipo(usuLogeado.Equipo.Nombre);
            List<Pago> pagosEquipoFiltrados = new List<Pago>();

            foreach (Pago p in pagosEquipo)
            {
                if (p is PagoUnico unPU)
                {
                    if (unPU.Fecha >= inicioMes && unPU.Fecha <= finMes) pagosEquipoFiltrados.Add(unPU);
                }
                else
                {
                    if (p is PagoRecurrente unPR)
                    {
                        if (unPR.Desde <= finMes && unPR.Hasta >= inicioMes) pagosEquipoFiltrados.Add(unPR);
                    }
                }

            }

            ViewBag.Mes = mesBuscado;
            ViewBag.Anio = anioBuscado; 

            pagosEquipoFiltrados.Sort();
            return View(pagosEquipoFiltrados);
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

        public IActionResult CreateRecurrentPayment()
        {
            ViewBag.TipoDeGastos = Sistema.Instancia.GetTipoGastos();
            return View();
        }

        [HttpPost]
        public IActionResult CreateRecurrentPayment(PagoRecurrente pago, string tipoGastoNombre)
        {
            try
            {
                pago.Usuario = Sistema.Instancia.GetUsuarioPorEmail(HttpContext.Session.GetString("email"));
                pago.TipoGasto = Sistema.Instancia.GetTipoGastoPorNombre(tipoGastoNombre);
                pago.Validar();
                Sistema.Instancia.AgregarPago(pago);
                ViewBag.Exito = "Pago registrado con éxito!";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            ViewBag.TipoDeGastos = Sistema.Instancia.GetTipoGastos();

            return View();
        }
    }
}