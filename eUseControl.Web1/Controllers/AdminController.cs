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

          public ActionResult Users(string searchTerm = null, LevelAcces? filterLevel = null)
          {
               var cookie = Request.Cookies["X-KEY"]?.Value;
               var currentUser = _session.GetUserByCookie(cookie);

               if (currentUser == null || currentUser.Level != LevelAcces.Admin)
               {
                    return RedirectToAction("Index", "Home");
               }

               using (var db = new UserContext())
               {
                    var usersQuery = db.Users.AsQueryable();

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                         usersQuery = usersQuery.Where(u => u.Username.Contains(searchTerm) || u.Email.Contains(searchTerm));
                    }

                    if (filterLevel.HasValue)
                    {
                         usersQuery = usersQuery.Where(u => u.Level == filterLevel.Value);
                    }

                    var users = usersQuery.ToList();

              
                    ViewBag.SearchTerm = searchTerm;
                    ViewBag.FilterLevel = filterLevel;

                    return View(users);
               }
          }

          [HttpPost]
          public ActionResult DeleteUser(int id)
          {
               var cookie = Request.Cookies["X-KEY"]?.Value;
               var currentUser = _session.GetUserByCookie(cookie);

               if (currentUser == null || currentUser.Level != LevelAcces.Admin)
               {
                    return RedirectToAction("Index", "Home");
               }

               using (var db = new UserContext())
               {
                    var user = db.Users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                    {
                
                         if (user.Id != currentUser.Id)
                         {
                              db.Users.Remove(user);
                              db.SaveChanges();
                         }
                    }
               }

               return RedirectToAction("Users");
          }
          [HttpPost]
          public ActionResult ToggleActive(int id)
          {
               var cookie = Request.Cookies["X-KEY"]?.Value;
               var currentUser = _session.GetUserByCookie(cookie);

               if (currentUser == null || currentUser.Level != LevelAcces.Admin)
               {
                    return RedirectToAction("Index", "Home");
               }

               using (var db = new UserContext())
               {
                    var user = db.Users.FirstOrDefault(u => u.Id == id);
                    if (user != null && user.Id != currentUser.Id) 
                    {
                         user.IsActive = !user.IsActive;
                         db.Entry(user).State = EntityState.Modified;
                         db.SaveChanges();
                    }
               }
               return RedirectToAction("Users");
          }
          [HttpPost]
          public ActionResult ResetPassword(int id)
          {
               var cookie = Request.Cookies["X-KEY"]?.Value;
               var currentUser = _session.GetUserByCookie(cookie);

               if (currentUser == null || currentUser.Level != LevelAcces.Admin)
               {
                    return RedirectToAction("Index", "Home");
               }

               using (var db = new UserContext())
               {
                    var user = db.Users.FirstOrDefault(u => u.Id == id);
                    if (user != null)
                    {
                  
                         string newPassword = "Temp1234";

                    
                         user.PasswordHash = HashPassword(newPassword);

                         db.Entry(user).State = EntityState.Modified;
                         db.SaveChanges();

                   
                    }
               }
               return RedirectToAction("Users");
          }

          private string HashPassword(string newPassword)
          {
               throw new NotImplementedException();
          }
     }
}
