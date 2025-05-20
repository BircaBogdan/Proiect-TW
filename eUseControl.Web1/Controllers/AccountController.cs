using System;
using System.Web.Mvc;

namespace eUseControl.Web1.Controllers
{
    public class AccountController : Controller
    {
  
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
        
            if (username == "admin" && password == "password")
            {
                Session["User"] = username;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
