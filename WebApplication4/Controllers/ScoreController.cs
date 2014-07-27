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
    public class ScoreController : Controller
    {
        private GolfDbEntities db = new GolfDbEntities();

        // GET: /Score/
        public ActionResult Index()
        {
            var scores = db.Scores.Include(s => s.ScoreCard).Include(s => s.Hole);
            return View(scores.ToList());
        }

        // GET: /Score/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // GET: /Score/Create
        public ActionResult Create()
        {
            ViewBag.ScoreCardid = new SelectList(db.ScoreCards, "Id", "Name");
            ViewBag.Holeid = new SelectList(db.Holes, "Id", "_Name");
            return View();
        }

        // POST: /Score/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,ScoreCardid,Strokes,Holeid")] Score score)
        {
            if (ModelState.IsValid)
            {
                db.Scores.Add(score);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ScoreCardid = new SelectList(db.ScoreCards, "Id", "Name", score.ScoreCardid);
            ViewBag.Holeid = new SelectList(db.Holes, "Id", "_Name", score.Holeid);
            return View(score);
        }

        // GET: /Score/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            ViewBag.ScoreCardid = new SelectList(db.Rounds, "Id", "Name", score.ScoreCardid);
            ViewBag.Holeid = new SelectList(db.Holes, "Id", "_Name", score.Holeid);
            return View(score);
        }

        // POST: /Score/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,ScoreCardid,Strokes,Holeid")] Score score)
        {
            if (ModelState.IsValid)
            {
                db.Entry(score).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ScoreCardid = new SelectList(db.ScoreCards, "Id", "Name", score.ScoreCardid);
            ViewBag.Holeid = new SelectList(db.Holes, "Id", "_Name", score.Holeid);
            return View(score);
        }

        // GET: /Score/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: /Score/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Score score = db.Scores.Find(id);
            db.Scores.Remove(score);
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
