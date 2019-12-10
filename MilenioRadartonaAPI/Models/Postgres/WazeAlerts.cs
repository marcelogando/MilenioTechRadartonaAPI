using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models.Postgres
{
    public class WazeAlerts : Base
    {
        public WazeAlerts()
        {

        }


        public DateTime Pubdate { get; set; }
        public int Magvar { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Street { get; set; }
        public string Roadtype { get; set; }
        public int ReportRating { get; set; }
        public int Reliability { get; set; }
        public string LatLon { get;set; }
    }
}
