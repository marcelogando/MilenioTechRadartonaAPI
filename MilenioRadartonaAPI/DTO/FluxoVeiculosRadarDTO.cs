using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class FluxoVeiculosRadarDTO
    {
        public int codigo { get; set; }
        public DateTime data_hora { get; set; }
        public int tipo_veiculo { get; set; }
        public int contagem { get; set; }
        public int autuacoes { get; set; }
        public int placas { get; set; }
        public int qtde_faixas { get; set; }
        public string velocidade { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string bairro { get; set; }
    }
}
