using ModalLogin.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class UserController : Controller
    {
        UserBusinessLogic UserBL = new UserBusinessLogic();
        //
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User User)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                if (UserBL.CheckUserLogin(User)>0)
                {
                    message = "Success";
                }
                else
                {
                    message = "UserName Or Password Is Incorrect";
                }
            }
            else
            {
                message = "All Fields Required";
            }

            if (Request.IsAjaxRequest())
            {
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}