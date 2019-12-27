using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class DistanciaViagem:Base
    {
        public DistanciaViagem()
        {
        }


        [Column(TypeName = "json")]
        public string JsonRetorno { get; set; }
        public int RadarInicial { get; set; }
        public int RadarFinal { get; set; }
    }
}
