using System;
using System.Collections.Generic;

namespace MilenioRadartonaAPI.Models
{
    public class RequisicaoInfos
    {

        public int RequisicaoInfosId { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public DateTime DiaRequisicao { get; set; }

        public int QtdReqFeitasNoDia { get; set; }

        public int QtdReqDiaMax { get; set; } // chumba 1000 em todos


    }
}
