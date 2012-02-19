using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using CodingExerciseMvcApplication.Models;

namespace CodingExerciseMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var viewModel = new HomeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel viewModel, string submitButton)
        {
            viewModel.FilteredByStation = string.Equals(submitButton, "Filter by station");
            Session.Add("HomeViewModel", viewModel);

            return View(viewModel);
        }

        public ActionResult GetChart()
        {
            var viewModel = Session["HomeViewModel"] as HomeViewModel;
          
            if (viewModel != null)
            {
                
                if (viewModel.FilteredByStation)
                {
                    var data = viewModel.Feedbacks.Where(f => f.StationId == viewModel.SelectedStation).ToList().GetFullData(viewModel.Stations);

                    var firstOrDefault = viewModel.Stations.FirstOrDefault(s => s.Id == viewModel.SelectedStation);
                    if (firstOrDefault != null)
                    {
                        var selectedStation =
                            firstOrDefault.Label;
                      
                        new Chart(width: 600, height: 400)
                                    .AddSeries("Default", viewModel.ChartType,
                                    xValue: data, xField: "Year",
                                    yValues: data, yFields: "Data")
                            .AddTitle(string.Format("Station {0}", selectedStation))
                        
                            .Write();
                        
                    }
                }
                else
                {

                    var data = viewModel.Feedbacks.Where(f => f.Year == viewModel.SelectedYear).ToList().GetFullData(viewModel.Stations);

                    new Chart(width: 600, height: 400)
                                    .AddSeries("Default", viewModel.ChartType,
                                    xValue: data, xField: "StationLabel",
                                    yValues: data, yFields: "Data")
                                    .AddTitle(string.Format("Year {0}", viewModel.SelectedYear))
                                    .Write();
                   
                }
               
            }

            return null;
        }
 
    }
}
