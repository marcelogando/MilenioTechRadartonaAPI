using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AWSLambdaGetTempo.Model
{
    [DataContract]
    public class Flags
    {
        [DataMember(Name = "sources")]
        public IList<string> Sources { get; set; }

        [DataMember(Name = "darksky-stations")]
        public IList<string> DarkSkyStations { get; set; } 

        [DataMember(Name = "datapoint-stations")]
        public IList<string> DataPointStations { get; set; } 

        [DataMember(Name = "isd-stations")]
        public IList<string> IsdStations { get; set; } 

        [DataMember(Name = "lamp-stations")]
        public IList<string> LampStations { get; set; } 

        [DataMember(Name = "metar-stations")]
        public IList<string> MetarStations { get; set; }

        [DataMember(Name = "madis-stations")]
        public IList<string> MadisStations { get; set; } 

        [DataMember(Name = "metno-license")]
        public string MetnoLicense { get; set; }

        [DataMember(Name = "units")]
        public string Units { get; set; }
    }
}
