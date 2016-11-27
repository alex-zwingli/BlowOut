using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.DAL;
using System.Collections;
using BlowOut.Models;
using System.Data.Entity;

namespace BlowOut.Controllers
{
    [RequireHttps]
    public class RentController : Controller
    {

        private AICContext db = new AICContext();

        // GET: Rent
        public ActionResult Index()
        {
            return RedirectToAction("Listings", "Rent", new { condition = "new" });
        }

        public ActionResult Listings(string condition)
        {
            if (condition == "used")
            {
                ViewBag.statusNew = "";
                ViewBag.statusUsed = "active";
                ViewBag.costTrumpet = "25";
                ViewBag.costTrombone = "35";
                ViewBag.costTuba = "50";
                ViewBag.costFlute = "25";
                ViewBag.costClarinet = "27";
                ViewBag.costSaxophone = "30";
            }
            else //new
            {
                ViewBag.statusNew = "active";
                ViewBag.statusUsed = "";
                ViewBag.costTrumpet = "55";
                ViewBag.costTrombone = "60";
                ViewBag.costTuba = "70";
                ViewBag.costFlute = "40";
                ViewBag.costClarinet = "35";
                ViewBag.costSaxophone = "42";
            }

            return View();
        }

        public ActionResult Instrument(string description)
        {
            //Send ViewBag Data
            ViewBag.img = "/Content/img/Instruments/" + description.ToLower() + "_800.jpg";
            ViewBag.instrument = description;

            //Highlight selected instrument on left panel
            switch (description.ToLower())
            {

                case "trumpet":
                    ViewBag.statusTrumpet = "active";
                    ViewBag.costNew = 55;
                    ViewBag.costUsed = 25;
                    break;

                case "trombone":
                    ViewBag.statusTrombone = "active";
                    ViewBag.costNew = 60;
                    ViewBag.costUsed = 35;
                    break;

                case "tuba":
                    ViewBag.statusTuba = "active";
                    ViewBag.costNew = 70;
                    ViewBag.costUsed = 50;
                    break;

                case "flute":
                    ViewBag.statusFlute = "active";
                    ViewBag.costNew = 40;
                    ViewBag.costUsed = 25;
                    break;

                case "clarinet":
                    ViewBag.statusClarinet = "active";
                    ViewBag.costNew = 35;
                    ViewBag.costUsed = 27;
                    break;

                case "saxophone":
                    ViewBag.statusSaxophone = "active";
                    ViewBag.costNew = 42;
                    ViewBag.costUsed = 30;
                    break;
            }

            return View();
        }

        [HttpGet]
        public ActionResult Rent(string description, string type)
        {
            TempData["description"] = description;
            TempData["type"] = type;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecordNewRental([Bind(Include = "ClientID,FirstName,LastName,Address,City,State,ZIP,Email,Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();

                int InstrumentID = db.Database.SqlQuery<int>("SELECT TOP 1 InstrumentID FROM dbo.Instrument WHERE (Description = '" + TempData["description"] + "') AND (type = '" + TempData["type"] + "'); ").FirstOrDefault<int>();

                if (InstrumentID > 0)
                {

                    db.Database.ExecuteSqlCommand("UPDATE Instrument SET ClientID = " + client.ClientID + " WHERE (InstrumentID = " + InstrumentID + ");");
                }

                //Client Information
                TempData["cFirsName"] = client.FirstName;
                TempData["cID"] = client.ClientID;

                //Instrument Information
                #region if and nested switch
                int price = 0;
                TempData["iName"] = TempData["description"];
                if (TempData["type"].ToString() == "1")
                {
                    TempData["iType"] = "New";
                    switch (TempData["description"].ToString().ToLower())
                    {
                        case "trumpet":
                            price = 55;
                            break;

                        case "trombone":
                            price = 60;
                            break;

                        case "tuba":
                            price = 70;
                            break;

                        case "flute":
                            price = 40;
                            break;

                        case "clarinet":
                            price = 35;
                            break;

                        case "saxophone":
                            price = 42;
                            break;
                    }
                }
                else
                {
                    TempData["iType"] = "Used";
                    switch (TempData["description"].ToString().ToLower())
                    {
                        case "trumpet":
                            price = 25;
                            break;

                        case "trombone":
                            price = 35;
                            break;

                        case "tuba":
                            price = 50;
                            break;

                        case "flute":
                            price = 25;
                            break;

                        case "clarinet":
                            price = 27;
                            break;

                        case "saxophone":
                            price = 30;
                            break;
                    }
                }
                #endregion

                TempData["iMontlyPrice"] = price;
                TempData["iPaidAfter18"] = price * 18;
                TempData["iDescription"] = "T";
                TempData["iImageURL"] = "/Content/img/Instruments/" + TempData["description"].ToString().ToLower() + "_320.jpg";




                return RedirectToAction("OrderConfirmation");

            }
            return View("Rent", client);
        }

        public ActionResult OrderConfirmation()
        {
            //Client Information
            ViewBag.cFirstName = TempData["cFirsName"];
            ViewBag.cID = TempData["cID"];

            //Instrument Information
            ViewBag.iName = TempData["iName"];
            ViewBag.iType = TempData["iType"];
            ViewBag.iImageURL = TempData["iImageURL"];
            ViewBag.iMonthlyPrice = TempData["iMontlyPrice"];
            ViewBag.iPaidAfter18 = TempData["iPaidAfter18"];

            return View();
        }

    }
}