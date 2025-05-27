using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.Domain.Entities.Contact;
using eUseControl.Domain.Entities.Programare;
using eUseControl.Web1.Models;
using eUseControl.Web1.ViewModels;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Web1.Extension;

namespace eUseControl.Web1.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ContactContext _context = new ContactContext();
        private readonly ProgramareContext _progcontext = new ProgramareContext();


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
            s.Services = new List<string> { "Cardiologie", "Starea Pulmonară", "Neurologie", "Pediatrie", "Stomatologie", "Laborator" };
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

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = new UDbContact
                {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message,
                    SentAt = DateTime.Now
                };

                _context.ContactMessages.Add(contact);
                _context.SaveChanges();

                ViewBag.Message = "Mesaj trimis cu succes!";
                ModelState.Clear();
                return View();
            }

            return View(model);
        }
     }
}
