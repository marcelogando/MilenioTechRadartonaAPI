using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class Caminhao
    {
        public Caminhao()
        {
        }

        public Caminhao(int caminhaoId, string placa)
        {
            CaminhaoId = caminhaoId;
            Placa = placa;
        }

        public int CaminhaoId { get; set; }
        public string Placa { get; set; }

    }
}
