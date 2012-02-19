using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataProviderLibrary;

namespace CodingExerciseMvcApplication.Controllers
{
    public static class Helper
    {
        public static IList<FeedBack> GetFullData(this IList<FeedBack> feedBacks, IList<Station> stations)
        {
            foreach (var feedBack in feedBacks)
            {
                var firstOrDefault = stations.FirstOrDefault(s => s.Id == feedBack.StationId);
                if (firstOrDefault != null)
                    feedBack.StationLabel = firstOrDefault.Label;
            }
            return feedBacks;
        }
    }
}