using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models.Postgres
{
    public class Viagens : Base
    {
        public Viagens()
        {

        }

        public Int64 Id { get; set; }
        public int Inicio { get; set; }
        public DateTime DataInicio { get; set; }
        public int Final { get; set; }
        public DateTime DataFinal { get; set; }
        public int Tipo { get; set; }
    }
}
