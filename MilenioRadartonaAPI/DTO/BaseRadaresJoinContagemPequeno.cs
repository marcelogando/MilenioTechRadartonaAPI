using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class BaseRadaresJoinContagemPequenoDTO
    {
        public BaseRadaresJoinContagemPequenoDTO()
        {
        }

        public BaseRadaresJoinContagemPequenoDTO(int codigo, string data_hora, int contagem, int autuacoes, int placas)
        {
            Codigo = codigo;
            this.data_hora = data_hora;
            Contagem = contagem;
            Autuacoes = autuacoes;
            Placas = placas;
        }

        public int Codigo { get; set; }
        public string data_hora { get; set; }
        public int Contagem { get; set; }
        public int Autuacoes { get; set; }
        public int Placas { get; set; }

    }
}
