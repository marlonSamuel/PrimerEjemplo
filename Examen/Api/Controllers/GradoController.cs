using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class GradoController : ApiController
    {
        private readonly Grado _grado = new Grado();

        [HttpGet]
        public HttpResponseMessage get()
        {
            try
            {
                var list = _grado.getAll();

                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch(Exception ex)
            {
                var message = "error";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
        }
        
        [HttpPost]
        public HttpResponseMessage post(Grado model)
        {
            try
            {
                var rpta = model.Save();
                return Request.CreateResponse(HttpStatusCode.OK, rpta);
            }
            catch
            {
                var message = "error";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
        }

        [HttpDelete]
        public HttpResponseMessage delete(int id)
        {
            try
            {
                var rpta = _grado.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, rpta);
            }
            catch
            {
                var message = "error";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
        }
    }
}
