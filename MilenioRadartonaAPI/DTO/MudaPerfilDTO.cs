using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.DTO
{
    public class MudaPerfilDTO
    {
        public MudaPerfilDTO()
        {
        }

        public MudaPerfilDTO(string nome, string celular)
        {
            Nome = nome;
            Celular = celular;
        }

        public string Nome { get; set; }
        public string Celular { get; set; }

    }
}
