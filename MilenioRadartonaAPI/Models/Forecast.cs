using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AWSLambdaGetTempo.Model
{
    [DataContract]
    public class Forecast
    {
        [DataMember(Name = "latitude")]
        public float Latitude { get; set; }

        [DataMember(Name = "longitude")]
        public float Longitude { get; set; }

        [DataMember(Name = "timezone")]
        public string TimeZone { get; set; }

        [DataMember(Name = "offset")]
        public double TimeZoneOffset { get; set; }

        [DataMember(Name = "currently")]
        public CurrentDataPoint Currently { get; set; }

        [DataMember(Name = "minutely")]
        public MinutelyForecast Minutely { get; set; }

        [DataMember(Name = "hourly")]
        public HourlyForecast Hourly { get; set; }

        [DataMember(Name = "daily")]
        public DailyForecast Daily { get; set; }

        [DataMember(Name = "flags")]
        public Flags Flags { get; set; }

        [DataMember(Name = "alerts")]
        public IList<Alert> Alerts { get; set; }
    }
}
