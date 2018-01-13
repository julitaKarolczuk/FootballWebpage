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
    public class RefereesController : Controller
    {
        private Entities db = new Entities();

        // GET: Referees
        public ActionResult Index()
        {
            return View(db.Referee.ToList());
        }

        // GET: Referees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referee referee = db.Referee.Find(id);
            if (referee == null)
            {
                return HttpNotFound();
            }
            return View(referee);
        }

        // GET: Referees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Referees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] Referee referee)
        {
            if (ModelState.IsValid)
            {
                db.Referee.Add(referee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(referee);
        }

        // GET: Referees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referee referee = db.Referee.Find(id);
            if (referee == null)
            {
                return HttpNotFound();
            }
            return View(referee);
        }

        // POST: Referees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] Referee referee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(referee);
        }

        // GET: Referees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referee referee = db.Referee.Find(id);
            if (referee == null)
            {
                return HttpNotFound();
            }
            return View(referee);
        }

        // POST: Referees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Referee referee = db.Referee.Find(id);
            db.Referee.Remove(referee);
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
