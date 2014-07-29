using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeInventory.Models;

namespace BikeInventory.Controllers
{
    [Authorize]
    public class BikesController : Controller
    {
        private BikeDBContext db = new BikeDBContext();

        //
        // GET: /Bikes/

        public ActionResult Index()
        {
            return View(db.Bikes.ToList());
        }

        //
        // GET: /Bikes/Details/5

        public ActionResult Details(int id = 0)
        {
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        //
        // GET: /Bikes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Bikes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Bikes.Add(bike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bike);
        }

        //
        // GET: /Bikes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        public ActionResult Remove(int id = 0)
        {
            Bike bike = db.Bikes.Find(id);
            bike.quantity--;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //
        // POST: /Bikes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bike);
        }

        //
        // GET: /Bikes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        //
        // POST: /Bikes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bike bike = db.Bikes.Find(id);
            db.Bikes.Remove(bike);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}