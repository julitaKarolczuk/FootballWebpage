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
    public class LiguesController : Controller
    {
        private Entities db = new Entities();

        // GET: Ligues
        public ActionResult Index()
        {
            return View(db.Ligue.ToList());
        }

        // GET: Ligues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ligue ligue = db.Ligue.Find(id);
            if (ligue == null)
            {
                return HttpNotFound();
            }
            return View(ligue);
        }

        // GET: Ligues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ligues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Ligue ligue)
        {
            if (ModelState.IsValid)
            {
                db.Ligue.Add(ligue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ligue);
        }

        // GET: Ligues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ligue ligue = db.Ligue.Find(id);
            if (ligue == null)
            {
                return HttpNotFound();
            }
            return View(ligue);
        }

        // POST: Ligues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Ligue ligue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ligue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ligue);
        }

        // GET: Ligues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ligue ligue = db.Ligue.Find(id);
            if (ligue == null)
            {
                return HttpNotFound();
            }
            return View(ligue);
        }

        // POST: Ligues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ligue ligue = db.Ligue.Find(id);
            db.Ligue.Remove(ligue);
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
