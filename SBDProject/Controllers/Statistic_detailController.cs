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
    public class Statistic_detailController : Controller
    {
        private Entities db = new Entities();

        // GET: Statistic_detail
        public ActionResult Index()
        {
            var statistic_detail = db.Statistic_detail.Include(s => s.Player).Include(s => s.Statistic);
            return View(statistic_detail.ToList());
        }

        // GET: Statistic_detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statistic_detail statistic_detail = db.Statistic_detail.Find(id);
            if (statistic_detail == null)
            {
                return HttpNotFound();
            }
            return View(statistic_detail);
        }

        // GET: Statistic_detail/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName");
            ViewBag.StatisticId = new SelectList(db.Statistic, "Id", "Name");
            return View();
        }

        // POST: Statistic_detail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StatisticId,Time,PlayerId")] Statistic_detail statistic_detail)
        {
            if (ModelState.IsValid)
            {
                db.Statistic_detail.Add(statistic_detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName", statistic_detail.PlayerId);
            ViewBag.StatisticId = new SelectList(db.Statistic, "Id", "Name", statistic_detail.StatisticId);
            return View(statistic_detail);
        }

        // GET: Statistic_detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statistic_detail statistic_detail = db.Statistic_detail.Find(id);
            if (statistic_detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName", statistic_detail.PlayerId);
            ViewBag.StatisticId = new SelectList(db.Statistic, "Id", "Name", statistic_detail.StatisticId);
            return View(statistic_detail);
        }

        // POST: Statistic_detail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StatisticId,Time,PlayerId")] Statistic_detail statistic_detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statistic_detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(db.Player, "Id", "FirstName", statistic_detail.PlayerId);
            ViewBag.StatisticId = new SelectList(db.Statistic, "Id", "Name", statistic_detail.StatisticId);
            return View(statistic_detail);
        }

        // GET: Statistic_detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statistic_detail statistic_detail = db.Statistic_detail.Find(id);
            if (statistic_detail == null)
            {
                return HttpNotFound();
            }
            return View(statistic_detail);
        }

        // POST: Statistic_detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statistic_detail statistic_detail = db.Statistic_detail.Find(id);
            db.Statistic_detail.Remove(statistic_detail);
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
