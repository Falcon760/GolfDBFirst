using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/
        public ActionResult Index()
        {
            DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
                .SetTitle(new Title() { Text = "Score by Hole"})
                .SetYAxis(new YAxis { Title = new YAxisTitle() { Text = "Score" } }
                
                )
                .SetXAxis(new XAxis
                            {
                                Title = new XAxisTitle() {Text = "Hole"},
                                Categories = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12","13","14","15","16","17","18" }
                            })
                .SetSeries(new Series
                            {
                                Name = "Player 1",
                                Data = new Data(new object[] { 2, 3, 4, 5, 5, 4, 3, 6, 5, 5, 6, 4,4,5,4,6,7, })
                            });


            return View(chart);
        }
    }
}
