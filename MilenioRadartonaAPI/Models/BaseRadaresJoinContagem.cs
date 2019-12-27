using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models
{
    public class BaseRadaresJoinContagemDTO
    {
        public BaseRadaresJoinContagemDTO()
        {
        }

        public BaseRadaresJoinContagemDTO(int codigo, string data_hora, int tipo, int contagem, int autuacoes, int placas, int qtde_faixas, string velocidade, double lat, double lon, string bairro)
        {
            Codigo = codigo;
            this.data_hora = data_hora;
            Tipo = tipo;
            Contagem = contagem;
            Autuacoes = autuacoes;
            Placas = placas;
            this.qtde_faixas = qtde_faixas;
            Velocidade = velocidade;
            Lat = lat;
            Lon = lon;
            Bairro = bairro;
        }

        public int Codigo { get; set; }
        public string data_hora { get; set; }
        public int Tipo { get; set; }
        public int Contagem { get; set; }
        public int Autuacoes { get; set; }
        public int Placas { get; set; }
        public int qtde_faixas { get; set; }
        public string Velocidade { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Bairro { get; set; }

    }
}
