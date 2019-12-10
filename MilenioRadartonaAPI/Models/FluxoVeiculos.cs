using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class FluxoVeiculos
    {
        public int id { get; set; }
        public DateTime data_hora { get; set; }
        public int localidade { get; set; }
        public int tipo { get; set; }
        public int contagem { get; set; }
        public int autuacoes { get; set; }
        public int placas { get; set; }
        public int lote { get; set; }
        public string velocidade { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
}
