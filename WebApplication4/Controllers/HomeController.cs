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
    public class HomeController : Controller
    {
        private GolfDbEntities db = new GolfDbEntities();

        public ActionResult Index()
        {
            //var combineds = db.PlayerScoreCards.Include(c => c.Player).Include(c => c.ScoreCard);
            //return View(combineds.ToList());
            //var combineds2 = from n in db.Players
            //                 select n;
            //return View(combineds2.ToList());
            //return View();

            //IQueryable<Combined> data = from p in db.Players
            //                            group p by p.Handicap into HandicapGroup
            //                            select new Combined() { Handicap = HandicapGroup.Key, PlayerCount = HandicapGroup.Count() };
            //return View(data.ToList());
           
            var scorecards = db.ScoreCards.Include(s => s.Player).Include(s => s.Round);
            return View(scorecards.ToList());


         }




        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}