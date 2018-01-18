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
    public class AppointmentsController : Controller
    {
        private Entities db = new Entities();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointment = db.Appointment.Include(a => a.Location).Include(a => a.Team).Include(a => a.Team1).Include(a=>a.RefereeSqad);
            return View(appointment.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(db.Location, "Id", "Name");
            ViewBag.TeamId1 = new SelectList(db.Team, "Id", "Name");
            ViewBag.TeamId2 = new SelectList(db.Team, "Id", "Name");
            ViewBag.Referee1 = ViewBag.Referee2 = ViewBag.Referee3 = ViewBag.Referee4 = new SelectList(db.Referee.Select(r => new { r.Id, FirstNAme = r.FirstName + " " + r.LastName }), "Id", "FirstName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamId1,TeamId2,TournamentId,AppointmentDate,LocationId,Attendance")] Appointment appointment, int referee1, int referee2, int referee3, int referee4)
        {
            if (ModelState.IsValid)
            {
                db.Appointment.Add(appointment);
                db.SaveChanges();
            }

            var ref1 = new RefereeSqad
            {
                AppointmentId = appointment.Id,
                RefereeId = referee1,
                RefereeTypeId = 1
            };

            var ref2 = new RefereeSqad
            {
                AppointmentId = appointment.Id,
                RefereeId = referee2,
                RefereeTypeId = 2
            };

            var ref3 = new RefereeSqad
            {
                AppointmentId = appointment.Id,
                RefereeId = referee3,
                RefereeTypeId = 3
            };

            var ref4 = new RefereeSqad
            {
                AppointmentId = appointment.Id,
                RefereeId = referee4,
                RefereeTypeId = 4
            };

            db.RefereeSqad.Add(ref1);
            db.RefereeSqad.Add(ref2);
            db.RefereeSqad.Add(ref3);
            db.RefereeSqad.Add(ref4);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Location, "Id", "Name", appointment.LocationId);
            ViewBag.TeamId1 = new SelectList(db.Team, "Id", "Name", appointment.TeamId1);
            ViewBag.TeamId2 = new SelectList(db.Team, "Id", "Name", appointment.TeamId2);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamId1,TeamId2,TournamentId,AppointmentDate,LocationId,Attendance")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(db.Location, "Id", "Name", appointment.LocationId);
            ViewBag.TeamId1 = new SelectList(db.Team, "Id", "Name", appointment.TeamId1);
            ViewBag.TeamId2 = new SelectList(db.Team, "Id", "Name", appointment.TeamId2);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointment.Find(id);
            db.Appointment.Remove(appointment);
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
