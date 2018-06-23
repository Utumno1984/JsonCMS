using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsonCMS.Areas.Manager.Controllers
{
    public class HomeManagerController : Controller
    {
        // GET: Manager/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}