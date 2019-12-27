using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models.Postgres
{
    public class LocalizacaoRadares:Base
    {
        public LocalizacaoRadares(string jsonRetorno)
        {
            JsonRetorno = jsonRetorno;
        }

        [Column(TypeName = "json")]
        public string JsonRetorno { get; set; }


    }
}
