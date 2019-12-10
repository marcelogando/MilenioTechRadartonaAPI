using MilenioRadartonaAPI.DTO;
using MilenioRadartonaAPI.Models;
using MilenioRadartonaAPI.Models.Postgres;
using MilenioRadartonaAPI.Relatorios;
using MilenioRadartonaAPI.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IRadartonaService
    {
        List<BaseRadaresDTO> GetRadaresTipoEnquadramento(string Enquadramento);
        List<BaseRadaresDTO> GetLocalizacaoRadares();
        List<BaseRadaresDTO> GetRadaresZonaConcessao(string ZonaConcessao);
        List<FluxoVeiculosRadarDTO> GetFluxoVeiculosRadares(string Radares, string DataConsulta);
        List<TipoVeiculosRadaresDTO> GetTipoVeiculosRadares(string Radares, string DataConsulta);
        List<InfracoesPorRadarDTO> GetInfracoesPorRadar(string Radares, string DataConsulta);
        List<AcuraciaIdentificacaoRadaresDTO> GetAcuraciaIdentificacaoRadares(string Radares, string DataConsulta);
        List<BaseRadaresDTO> GetPerfilVelocidadesRadar(int VelocidadeMin, int VelocidadeMax);
        List<TrajetosDTO> GetTrajetos(string DataConsulta, string Radares);
        List<VelocidadeMediaTrajetoDTO> GetVelocidadeMediaTrajeto(string DataConsulta, string Radares);
        List<ViagensDTO> GetViagens(string DataConsulta, string Radares);
        List<DistanciaViagemDTO> GetDistanciaViagem(string DataConsulta);
        Task LogRequest(string Usuario, string Endpoint, long TempoRequisicao);

        // ======= CSV =======
        byte[] GetLocalizacaoRadaresCSV();
        byte[] GetRadaresTipoEnquadramentoCSV(string Enquadramento);
        byte[] GetRadaresZonaConcessaoCSV(string ZonaConcessao);
        byte[] GetFluxoVeiculosRadaresCSV(string Radares, string DataConsulta);
        byte[] GetTipoVeiculosRadaresCSV(string Radares, string DataConsulta);
        byte[] GetInfracoesPorRadarCSV(string Radares, string DataConsulta);
        byte[] GetAcuraciaIdentificacaoRadaresCSV(string Radares, string DataConsulta);
        byte[] GetPerfilVelocidadesRadarCSV(int VelocidadeMin, int VelocidadeMax);
        byte[] GetTrajetosCSV(string DataConsulta, string Radares);
        byte[] GetVelocidadeMediaTrajetoCSV(string DataConsulta, string Radares);
        byte[] GetViagensCSV(string DataConsulta, string Radares);
        byte[] GetDistanciaViagemCSV(string DataConsulta);
    }


    public class RadartonaService : IRadartonaService
    {

        private readonly IRadartonaRepository _rep;

        public RadartonaService(IRadartonaRepository rep)
        {
            _rep = rep;
        }

        public List<BaseRadaresDTO> GetLocalizacaoRadares()
        {
            return _rep.GetLocalizacaoRadares();
        }

        public List<BaseRadaresDTO> GetRadaresTipoEnquadramento(string Enquadramento)
        {
            string[] Enquadramentos = Enquadramento.Split(",");
            return _rep.GetRadaresTipoEnquadramento(Enquadramentos);
        }

        public List<BaseRadaresDTO> GetRadaresZonaConcessao(string ZonaConcessao)
        {
            return _rep.GetRadaresZonaConcessao(ZonaConcessao);
        }

        public List<FluxoVeiculosRadarDTO> GetFluxoVeiculosRadares(string Radares, string DataConsulta)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetFluxoVeiculosRadares(lstRadares, DataConsulta);
        }

        public List<TipoVeiculosRadaresDTO> GetTipoVeiculosRadares(string Radares, string DataConsulta)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetTipoVeiculosRadares(lstRadares, DataConsulta);
        }

        public List<InfracoesPorRadarDTO> GetInfracoesPorRadar(string Radares, string DataConsulta)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetInfracoesPorRadar(lstRadares, DataConsulta);
        }

        public List<AcuraciaIdentificacaoRadaresDTO> GetAcuraciaIdentificacaoRadares(string Radares, string DataConsulta)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetAcuraciaIdentificacaoRadares(lstRadares, DataConsulta);
        }

        public List<BaseRadaresDTO> GetPerfilVelocidadesRadar(int VelocidadeMin, int VelocidadeMax)
        {
            return _rep.GetPerfilVelocidadesRadar(VelocidadeMin, VelocidadeMax);
        }

        public List<TrajetosDTO> GetTrajetos(string DataConsulta, string Radares)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetTrajetos(lstRadares, DataConsulta);
        }

        public List<VelocidadeMediaTrajetoDTO> GetVelocidadeMediaTrajeto(string DataConsulta, string Radares)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetVelocidadeMediaTrajeto(DataConsulta, lstRadares);
        }

        public List<ViagensDTO> GetViagens(string DataConsulta, string Radares)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetViagens(DataConsulta, lstRadares);
        }

        public List<DistanciaViagemDTO> GetDistanciaViagem(string DataConsulta)
        {
            return _rep.GetDistanciaViagem(DataConsulta);
        }

        public bool VerificaChaveTaValida(string chave)
        {
            return _rep.VerificaChaveTaValida(chave);
        }

        public bool UsuarioPodePedirMaisReq(string chave)
        {
            return _rep.UsuarioPodePedirMaisReq(chave);
        }

        public async Task LogRequest(string Usuario, string Endpoint, long TempoRequisicao)
        {
            await _rep.LogRequest(Usuario, Endpoint, TempoRequisicao);
        }

        // ======== CSV ======== 
        public byte[] GetLocalizacaoRadaresCSV()
        {
            return _rep.GetLocalizacaoRadaresCSV();
        }

        public byte[] GetRadaresTipoEnquadramentoCSV(string Enquadramento)
        {
            string[] Enquadramentos = Enquadramento.Split(",");
            return _rep.GetRadaresTipoEnquadramentoCSV(Enquadramentos);
        }

        public byte[] GetRadaresZonaConcessaoCSV(string ZonaConcessao)
        {
            return _rep.GetRadaresZonaConcessaoCSV(ZonaConcessao);
        }

        public byte[] GetFluxoVeiculosRadaresCSV(string Radares, string DataConsulta)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetFluxoVeiculosRadaresCSV(lstRadares, DataConsulta);
        }

        public byte[] GetTipoVeiculosRadaresCSV(string Radares, string DataConsulta)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetTipoVeiculosRadaresCSV(lstRadares, DataConsulta);
        }

        public byte[] GetInfracoesPorRadarCSV(string Radares, string DataConsulta)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetInfracoesPorRadarCSV(lstRadares, DataConsulta);
        }

        public byte[] GetAcuraciaIdentificacaoRadaresCSV(string Radares, string DataConsulta)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetAcuraciaIdentificacaoRadaresCSV(lstRadares, DataConsulta);
        }

        public byte[] GetPerfilVelocidadesRadarCSV(int VelocidadeMin, int VelocidadeMax)
        {
            return _rep.GetPerfilVelocidadesRadarCSV(VelocidadeMin, VelocidadeMax);
        }

        public byte[] GetTrajetosCSV(string DataConsulta, string Radares)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetTrajetosCSV(DataConsulta, lstRadares);
        }

        public byte[] GetVelocidadeMediaTrajetoCSV(string DataConsulta, string Radares)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetVelocidadeMediaTrajetoCSV(DataConsulta, lstRadares);
        }

        public byte[] GetViagensCSV(string DataConsulta, string Radares)
        {
            string[] lstRadares = Radares.Split(",");
            return _rep.GetViagensCSV(DataConsulta, lstRadares);
        }

        public byte[] GetDistanciaViagemCSV(string DataConsulta)
        {
            return _rep.GetDistanciaViagemCSV(DataConsulta);
        }
    }
}
