using Factura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Factura.App_Code;
using System.Net.Http;
using System.IO;
using System.Drawing;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

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
        public async System.Threading.Tasks.Task<JsonResult> cargarFactura(string Data, string NombreArchivo)
        {
            try
            {
                Data = Data.Replace("data:image/jpeg;base64,", "");

                string pathOk = this.Server.MapPath("~/FilesFacturas/") + String.Format("{0}_{1}", DateTime.Now.ToString("yyMMddHHmmss"), NombreArchivo);
                

                //var archivo = new FileStream(pathOk, FileMode.Create);
                //archivo.Write(Convert.FromBase64String(Data), 0, (int)archivo.Length );
                //archivo.Flush();
                //archivo.Dispose();
                Image.FromStream(new MemoryStream(Convert.FromBase64String(Data))).Save(pathOk);

                var client = new HttpClient();
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                // Request headers
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscri" +
                    "" +
                    "ption-Key", "13fc1b0f765c4d67a71a705ca5c2e080");

                // Request parameters
                queryString["language"] = "unk";
                queryString["detectOrientation "] = "true";
                var uri = "https://eastus2.api.cognitive.microsoft.com/vision/v1.0/ocr?" + queryString;

                HttpResponseMessage response;
                                             

                //Bitmap.FromFile(pathOk);

                // Request body
                byte[] byteData = Convert.FromBase64String(Data);

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response =await client.PostAsync(uri, content);
                }

                String respuesta = response.Content.ReadAsStringAsync().Result;

                JObject jObject = new JObject();

                String RelativePath = pathOk.Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"], String.Empty);

                jObject["Data"] = respuesta;
                jObject["RutaArchivo"] = RelativePath;

                // Insertar datos en la base de datos       
                return Json(Respuesta.newRespuesta(Respuesta.OK, "Factura subida", jObject.ToString() ));
            }
            catch (Exception ex)
            {
                return Json(Respuesta.newRespuesta(Respuesta.ERR, ex.Message, null));
            }
        }
    }
}