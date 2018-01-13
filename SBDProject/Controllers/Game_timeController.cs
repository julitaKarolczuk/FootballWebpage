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
    public class Game_timeController : Controller
    {
        private Entities db = new Entities();

        // GET: Game_time
        public ActionResult Index()
        {
            var game_time = db.Game_time.Include(g => g.Appointment).Include(g => g.Player);
            return View(game_time.ToList());
        }

        // GET: Game_time/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_time game_time = db.Game_time.Find(id);
            if (game_time == null)
            {
                return HttpNotFound();
            }
            return View(game_time);
        }

        // GET: Game_time/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id");
            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName");
            return View();
        }

        // POST: Game_time/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerId,AppointmentId,TimeFrom,TimeTo")] Game_time game_time)
        {
            if (ModelState.IsValid)
            {
                db.Game_time.Add(game_time);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id", game_time.AppointmentId);
            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName", game_time.PlayerId);
            return View(game_time);
        }

        // GET: Game_time/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_time game_time = db.Game_time.Find(id);
            if (game_time == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id", game_time.AppointmentId);
            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName", game_time.PlayerId);
            return View(game_time);
        }

        // POST: Game_time/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerId,AppointmentId,TimeFrom,TimeTo")] Game_time game_time)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game_time).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentId = new SelectList(db.Appointment, "Id", "Id", game_time.AppointmentId);
            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName", game_time.PlayerId);
            return View(game_time);
        }

        // GET: Game_time/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game_time game_time = db.Game_time.Find(id);
            if (game_time == null)
            {
                return HttpNotFound();
            }
            return View(game_time);
        }

        // POST: Game_time/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game_time game_time = db.Game_time.Find(id);
            db.Game_time.Remove(game_time);
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
