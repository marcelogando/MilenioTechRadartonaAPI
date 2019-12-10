using System;
using System.Collections.Generic;
using System.Text;

namespace MilenioRadartonaAPI.Relatorios
{
    public class AcidenteRelatorioDTO
    {
        public AcidenteRelatorioDTO()
        {
        }

        public AcidenteRelatorioDTO(int intensidade, string nomeRua, string tipoRua, string cep, DateTime dataHora)
        {
            Intensidade = intensidade;
            NomeRua = nomeRua;
            TipoRua = tipoRua;
            Cep = cep;
            DataHora = dataHora;
        }

        public int Intensidade { get; set; }

        public string NomeRua { get; set; }

        public string TipoRua { get; set; }

        public string Cep { get; set; }

        public DateTime DataHora { get; set; }




    }
}
