using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TransShipModel.Responses;

namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class CursoController : ApiController
    {
        private readonly Curso _curso = new Curso();

        public HttpResponseMessage get()
        {
            try
            {

                var list = new List<Curso>();
                list = _curso.Listar();
                return Request.CreateResponse(HttpStatusCode.OK, list);

            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Error al obtener los cursos - " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, mensaje);
            }

        }

        public HttpResponseMessage post(Curso model)
        {
            try
            {
                bool rpta;

                rpta = model.Save();
                return Request.CreateResponse(HttpStatusCode.OK, rpta);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Exception to save contact - " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, mensaje);
            }

        }

        public HttpResponseMessage delete(int id)
        {
            try
            {

                var delete = _curso.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, delete);
            }
            catch (Exception e)
            {
                ErrorMessage mensaje = new ErrorMessage("2.1", "Error al eliminar - " + e.GetBaseException().Message, e.ToString());
                return Request.CreateResponse(HttpStatusCode.InternalServerError, mensaje);
            }

        }
    }
}
