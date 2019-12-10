using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilenioRadartonaAPI.Relatorios
{

    public class ImprudenciaRelatorioDTO
    {
        public ImprudenciaRelatorioDTO()
        {
        }

        public ImprudenciaRelatorioDTO(string nomeRua, string tipoRua, string cep, DateTime dataHora, string tipoImprudencia)
        {
            NomeRua = nomeRua;
            TipoRua = tipoRua;
            Cep = cep;
            DataHora = dataHora;
            TipoImprudencia = tipoImprudencia;
        }

        public string NomeRua { get; set; }
        public string TipoRua { get; set; }
        public string Cep { get; set; }
        public DateTime DataHora { get; set; }
        public string TipoImprudencia { get; set; }

    }
}
