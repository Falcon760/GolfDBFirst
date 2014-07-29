using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4;

namespace WebApplication4.Controllers
{
    public class CombinedController : Controller
    {
        private GolfDbEntities db = new GolfDbEntities();

        // GET: /Combined/
        public ActionResult Index()
        {
            var combineds = db.Combineds.Include(c => c.Player).Include(c => c.ScoreCard);
            return View(combineds.ToList());
        }

        // GET: /Combined/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combined combined = db.Combineds.Find(id);
            if (combined == null)
            {
                return HttpNotFound();
            }
            return View(combined);
        }

        // GET: /Combined/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Players, "Id", "LastName");
            ViewBag.Id = new SelectList(db.ScoreCards, "Id", "Name");
            return View();
        }

        // POST: /Combined/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id")] Combined combined)
        {
            if (ModelState.IsValid)
            {
                db.Combineds.Add(combined);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Players, "Id", "LastName", combined.Id);
            ViewBag.Id = new SelectList(db.ScoreCards, "Id", "Name", combined.Id);
            return View(combined);
        }

        // GET: /Combined/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combined combined = db.Combineds.Find(id);
            if (combined == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Players, "Id", "LastName", combined.Id);
            ViewBag.Id = new SelectList(db.ScoreCards, "Id", "Name", combined.Id);
            return View(combined);
        }

        // POST: /Combined/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id")] Combined combined)
        {
            if (ModelState.IsValid)
            {
                db.Entry(combined).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Players, "Id", "LastName", combined.Id);
            ViewBag.Id = new SelectList(db.ScoreCards, "Id", "Name", combined.Id);
            return View(combined);
        }

        // GET: /Combined/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combined combined = db.Combineds.Find(id);
            if (combined == null)
            {
                return HttpNotFound();
            }
            return View(combined);
        }

        // POST: /Combined/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Combined combined = db.Combineds.Find(id);
            db.Combineds.Remove(combined);
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
