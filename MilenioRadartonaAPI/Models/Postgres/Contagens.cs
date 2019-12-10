using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models.Postgres
{
    public class Contagens : Base
    {
        public Contagens()
        {

        }

        public Int64 Id { get; set; }
        public DateTime DataHora { get; set; }
        public int Localidade { get; set; }
        public int Tipo { get; set; }
        public int Contagem { get; set; }
        public int Autuacoes { get; set; }
        public int Placas { get; set; }
    }
}
