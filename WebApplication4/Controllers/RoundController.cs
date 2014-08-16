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
    public class RoundController : Controller
    {
        private GolfDbEntities db = new GolfDbEntities();
        //Search Action method created by Me

        public ActionResult Search(string SearchBox)
        {
            var items = from t in db.Rounds select t;
            DateTime searchDate;
            if(!String.IsNullOrEmpty(SearchBox))
            {
                bool isDateSearch = DateTime.TryParse(SearchBox, out searchDate);
                if (isDateSearch)
                {

                    items = items.Where(s => s.RoundDate.Equals(searchDate));
                }

                else
                {
                    items = from t in db.Rounds
                             where
                                 t.Name.Contains(SearchBox)
                                 || t.Course.Name.Contains(SearchBox)
                             select t;

                }
            }
            return View("Index", items.ToList());
        }
  

        // GET: /Round/
        public ActionResult Index()
        {
            var rounds = db.Rounds.Include(r => r.Course);
            return View(rounds.ToList());
        }

        // GET: /Round/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            return View(round);
        }

        // GET: /Round/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            return View();
        }

        // POST: /Round/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,RoundDate,Name,CourseId,Comments")] Round round)
        {
            if (ModelState.IsValid)
            {
                db.Rounds.Add(round);
                db.SaveChanges();
                return RedirectToAction("Create","ScoreCard");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", round.CourseId);
            return View(round);
        }

        // GET: /Round/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", round.CourseId);
            return View(round);
        }

        // POST: /Round/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,RoundDate,Name,CourseId,Comments")] Round round)
        {
            if (ModelState.IsValid)
            {
                db.Entry(round).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", round.CourseId);
            return View(round);
        }

        // GET: /Round/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Round round = db.Rounds.Find(id);
            if (round == null)
            {
                return HttpNotFound();
            }
            return View(round);
        }

        // POST: /Round/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Round round = db.Rounds.Find(id);
            db.Rounds.Remove(round);
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
