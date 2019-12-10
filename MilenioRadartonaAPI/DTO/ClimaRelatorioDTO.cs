using System;
using System.Collections.Generic;
using System.Text;

namespace MilenioRadartonaAPI.Relatorios
{
    public class ClimaRelatorioDTO
    {
        public ClimaRelatorioDTO()
        {
        }

        public ClimaRelatorioDTO(double temperatura, double pressaoAtmosferica, double umidadeAr, double angulacaoVento, double velocidadeVento, int nivelNuvens, string resumoClima)
        {
            Temperatura = temperatura;
            PressaoAtmosferica = pressaoAtmosferica;
            UmidadeAr = umidadeAr;
            AngulacaoVento = angulacaoVento;
            VelocidadeVento = velocidadeVento;
            NivelNuvens = nivelNuvens;
            ResumoClima = resumoClima;
        }

        public double Temperatura { get; set; }

        public double PressaoAtmosferica { get; set; }

        public double UmidadeAr { get; set; }

        public double AngulacaoVento { get; set; }

        public double VelocidadeVento { get; set; }

        public int NivelNuvens { get; set; }

        public string ResumoClima { get; set; }




    }
}
