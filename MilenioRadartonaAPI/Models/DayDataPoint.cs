using System;
using System.Runtime.Serialization;

namespace AWSLambdaGetTempo.Model
{

    [DataContract]
    public class DayDataPoint
    {
        [DataMember]
        private int time;

        [DataMember]
        private int sunriseTime;

        [DataMember]
        private int sunsetTime;

        [DataMember]
        private int precipIntensityMaxTime;

        [DataMember]
        private int temperatureMaxTime;

        [Obsolete]
        [DataMember]
        private int temperatureMinTime;

        [Obsolete]
        [DataMember]
        private int apparentTemperatureMinTime;

        [Obsolete]
        [DataMember]
        private int apparentTemperatureMaxTime;

        [DataMember]
        private int apparentTemperatureLowTime;

        [DataMember]
        private int apparentTemperatureHighTime;

        [DataMember]
        private int temperatureLowTime;

        [DataMember]
        private int temperatureHighTime;

        [DataMember]
        private int uvIndexTime;

        [DataMember]
        private int windGustTime;

        public DateTimeOffset Time { get; set; }

        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        [DataMember(Name = "icon")]
        public string Icon { get; set; }

        public DateTimeOffset SunsetTime { get; set; }


        public DateTimeOffset SunriseTime { get; set; }

        [DataMember(Name = "moonPhase")]
        public float MoonPhase { get; set; }

        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }

        [DataMember(Name = "precipIntensityMax")]
        public float MaxPrecipitationIntensity { get; set; }

		[DataMember(Name = "precipType")]
		public string PrecipitationType { get; set; }

		public DateTimeOffset MaxPrecipitationIntensityTime { get; set; }

            
        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }

        [DataMember(Name = "precipAccumulation")]
        public float PrecipitationAccumulation { get; set; }

        [DataMember(Name = "apparentTemperatureLow")]
        public float ApparentLowTemperature { get; set; }

        public DateTimeOffset ApparentLowTemperatureTime { get; set; }


        [DataMember(Name = "apparentTemperatureHigh")]
        public float ApparentHighTemperature { get; set; }

        public DateTimeOffset ApparentHighTemperatureTime { get; set; }

        [DataMember(Name = "temperatureLow")]
        public float LowTemperature { get; set; }

        public DateTimeOffset LowTemperatureTime { get; set; }

        [DataMember(Name = "temperatureHigh")]
        public float HighTemperature { get; set; }

        public DateTimeOffset HighTemperatureTime { get; set; }
 
        [DataMember(Name = "temperature")]
        public float Temperature { get; set; }

        [Obsolete("Deprecated - consider using LowTemperature instead.")]
        [DataMember(Name = "temperatureMin")]
        public float MinTemperature { get; set; }

        [Obsolete("Deprecated - consider using LowTemperatureTime instead.")]
        public DateTimeOffset MinTemperatureTime { get; set; }

        [Obsolete("Deprecated - consider using HighTemperature instead.")]
        [DataMember(Name = "temperatureMax")]
        public float MaxTemperature { get; set; }

        [Obsolete("Deprecated - consider using HighTemperatureTime instead.")]
        public DateTimeOffset MaxTemperatureTime { get; set; }

        [Obsolete("Deprecated - consider using ApparentLowTemperature instead.")]
        [DataMember(Name = "apparentTemperatureMin")]
        public float ApparentMinTemperature { get; set; }

        [Obsolete("Deprecated - consider using ApparentLowTemperatureTime instead.")]
        public DateTimeOffset ApparentMinTemperatureTime { get; set; }

        [Obsolete("Deprecated - consider using ApparentHighTemperature instead.")]
        [DataMember(Name = "apparentTemperatureMax")]
        public float ApparentMaxTemperature { get; set; }

        [Obsolete("Deprecated - consider using ApparentHighTemperatureTime instead.")]
        public DateTimeOffset ApparentMaxTemperatureTime { get; set; }

        [DataMember(Name = "dewPoint")]
        public float DewPoint { get; set; }

        [DataMember(Name = "humidity")]
        public float Humidity { get; set; }

        [DataMember(Name = "windSpeed")]
        public float WindSpeed { get; set; }

        [DataMember(Name = "windBearing")]
        public float WindBearing { get; set; }

        [DataMember(Name = "windGust")]
        public float WindGust { get; set; }

        public DateTimeOffset WindGustTime { get; set; }

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

        public DateTimeOffset UVIndexTime { get; set; }


    }
}
