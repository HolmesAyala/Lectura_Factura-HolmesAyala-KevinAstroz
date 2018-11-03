﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return Json(Respuesta.newRespuesta(Respuesta.OK, "", Data));
        }
    }

    public class Respuesta
    {
        public const int OK = 1;
        public const int ERR = 1;

        private Respuesta()
        {

        }

        public static Respuesta newRespuesta(int estado, string mensaje, object data)
        {
            return new Respuesta { Estado = estado, Mensaje = mensaje, Data = data };
        }

        public int Estado { get; set; }

        public string Mensaje { get; set; }

        public object Data { get; set; }
    }
}