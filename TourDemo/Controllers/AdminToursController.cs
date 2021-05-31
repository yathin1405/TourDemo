using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TourDemo.Models;

namespace TourDemo.Controllers
{
    public class AdminToursController : Controller
    {
        private TourContext db = new TourContext();

        // GET: AdminTours
        public ActionResult Index()
        {
            return View(db.AdminTours.ToList());


        }
        public ActionResult UserLandingPage()
        {
            return View(db.AdminTours.ToList());


        }


        // GET: AdminTours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminTour adminTour = db.AdminTours.Find(id);
            if (adminTour == null)
            {
                return HttpNotFound();
            }
            return View(adminTour);
        }

        // GET: AdminTours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminTours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tour_Num,Tour_Name,Tour_Duration,LocationFrom,LocationTO,TourDate,TourStartTime,TourName,Price,Deposit")] AdminTour adminTour)
        {
            if (ModelState.IsValid)
            {
                
                adminTour.Deposit = adminTour.deposit();
                db.AdminTours.Add(adminTour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adminTour);
        }

        // GET: AdminTours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminTour adminTour = db.AdminTours.Find(id);
            if (adminTour == null)
            {
                return HttpNotFound();
            }
            return View(adminTour);
        }

        // POST: AdminTours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tour_Num,Tour_Name,Tour_Duration,LocationFrom,LocationTO,TourDate,TourStartTime,TourName,Price,Deposit")] AdminTour adminTour)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(adminTour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adminTour);
        }

        // GET: AdminTours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminTour adminTour = db.AdminTours.Find(id);
            if (adminTour == null)
            {
                return HttpNotFound();
            }
            return View(adminTour);
        }

        // POST: AdminTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminTour adminTour = db.AdminTours.Find(id);
            db.AdminTours.Remove(adminTour);
            db.SaveChanges();
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
