using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataProviderLibrary
{
    public interface IDataProvider
    {
        IList<Year> GetYearList();
        IList<Station> GetStationList();
        IList<FeedBack> GetFeedBackList();

    }
}
