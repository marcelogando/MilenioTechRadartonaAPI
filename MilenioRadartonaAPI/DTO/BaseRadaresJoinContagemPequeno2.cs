using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class BaseRadaresJoinContagemPequenoDTO2
    {
        public BaseRadaresJoinContagemPequenoDTO2()
        {
        }

        public BaseRadaresJoinContagemPequenoDTO2(int codigo, string dataHora, int contagem, int autuacoes, int placas, int tipoVeiculo)
        {
            Codigo = codigo;
            DataHora = dataHora;
            Contagem = contagem;
            Autuacoes = autuacoes;
            Placas = placas;
            TipoVeiculo = tipoVeiculo;
        }

        public int Codigo { get; set; }
        public string DataHora { get; set; }
        public int Contagem { get; set; }
        public int Autuacoes { get; set; }
        public int Placas { get; set; }
        public int TipoVeiculo { get; set; }

    }
}
