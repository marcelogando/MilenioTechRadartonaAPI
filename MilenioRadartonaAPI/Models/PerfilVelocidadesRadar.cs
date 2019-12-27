using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class PerfilVelocidadesRadar: Base
    {

        public int VelocidadeMin { get; set; }

        public int VelocidadeMax { get; set; }

        [Column(TypeName = "json")]
        public string JsonRetorno { get; set; }

    }
}
