using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SBDProject.Models;

namespace SBDProject.Controllers
{
    public class RefereeSqadsController : Controller
    {
        private Entities db = new Entities();

        // GET: RefereeSqads
        public ActionResult Index()
        {
            var refereeSqad = db.RefereeSqad.Include(r => r.Appointment).Include(r => r.Referee).Include(r => r.RefereeType);
            return View(refereeSqad.ToList());
        }

        // GET: RefereeSqads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefereeSqad refereeSqad = db.RefereeSqad.Find(id);
            if (refereeSqad == null)
            {
                return HttpNotFound();
            }
            return View(refereeSqad);
        }

        // GET: RefereeSqads/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id");
            ViewBag.RefereeId = new SelectList(db.Referee, "Id", "FirstName");
            ViewBag.RefereeTypeId = new SelectList(db.RefereeType, "Id", "Name");
            return View();
        }

        // POST: RefereeSqads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentId,RefereeId,RefereeTypeId")] RefereeSqad refereeSqad)
        {
            if (ModelState.IsValid)
            {
                db.RefereeSqad.Add(refereeSqad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id", refereeSqad.AppointmentId);
            ViewBag.RefereeId = new SelectList(db.Referee, "Id", "FirstName", refereeSqad.RefereeId);
            ViewBag.RefereeTypeId = new SelectList(db.RefereeType, "Id", "Name", refereeSqad.RefereeTypeId);
            return View(refereeSqad);
        }

        // GET: RefereeSqads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefereeSqad refereeSqad = db.RefereeSqad.Find(id);
            if (refereeSqad == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id", refereeSqad.AppointmentId);
            ViewBag.RefereeId = new SelectList(db.Referee, "Id", "FirstName", refereeSqad.RefereeId);
            ViewBag.RefereeTypeId = new SelectList(db.RefereeType, "Id", "Name", refereeSqad.RefereeTypeId);
            return View(refereeSqad);
        }

        // POST: RefereeSqads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentId,RefereeId,RefereeTypeId")] RefereeSqad refereeSqad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refereeSqad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id", refereeSqad.AppointmentId);
            ViewBag.RefereeId = new SelectList(db.Referee, "Id", "FirstName", refereeSqad.RefereeId);
            ViewBag.RefereeTypeId = new SelectList(db.RefereeType, "Id", "Name", refereeSqad.RefereeTypeId);
            return View(refereeSqad);
        }

        // GET: RefereeSqads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefereeSqad refereeSqad = db.RefereeSqad.Find(id);
            if (refereeSqad == null)
            {
                return HttpNotFound();
            }
            return View(refereeSqad);
        }

        // POST: RefereeSqads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RefereeSqad refereeSqad = db.RefereeSqad.Find(id);
            db.RefereeSqad.Remove(refereeSqad);
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
