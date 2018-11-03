using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Npgsql;

namespace Factura.App_Code
{
    public class DBConexion
    {

        public static NpgsqlConnection getConexion()
        {
            return new NpgsqlConnection(ConfigurationManager.ConnectionStrings["Postgres"].ConnectionString);
        }

    }
}