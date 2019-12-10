using System.Runtime.Serialization;

namespace MilenioRadartonaAPI.Models
{
    [DataContract]
    public class Base
    {

        [DataMember]
        public int Id { get; set; }

    }
}