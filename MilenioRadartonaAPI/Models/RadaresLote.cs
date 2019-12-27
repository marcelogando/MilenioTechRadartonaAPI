using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class RadaresLote: Base
    {
        public RadaresLote()
        {
        }

        public RadaresLote(string zonaConcessao, string jsonRetorno)
        {
            ZonaConcessao = zonaConcessao;
            JsonRetorno = jsonRetorno;
        }

        public string ZonaConcessao { get; set; }


        [Column(TypeName = "json")]
        public string JsonRetorno { get; set; }



    }
}
