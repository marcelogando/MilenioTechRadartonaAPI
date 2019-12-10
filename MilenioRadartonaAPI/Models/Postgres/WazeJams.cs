using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models.Postgres
{
    public class WazeJams : Base
    {
        public WazeJams()
        {

        }

        public DateTime Pubdate { get; set; }
        public decimal Speed { get; set; }
        public int Length { get; set; }
        public int Delay { get; set; }
        public string Street { get; set; }
        public string RoadType { get; set; }
        public string StartNode { get; set; }
        public string EndNode { get; set; }
        public int Level { get; set; }
        public string BlockingAlertUUID { get; set; }
        public string Polyline { get; set; }
    }
}
