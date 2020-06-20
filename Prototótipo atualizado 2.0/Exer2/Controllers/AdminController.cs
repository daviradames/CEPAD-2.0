using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exer2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult LoginADM()
        {
            return View();
        }
        public ActionResult cadastroADM()
        {
            return View();
        }
        public ActionResult AgendaADM()
        {
            return View();
        }
        public ActionResult AgendamentoADM()
        {
            return View();
        }

    }
}