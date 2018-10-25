using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class AsignacionController : ApiController
    {
        private readonly AlumnoCurso _asignacion = new AlumnoCurso();

        [HttpGet]
        public HttpResponseMessage get()
        {
            try
            {
                var list = _asignacion.getAll();
                return Request.CreateResponse(HttpStatusCode.OK, list);
            }
            catch
            {
                var message = "error";
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message);
            }
           
        }

        [HttpGet]
        public HttpResponseMessage post(int idAlumno, List<int> cursoId)
        {
            try
            {
                var rpta = _asignacion.save(idAlumno, cursoId);
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
