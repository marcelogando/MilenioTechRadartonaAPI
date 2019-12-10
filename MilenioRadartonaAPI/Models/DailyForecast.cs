using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AWSLambdaGetTempo.Model

{

    [DataContract]
    public class DailyForecast
    {
        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "data")]
        public IList<DayDataPoint> Days { get; set; }
    }
}
