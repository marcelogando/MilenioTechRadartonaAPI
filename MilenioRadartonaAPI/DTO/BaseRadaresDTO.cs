using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class BaseRadaresDTO
    {
        public int Lote { get; set; }
        public string Codigo { get; set; }
        public string Endereco { get; set; }
        public string Sentido { get; set; }
        public string Referencia { get; set; }
        public string TipoEquipamento { get; set; }
        public string Enquadramento { get; set; }
        public int? QtdeFaixas { get; set; }
        public string DataPublicacao { get; set; }
        public string Velocidade { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Bairro { get; set; }
    }
}
