using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class RadaresTipoEnquadramento: Base
    {
        public RadaresTipoEnquadramento()
        {
        }

        public RadaresTipoEnquadramento(string enquadramento, string jsonRetorno)
        {
            Enquadramento = enquadramento;
            JsonRetorno = jsonRetorno;
        }

        public string Enquadramento { get; set; }

        [Column(TypeName = "json")]
        public string JsonRetorno { get; set; }



    }
}
