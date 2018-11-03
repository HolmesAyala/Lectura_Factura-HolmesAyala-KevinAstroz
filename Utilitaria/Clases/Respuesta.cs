using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LecturaFactura.App_Code
{
    public class Respuesta
    {
        const int OK = 1;
        const int ERR = 1;

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