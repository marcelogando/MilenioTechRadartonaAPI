using MilenioRadartonaAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilenioRadartonaAPI.Relatorios
{

    public class AcidenteRelatorio : Base
    {

        public int Intensidade { get; set; }

        public string NomeRua { get; set; }

        public string TipoRua { get; set; }

        public string Cep { get; set; }

        public DateTime DataHora { get; set; }

    }
}
