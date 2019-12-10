using System;
using System.Runtime.Serialization;

namespace AWSLambdaGetTempo.Model
{
    [DataContract]
    public class MinuteDataPoint
    {
        [DataMember]
        private int time;

        public DateTimeOffset Time { get; set; }

        [DataMember(Name = "precipIntensity")]
        public float PrecipitationIntensity { get; set; }

        [DataMember(Name = "precipProbability")]
        public float PrecipitationProbability { get; set; }

		[DataMember(Name = "precipType")]
		public string PrecipitationType { get; set; }

















    }
}
