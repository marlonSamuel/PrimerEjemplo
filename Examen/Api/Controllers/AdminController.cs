using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Curso()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Alumno(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Grado()
        {
            return View();
        }
    }
}
