using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models.Postgres
{
    public class Trajetos : Base
    {
        public Trajetos()
        {

        }

        public Int64 Id { get; set; }
        public int ViagemId { get; set; }
        public int Tipo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public int Origem { get; set; }
        public int Destino { get; set; }
        public int V0 { get; set; }
        public int V1 { get; set; }
    }
}
