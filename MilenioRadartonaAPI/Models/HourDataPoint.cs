using System;
using System.Runtime.Serialization;

namespace AWSLambdaGetTempo.Model
{
    [DataContract]
    public class HourDataPoint
    {
        [DataMember]
        private int time;

        public DateTimeOffset Time { get; set; }

        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }

        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }

		[DataMember(Name = "precipType")]
		public string PrecipitationType { get; set; }

        [DataMember(Name = "precipAccumulation")]
        public float PrecipitationAccumulation { get; set; }

		[DataMember(Name = "temperature")]
        public float Temperature { get; set; }

        [DataMember(Name = "apparentTemperature")]
        public float ApparentTemperature { get; set; }

        [DataMember(Name = "dewPoint")]
        public float DewPoint { get; set; }

        [DataMember(Name = "humidity")]
        public float Humidity { get; set; }

        [DataMember(Name = "windSpeed")]
        public float WindSpeed { get; set; }

        [DataMember(Name = "windBearing")]
        public float WindBearing { get; set; }

        [DataMember(Name = "visibility")]
        public float Visibility { get; set; }

        [DataMember(Name = "cloudCover")]
        public float CloudCover { get; set; }

        [DataMember(Name = "pressure")]
        public float Pressure { get; set; }

        [DataMember(Name = "ozone")]
        public float Ozone { get; set; }

        [DataMember(Name = "uvIndex")]
        public float UVIndex { get; set; }

        [DataMember(Name = "windGust")]
        public float WindGust { get; set; }
    }
}
