using StudentMangmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMangmentSystem.Controllers
{
    public class LoginController : Controller
    {
        linadaEntities1 db = new linadaEntities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objchk)
        {
            if(ModelState.IsValid)
            {
                using(linadaEntities1 db = new linadaEntities1())
                {
                    var obj = db.users.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.id.ToString();
                        Session["UserNme"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "The username or password is incorrect");

                    }

                }
            }
            
            return View(objchk);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login"); 
        }




    }
}