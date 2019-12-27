using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class BaseRadaresJoinContagemPequenoDTO3
    {
        public BaseRadaresJoinContagemPequenoDTO3()
        {
        }

        public BaseRadaresJoinContagemPequenoDTO3(int codigoRadar, string dataHora, int contagem, int autuacoes, int placas, int tipoVeiculo, double acuraciaIdentificacao)
        {
            CodigoRadar = codigoRadar;
            DataHora = dataHora;
            Contagem = contagem;
            Autuacoes = autuacoes;
            Placas = placas;
            TipoVeiculo = tipoVeiculo;
            AcuraciaIdentificacao = acuraciaIdentificacao;
        }

        public int CodigoRadar { get; set; }
        public string DataHora { get; set; }
        public int Contagem { get; set; }
        public int Autuacoes { get; set; }
        public int Placas { get; set; }
        public int TipoVeiculo { get; set; }
        public double AcuraciaIdentificacao { get; set; }

    }
}
