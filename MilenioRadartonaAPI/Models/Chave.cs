using System;

namespace MilenioRadartonaAPI.Models
{
    public class Chave
    {
        public int ChaveId { get; set; }
        public string Token { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }


        public bool Authenticated { get; set; }

        public DateTime Created { get; set; }
        public DateTime Expiration { get; set; }

        public string Message { get; set; }



    }
}