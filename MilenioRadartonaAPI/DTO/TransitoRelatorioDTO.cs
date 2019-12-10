using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilenioRadartonaAPI.Relatorios
{

    public class TransitoRelatorioDTO
    {
        public TransitoRelatorioDTO()
        {
        }

        public TransitoRelatorioDTO(string cep, string tipoRua, int intensidade, string nomeRua, DateTime dataHora)
        {
            Cep = cep;
            TipoRua = tipoRua;
            Intensidade = intensidade;
            NomeRua = nomeRua;
            DataHora = dataHora;
        }

        public string Cep { get; set; }

        public string TipoRua { get; set; }

        public int Intensidade { get; set; }

        public string NomeRua { get; set; }

        public DateTime DataHora { get; set; }



    }
}
