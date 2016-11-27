using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BlowOut.Models;
using System.Web.Security;

namespace BlowOut.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String user = form["User Name"].ToString();
            String password = form["Password"].ToString();

            if (string.Equals(user, "Missouri") && (string.Equals(password, "ShowMe")))
            {
                FormsAuthentication.SetAuthCookie(user, rememberMe);

                return RedirectToAction("UpdateData", "Rentals");

            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}