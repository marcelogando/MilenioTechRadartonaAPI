using MilenioRadartonaAPI.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilenioRadartonaAPI.Relatorios
{

    public class ClimaRelatorio : Base
    {
        public double Temperatura { get; set; }
        public double PressaoAtmosferica { get; set; }
        public double UmidadeAr { get; set; }
        public double AngulacaoVento { get; set; }
        public double VelocidadeVento { get; set; }
        public int NivelNuvens { get; set; }
        public string ResumoClima { get; set; }

    }
}
