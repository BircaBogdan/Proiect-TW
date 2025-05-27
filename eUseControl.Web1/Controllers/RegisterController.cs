using System;
using System.Web.Mvc;
using AutoMapper;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web1.Models;

namespace eUseControl.Web1.Controllers
{
     public class RegisterController : Controller
     {
          private readonly ISession _session;

          public RegisterController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
          }

          public ActionResult Index()
          {
               return View();
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(UserRegister register)
          {
              
               if (register.Role == "Admin" && register.AdminSecret != "superadmin")
               {
                    ModelState.AddModelError("", "Codul secret pentru admin este invalid.");
                    return View(register);
               }

               if (ModelState.IsValid)
               {
                    var data = Mapper.Map<URegisterData>(register);
                    data.RegisterIp = Request.UserHostAddress;
                    data.RegisterDateTime = DateTime.Now;

                    
                    data.Role = register.Role;

                    var registerResult = _session.UserRegister(data);
                    if (registerResult.Status)
                    {
                         return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                         ModelState.AddModelError("", registerResult.StatusMsg);
                    }
               }

               return View(register);
          }

     }
}