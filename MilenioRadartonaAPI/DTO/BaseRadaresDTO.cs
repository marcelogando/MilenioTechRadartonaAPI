using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class BaseRadaresDTO
    {
        public int lote { get; set; }
        public string codigo { get; set; }
        public string endereco { get; set; }
        public string sentido { get; set; }
        public string referencia { get; set; }
        public string tipoEquipamento { get; set; }
        public string enquadramento { get; set; }
        public int? qtdeFaixas { get; set; }
        public string dataPublicacao { get; set; }
        public string velocidade { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string bairro { get; set; }
    }
}
