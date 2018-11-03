using Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factura.App_Code;

namespace LecturaFactura.Controllers
{
    public class SubirFacturaController : Controller
    {
        // GET: SubirFactura
        public ActionResult SubirFactura()
        {
            return View();
        }

        [HttpPost]
        public JsonResult cargarFactura(string Data)
        {
            try
            {


                return Json(Respuesta.newRespuesta(Respuesta.OK, "Factura subida", null));
            }
            catch (Exception ex)
            {
                return Json(Respuesta.newRespuesta(Respuesta.ERR, ex.Message, null));
            }
        }
    }
}