using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class LoginOptimusDTO
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    
        [Required]
        public string Senha { get; set; }


    }
}
