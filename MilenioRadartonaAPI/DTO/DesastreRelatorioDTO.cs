using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Relatorios
{
    public class DesastreRelatorioDTO
    {
        public DesastreRelatorioDTO()
        {
        }

        public DesastreRelatorioDTO(string nomeRua, string tipoRua, string tipoDesastre, DateTime dataHora, string cep)
        {
            NomeRua = nomeRua;
            TipoRua = tipoRua;
            TipoDesastre = tipoDesastre;
            DataHora = dataHora;
            Cep = cep;
        }

        public string NomeRua { get; set; }
        public string TipoRua { get; set; }
        public string TipoDesastre { get; set; }
        public DateTime DataHora { get; set; }
        public string Cep { get; set; }



    }
}
