using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class LocalizacaoRadar
    {
        public int codigo { get; set; }
        public string endereco { get; set; }
        public string sentido { get; set; }
        public string referencia { get; set; }
        public string tipo_equip { get; set; }
        public string enquadrame { get; set; }
        public int qtde_fxs_f { get; set; }
        public DateTime data_publi { get; set; }
        public string velocidade { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
}
