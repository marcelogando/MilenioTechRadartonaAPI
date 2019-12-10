using MilenioRadartonaAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Relatorios
{

    public class DesastreRelatorio : Base
    {

        public string NomeRua { get; set; }
        public string TipoRua { get; set; }
        public string TipoDesastre { get; set; }
        public DateTime DataHora { get; set; }
        public string Cep { get; set; }


    }
}
