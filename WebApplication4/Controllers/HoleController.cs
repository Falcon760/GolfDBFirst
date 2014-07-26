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
    public class HoleController : Controller
    {
        private GolfDbEntities db = new GolfDbEntities();

        // GET: /Hole/
        public ActionResult Index()
        {
            var holes = db.Holes.Include(h => h.Course);
            return View(holes.ToList());
        }

        // GET: /Hole/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hole hole = db.Holes.Find(id);
            if (hole == null)
            {
                return HttpNotFound();
            }
            return View(hole);
        }

        // GET: /Hole/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            return View();
        }

        // POST: /Hole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Number,Par,Type,TotalYards,YardsFromBlue,YardsFromWhite,YardsFromRed,CourseId")] Hole hole)
        {
            if (ModelState.IsValid)
            {
                db.Holes.Add(hole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", hole.CourseId);
            return View(hole);
        }

        // GET: /Hole/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hole hole = db.Holes.Find(id);
            if (hole == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", hole.CourseId);
            return View(hole);
        }

        // POST: /Hole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Number,Par,Type,TotalYards,YardsFromBlue,YardsFromWhite,YardsFromRed,CourseId")] Hole hole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", hole.CourseId);
            return View(hole);
        }

        // GET: /Hole/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hole hole = db.Holes.Find(id);
            if (hole == null)
            {
                return HttpNotFound();
            }
            return View(hole);
        }

        // POST: /Hole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hole hole = db.Holes.Find(id);
            db.Holes.Remove(hole);
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
