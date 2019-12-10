using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class LoginTokenDTO
    {
        public DateTime DataCriacao { get; set; }
        public string Token { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}
