using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using AutoMapper;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.User;

namespace eUseControl.Web1.Controllers
{
     public class AdminController : Controller
     {
          private readonly ISession _session;

          public AdminController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
          }

          public ActionResult Users()
          {
               var cookie = Request.Cookies["X-KEY"]?.Value;
               var currentUser = _session.GetUserByCookie(cookie);

               if (currentUser == null || currentUser.Level != LevelAcces.Admin)
               {
                    return RedirectToAction("Index", "Home");
               }

               using (var db = new UserContext())
               {
                    var users = db.Users.ToList();
                    return View(users);
               }
          }
     }
}