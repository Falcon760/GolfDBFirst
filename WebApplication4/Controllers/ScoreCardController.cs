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
    public class ScoreCardController : Controller
    {
        private GolfDbEntities db = new GolfDbEntities();

        // GET: /ScoreCard/
        public ActionResult Index()
        {
            var scorecards = db.ScoreCards.Include(s => s.Player).Include(s => s.Round);
            return View(scorecards.ToList());
        }

        // GET: /ScoreCard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreCard scorecard = db.ScoreCards.Find(id);
            if (scorecard == null)
            {
                return HttpNotFound();
            }
            return View(scorecard);
        }

        // GET: /ScoreCard/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "LastName");
            ViewBag.RoundId = new SelectList(db.Rounds, "Id", "Name");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,TotalScore,PlayerId,RoundId")] ScoreCard scorecard)
        {
            if (ModelState.IsValid)
            {
                db.ScoreCards.Add(scorecard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(db.Players, "Id", "LastName", scorecard.PlayerId);
            ViewBag.RoundId = new SelectList(db.Rounds, "Id", "Name", scorecard.RoundId);
            return View(scorecard);
        }

        // GET: /ScoreCard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreCard scorecard = db.ScoreCards.Find(id);
            if (scorecard == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "LastName", scorecard.PlayerId);
            ViewBag.RoundId = new SelectList(db.Rounds, "Id", "Name", scorecard.RoundId);
            return View(scorecard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,TotalScore,PlayerId,RoundId")] ScoreCard scorecard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scorecard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(db.Players, "Id", "LastName", scorecard.PlayerId);
            ViewBag.RoundId = new SelectList(db.Rounds, "Id", "Name", scorecard.RoundId);
            return View(scorecard);
        }

        // GET: /ScoreCard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreCard scorecard = db.ScoreCards.Find(id);
            if (scorecard == null)
            {
                return HttpNotFound();
            }
            return View(scorecard);
        }

        // POST: /ScoreCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
//            [HttpPost, ActionName("Delete")]
//[ValidateAntiForgeryToken]
//public ActionResult DeleteConfirmed(int id)
//{ Instructor instructor = db.Instructors 
//    .Include(i => i.OfficeAssignment) 
//    .Where(i => i.ID == id) .Single();
//instructor.OfficeAssignment = null;
//db.Instructors.Remove(instructor);
//var department = db.Departments 
            //.Where(d => d.InstructorID == id) 
            //.SingleOrDefault(); 
            //if (department != null) 
            //{ department.InstructorID = null; }
//db.SaveChanges();
//return RedirectToAction("Index");
//}




            
            ScoreCard scorecard = db.ScoreCards.Find(id);
            db.ScoreCards.Remove(scorecard);
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
