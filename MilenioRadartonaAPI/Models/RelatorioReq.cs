using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class RelatorioReq
    {        
        public int RelatorioReqId { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Evento { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public double Raio { get; set; }

    }
}
