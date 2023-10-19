using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P2P_Final_v0._001.Controllers
{
    public class RenterController : Controller
    {

        // GET: Home
        [RequireHttps]
        public ActionResult Index()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Cars()
        {
            return View();
        }

        public ActionResult Details(int? SelectedCarID)
        {
            if (SelectedCarID.HasValue)
            {
            }
            else
            {
                TempData["Error"] = $"<script> alert('No Car Has been selected')</script>";
            }
            return View( SelectedCarID);
        }


        public ActionResult Testimonies()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}