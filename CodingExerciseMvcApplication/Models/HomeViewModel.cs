using System.Collections.Generic;
using DataProviderLibrary;

namespace CodingExerciseMvcApplication.Models
{
    public class HomeViewModel
    {
        private readonly IDataProvider _dataProvider = new DataProvider();

        private IList<Year> _years;
        public IList<Year> Years {
            get { return _years ?? (_years = _dataProvider.GetYearList()); }
        }

        public string SelectedYear { get; set; }

        private IList<Station> _station;
        public IList<Station> Stations
        {
            get { return _station ?? (_station = _dataProvider.GetStationList()); }
        }

        public string SelectedStation { get; set; }

        private IList<FeedBack> _feedbacks;
        public IList<FeedBack> Feedbacks
        {
            get { return _feedbacks ?? (_feedbacks = _dataProvider.GetFeedBackList()); }
        }

        public bool FilteredByStation { get; set; }

        public string ChartType { get; set; }
    }
}