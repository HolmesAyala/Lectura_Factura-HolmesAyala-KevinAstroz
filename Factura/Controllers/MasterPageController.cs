﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Factura.Controllers
{
    public class MasterPageController : Controller
    {
        // GET: MasterPage
        public ActionResult MasterPage()
        {
            return View();
        }
    }
}