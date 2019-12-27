using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class MensagemDTO
    {
        public MensagemDTO()
        {
        }

        public MensagemDTO(string corpo, string linkAudio, DateTime dataHora, int caminhaoId, int usuarioId, string sender)
        {
            Corpo = corpo;
            LinkAudio = linkAudio;
            DataHora = dataHora;
            CaminhaoId = caminhaoId;
            UsuarioId = usuarioId;
            Sender = sender;
        }

        public MensagemDTO(string corpo, int caminhaoId, int usuarioId, string sender)
        {
            Corpo = corpo;
            CaminhaoId = caminhaoId;
            UsuarioId = usuarioId;
            Sender = sender;
        }


        public string Corpo { get; set; }
        public string LinkAudio { get; set; }
        public DateTime DataHora { get; set; }
        public int CaminhaoId { get; set; }
        public int UsuarioId { get; set; }
        public string Sender { get; set; }

    }
}
