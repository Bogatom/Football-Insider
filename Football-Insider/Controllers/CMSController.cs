using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Football_Insider.Controllers
{
    public class CMSController : Controller
    {
        // GET: CMS
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}