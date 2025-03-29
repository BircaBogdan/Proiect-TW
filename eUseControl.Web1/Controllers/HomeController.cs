using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using eUseControl.Web1.Extension;
using eUseControl.Web1.Models;


namespace eUseControl.Web1.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("Index", "Login");
               }

               var user = System.Web.HttpContext.Current.GetMySessionObject();
               Domains s = new Domains();
               s.Title = "Servicii";
               s.Description = "Serviciile medicale oferite";
               s.Services = new List<string> { "Cardiologie", "Starea Pulmonară","Neurologie","Pediatrie","Stomatologie","Laborator" };
               s.Images = new List<string> { "fa fa-heartbeat text-primary fs-4", "fa fa-x-ray text-primary fs-4", "fa fa-brain text-primary fs-4", "fa fa-wheelchair text-primary fs-4", "fa fa-tooth text-primary fs-4", "fa fa-vials text-primary fs-4" };

               
            return View(s);
        }
        public ActionResult Service()
        {
               return View();
        }
        public ActionResult About()
        {
               return View();
        }
        public ActionResult Contact()
        {
               return View();
        }

     }
}