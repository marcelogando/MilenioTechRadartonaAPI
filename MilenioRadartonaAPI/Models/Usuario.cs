using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class Usuario
    {

        public int UsuarioId { get; set; }

        public Chave Chave { get; set; }

        public IList<RequisicaoInfos> ReqInfos { get; set; }
        public int ReqInfosId { get; set; }


        public string TipoUsuario { get; set; }
        public string Celular { get; set; }
        public bool Bloqueado { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime CriacaoDeConta { get; set; }
        public DateTime UltimaMudancaDeSenha { get; set; }
        

    }
}
