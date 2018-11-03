using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factura
{
    public class Respuesta
    {
        public const int OK = 1;
        public const int ERR = 2;

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