using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class Mensagem
    {
        public Mensagem()
        {
        }

        public Mensagem(int mensagemId, string corpo, string linkAudio, DateTime dataHora, Caminhao caminhao, int caminhaoId, Usuario usuario, int usuarioId)
        {
            MensagemId = mensagemId;
            Corpo = corpo;
            LinkAudio = linkAudio;
            DataHora = dataHora;
            Caminhao = caminhao;
            CaminhaoId = caminhaoId;
            Usuario = usuario;
            UsuarioId = usuarioId;
        }

        public int MensagemId { get; set; }
        public string Corpo { get; set; }
        public string LinkAudio { get; set; }
        public DateTime DataHora { get; set; }
        public Caminhao Caminhao { get; set; }
        public int CaminhaoId { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

    }
}

