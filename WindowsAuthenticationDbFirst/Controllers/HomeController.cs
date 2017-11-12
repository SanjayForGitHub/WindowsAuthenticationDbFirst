using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WindowsAuthenticationDbFirst.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        [Authorize(Users = @"CONTOSO\Rick, CONTOSO\Keith, CONTOSO\Mike")]
        public ActionResult About()
        {
            return View();
        }

        [Authorize(Roles = @"CONTOSO\VBmanagers,CONTOSO\CSmanagers")]
        public ActionResult VB_CS_Managers()
        {
            return View();
        }

        [Authorize(Roles = @"VPs")]
        public ActionResult VP()
        {
            return View();
        }

    }
}