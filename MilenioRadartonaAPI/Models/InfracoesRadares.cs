using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class InfracoesRadares: Base
    {

        public string DataConsulta { get; set; }

        public string Radares { get; set; }

        [Column(TypeName = "json")]
        public string JsonRetorno { get; set; }


    }
}
