using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHealthyFinances.Controllers
{
    public class InfosController : Controller
    {
        // GET: Infos
        public ActionResult System()
        {
            return View();
        }

        public ActionResult Finances()
        {
            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult Tips()
        {
            return View();
        }
    }
}