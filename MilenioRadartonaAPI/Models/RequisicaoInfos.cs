using System;
using System.Collections.Generic;

namespace MilenioRadartonaAPI.Models
{
    public class RequisicaoInfos
    {

        public int RequisicaoInfosId { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public IList<DiasAutenticados> DiasAutenticados { get; set; }
        public int DiasAutenticadosId { get; set; }

        public int QtdReqFeitasNoDia { get; set; }

        public int QtdReqDiaMax { get; set; } // chumba 1000 em todos

        public IList<Acesso> Acessos { get; set; }
        public int AcessoId { get; set; }

    }
}
