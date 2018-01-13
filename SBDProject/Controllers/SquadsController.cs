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
    public class SquadsController : Controller
    {
        private Entities db = new Entities();

        // GET: Squads
        public ActionResult Index()
        {
            var squad = db.Squad.Include(s => s.Appointment).Include(s => s.Position);
            return View(squad.ToList());
        }

        // GET: Squads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squad squad = db.Squad.Find(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            return View(squad);
        }

        // GET: Squads/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id");
            ViewBag.PositionId = new SelectList(db.Position, "Id", "Name");
            return View();
        }

        // POST: Squads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AppointmentId,PositionId")] Squad squad)
        {
            if (ModelState.IsValid)
            {
                db.Squad.Add(squad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id", squad.AppointmentId);
            ViewBag.PositionId = new SelectList(db.Position, "Id", "Name", squad.PositionId);
            return View(squad);
        }

        // GET: Squads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squad squad = db.Squad.Find(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id", squad.AppointmentId);
            ViewBag.PositionId = new SelectList(db.Position, "Id", "Name", squad.PositionId);
            return View(squad);
        }

        // POST: Squads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AppointmentId,PositionId")] Squad squad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(squad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id", squad.AppointmentId);
            ViewBag.PositionId = new SelectList(db.Position, "Id", "Name", squad.PositionId);
            return View(squad);
        }

        // GET: Squads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Squad squad = db.Squad.Find(id);
            if (squad == null)
            {
                return HttpNotFound();
            }
            return View(squad);
        }

        // POST: Squads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Squad squad = db.Squad.Find(id);
            db.Squad.Remove(squad);
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
