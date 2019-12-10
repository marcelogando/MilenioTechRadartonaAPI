using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models.Postgres
{
    public class BaseRadares : Base
    {
        public BaseRadares()
        {
        }

        public int? lote { get; set; }
        public string codigo { get; set; }
        public string endereco { get; set; }
        public string sentido { get; set; }
        public string referencia { get; set; }
        public string tipo_equip { get; set; }
        public string enquadrame { get; set; }
        public int? qtde_fxs_f { get; set; }
        public string data_publi { get; set; }
        public string velocidade { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string bairro { get; set; }
    }
}
