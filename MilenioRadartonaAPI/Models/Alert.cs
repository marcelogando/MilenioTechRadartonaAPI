using System;
using System.Runtime.Serialization;

namespace AWSLambdaGetTempo.Model
{
    [DataContract]
    public class Alert
    {
        [DataMember]
        private int expires;

        [DataMember]
        private int time;

        [DataMember]
        private string severity;

        [DataMember(Name = "title")]
        public string Title { get; set; }

        public Severity Severity
        {
            get
            {
                return AlertSeverity.FromString(severity);
            }
        }

        public DateTimeOffset Time { get; set; }

        [DataMember(Name = "regions")]
        public string[] Regions { get; set; }

        public DateTimeOffset Expires { get; set;  }


        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "uri")]
        public string Uri { get; set; }
    }











}
