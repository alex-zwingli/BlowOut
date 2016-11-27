using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlowOut.DAL;
using BlowOut.Models;

namespace BlowOut.Controllers
{
    [Authorize]
    [RequireHttps]
    public class RentalsController : Controller
    {
        private AICContext db = new AICContext();

        // GET: Rentals
        public ActionResult UpdateData()
        {

            IEnumerable<Rentals> Rentals = db.Database.SqlQuery<Rentals>("SELECT * FROM Instrument INNER JOIN Client ON Instrument.ClientID = Client.ClientID;");

            return View(Rentals);
        }

        // GET: Rentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var rentals = db.Database.SqlQuery<Rentals>("SELECT * FROM Instrument INNER JOIN Client ON Instrument.ClientID = Client.ClientID WHERE InstrumentID = " + id + ";").FirstOrDefault();

            if (rentals == null)
            {
                return HttpNotFound();
            }
            return View(rentals);
        }

        // GET: Rentals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstrumentID,Description,Type,Price,ClientID,FirstName,LastName,Address,City,State,ZIP,Email,Phone")] Rentals rentals)
        {
            if (ModelState.IsValid)
            {
                db.Rentals.Add(rentals);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rentals);
        }

        // GET: Rentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstrumentID,Description,Type,Price,ClientID,FirstName,LastName,Address,City,State,ZIP,Email,Phone")] Rentals client, int ClientID)
        {
            client.ClientID = ClientID;

            if (ModelState.IsValid)
            {
                // Load current account from DB
                var clientInDb = db.Clients.Single(c => c.ClientID == client.ClientID);

                // Update the properties
                db.Entry(clientInDb).CurrentValues.SetValues(client);

                // Save the changes
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // Return to view to display errors
            return View(client);
        }

        // GET: Rentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();

            db.Database.ExecuteSqlCommand("UPDATE Instrument SET ClientID = NULL WHERE (ClientID = " + id + ");");

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
