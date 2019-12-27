using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class AcuraciaIdentificacaoRadares: Base
    {
        public AcuraciaIdentificacaoRadares()
        {
        }

        public AcuraciaIdentificacaoRadares(string dataConsulta, string radares, string jsonRetorno)
        {
            DataConsulta = dataConsulta;
            Radares = radares;
            JsonRetorno = jsonRetorno;
        }

        public string DataConsulta { get; set; }

        public string Radares { get; set; }

        [Column(TypeName = "json")]
        public string JsonRetorno { get; set; }


    }
}
