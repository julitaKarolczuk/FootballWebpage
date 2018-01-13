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
    public class RefereeTypesController : Controller
    {
        private Entities db = new Entities();

        // GET: RefereeTypes
        public ActionResult Index()
        {
            return View(db.RefereeType.ToList());
        }

        // GET: RefereeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefereeType refereeType = db.RefereeType.Find(id);
            if (refereeType == null)
            {
                return HttpNotFound();
            }
            return View(refereeType);
        }

        // GET: RefereeTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RefereeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] RefereeType refereeType)
        {
            if (ModelState.IsValid)
            {
                db.RefereeType.Add(refereeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(refereeType);
        }

        // GET: RefereeTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefereeType refereeType = db.RefereeType.Find(id);
            if (refereeType == null)
            {
                return HttpNotFound();
            }
            return View(refereeType);
        }

        // POST: RefereeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] RefereeType refereeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refereeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(refereeType);
        }

        // GET: RefereeTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RefereeType refereeType = db.RefereeType.Find(id);
            if (refereeType == null)
            {
                return HttpNotFound();
            }
            return View(refereeType);
        }

        // POST: RefereeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RefereeType refereeType = db.RefereeType.Find(id);
            db.RefereeType.Remove(refereeType);
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
