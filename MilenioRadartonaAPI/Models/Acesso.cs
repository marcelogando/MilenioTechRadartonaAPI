using MilenioRadartonaAPI.DTO;
using System.ComponentModel.DataAnnotations;

namespace MilenioRadartonaAPI.Models
{
    public class Acesso
    {

        public int AcessoId { get; set; }

        [Required]
        public string Url { get; set; }
        
        public RelatorioReq Relatorio { get; set; }

        public string Descricao { get; set; }

    }
}