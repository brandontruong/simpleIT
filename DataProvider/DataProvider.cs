using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace DataProviderLibrary
{


    public class DataProvider: IDataProvider
    {
        public IList<Year> GetYearList()
        {
            var data = File.ReadAllText(string.Format("{0}{1}", ConfigurationSettings.AppSettings["DataPath"], "testYears.dim"));

            return (List<Year>)Newtonsoft.Json.JsonConvert.DeserializeObject(data, typeof(List<Year>));
            
        }

        public IList<Station> GetStationList()
        {
            var data = File.ReadAllText(string.Format("{0}{1}", ConfigurationSettings.AppSettings["DataPath"], "testStations.dim"));

            return (List<Station>)Newtonsoft.Json.JsonConvert.DeserializeObject(data, typeof(List<Station>));
    
        }

        public IList<FeedBack> GetFeedBackList()
        {
            var result = new List<FeedBack>();
            var lines = File.ReadAllLines(string.Format("{0}{1}", ConfigurationSettings.AppSettings["DataPath"], "testFeedback.data"));

            var firstLine = true;

            var stations = new string[] {};
            foreach (var line in lines)
            {
                if (firstLine)
                {
                    stations = line.Split(',');
                    firstLine = false;

                }
                else
                {
                    var data = line.Split(',');
                    for (var i = 1; i < stations.Length; i++)
                    {
                        result.Add(new FeedBack { Year = data[0].Trim(), StationId = stations[i].Trim(), Data = int.Parse(data[i]) });
                    }
                }
            }

           return result;
        }
    }
}
