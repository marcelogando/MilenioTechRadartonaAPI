using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilenioRadartonaAPI.DTO;
using MilenioRadartonaAPI.Models;
using MilenioRadartonaAPI.Models.Postgres;
using MilenioRadartonaAPI.Relatorios;
using Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Controllers
{
    public class RadartonaController : Controller
    {

        /*service*/
        private readonly IRadartonaService _serv;


        public RadartonaController(IRadartonaService serv)
        {
            _serv = serv;
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetLocalizacaoRadares")]
        public IActionResult GetLocalizacaoRadares()
        {
            return Ok(_serv.GetLocalizacaoRadares());
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetRadaresTipoEnquadramento")]
        public async Task<IActionResult> GetRadaresTipoEnquadramento(string Enquadramento)
        {
            var watch = new Stopwatch();
            watch.Start();
            List<BaseRadaresDTO> lstRetorno = _serv.GetRadaresTipoEnquadramento(Enquadramento);
            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetRadaresTipoEnquadramento", TempoRequisicao);

            return Ok(lstRetorno);
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetRadaresZonaConcessao")]
        public async Task<IActionResult> GetRadaresZonaConcessao(string ZonaConcessao)
        {
            var watch = new Stopwatch();
            watch.Start();
            List<BaseRadaresDTO> lstRetorno = _serv.GetRadaresZonaConcessao(ZonaConcessao);
            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetRadaresZonaConcessao", TempoRequisicao);

            return Ok(lstRetorno);
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetFluxoVeiculosRadares")]
        public async Task<IActionResult> GetFluxoVeiculosRadares(string Radares, string DataConsulta)
        {
            var watch = new Stopwatch();
            watch.Start();
            List<FluxoVeiculosRadarDTO> lstRetorno = _serv.GetFluxoVeiculosRadares(Radares, DataConsulta);
            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetFluxoVeiculosRadares", TempoRequisicao);

            return Ok(lstRetorno);
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetTipoVeiculosRadares")]
        public async Task<IActionResult> GetTipoVeiculosRadares(string Radares, string DataConsulta)
        {
            var watch = new Stopwatch();
            watch.Start();
            List<TipoVeiculosRadaresDTO> lstRetorno = _serv.GetTipoVeiculosRadares(Radares, DataConsulta);
            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetFluxoVeiculosRadares", TempoRequisicao);

            return Ok(lstRetorno);
        }

        [Authorize("Bearer")]
        [HttpGet]
        //[HttpGet(Name = "Get infrações por radares.")]
        [Route("/v1/GetInfracoesRadares")]
        public async  Task<IActionResult> GetInfracoesRadares(string Radares, string DataConsulta)
        {
            var watch = new Stopwatch();
            watch.Start();
            List<InfracoesPorRadarDTO> lstRetorno = _serv.GetInfracoesPorRadar(Radares, DataConsulta);
            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetInfracoesRadares", TempoRequisicao);

            return Ok(lstRetorno);
        }

        [Authorize("Bearer")]
        [HttpGet]
        //[HttpGet(Name = "Get infrações por radares.")]
        [Route("/v1/GetAcuraciaIdentificacaoRadares")]
        public async Task<IActionResult> GetAcuraciaIdentificacaoRadares(string Radares, string DataConsulta)
        {
            var watch = new Stopwatch();
            watch.Start();
            List<AcuraciaIdentificacaoRadaresDTO> lstRetorno = _serv.GetAcuraciaIdentificacaoRadares(Radares, DataConsulta);
            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetAcuraciaIdentificacaoRadares", TempoRequisicao);

            return Ok(lstRetorno);
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetPerfilVelocidadesRadar")]
        public async  Task<IActionResult> GetPerfilVelocidadesRadar(int VelocidadeMin, int VelocidadeMax)
        {
            var watch = new Stopwatch();
            watch.Start();
            List<BaseRadaresDTO> lstRetorno = _serv.GetPerfilVelocidadesRadar(VelocidadeMin, VelocidadeMax);
            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetPerfilVelocidadesRadar", TempoRequisicao);

            return Ok(lstRetorno);
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetTrajetos")]
        public async Task<IActionResult> GetTrajetos(string DataConsulta, string Radares)
        {
            var watch = new Stopwatch();
            watch.Start();
            List<TrajetosDTO> lstRetorno = _serv.GetTrajetos(DataConsulta, Radares);
            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetTrajetos", TempoRequisicao);

            return Ok(lstRetorno);
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetVelocidadeMediaTrajeto")]
        public async Task<IActionResult> GetVelocidadeMediaTrajeto(string DataConsulta, string Radares)
        {
            var watch = new Stopwatch();
            watch.Start();
            List<VelocidadeMediaTrajetoDTO> lstRetorno = _serv.GetVelocidadeMediaTrajeto(DataConsulta, Radares);
            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetVelocidadeMediaTrajeto", TempoRequisicao);

            return Ok(lstRetorno);
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetViagens")]
        public async Task<IActionResult> GetViagens(string DataConsulta, string Radares)
        {
            var watch = new Stopwatch();
            watch.Start();
            List<ViagensDTO> lstRetorno = _serv.GetViagens(DataConsulta, Radares);
            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetViagens", TempoRequisicao);

            return Ok(lstRetorno);
        }


        [Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetDistanciaViagem")]
        public async Task<IActionResult> GetDistanciaViagem(string DataConsulta)
        {
            var watch = new Stopwatch();
            watch.Start();
            List<DistanciaViagemDTO> lstRetorno = _serv.GetDistanciaViagem(DataConsulta);
            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetDistanciaViagem", TempoRequisicao);

            return Ok(lstRetorno);
        }


        private async Task LogRequest(string Endpoint, long TempoRequisicao)
        {
            string Usuario = String.Empty;
            try
            {
                Usuario = User.Identity.Name;
            }
            catch { }
            
            await _serv.LogRequest(Usuario, Endpoint, TempoRequisicao);
        }


        // ======== CSV ========

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetLocalizacaoRadaresCSV")]
        public async Task<IActionResult> GetLocalizacaoRadaresCSV()
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetLocalizacaoRadaresCSV();
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "LocalizacaoRadares.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetLocalizacaoRadaresCSV", TempoRequisicao);

            return result;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetRadaresTipoEnquadramentoCSV")]
        public async Task<IActionResult> GetRadaresTipoEnquadramentoCSV(string Enquadramento)
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetRadaresTipoEnquadramentoCSV(Enquadramento);
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "RadaresTipoEnquadramento.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetLocalizacaoRadaresCSV", TempoRequisicao);

            return result;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetRadaresZonaConcessaoCSV")]
        public async Task<IActionResult> GetRadaresZonaConcessaoCSV(string ZonaConcessao)
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetRadaresZonaConcessaoCSV(ZonaConcessao);
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "RadaresZonaConcessao.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetRadaresZonaConcessaoCSV", TempoRequisicao);

            return result;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetFluxoVeiculosRadaresCSV")]
        public async Task<IActionResult> GetFluxoVeiculosRadaresCSV(string Radares, string DataConsulta)
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetFluxoVeiculosRadaresCSV(Radares, DataConsulta);
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "FluxoVeiculosRadares.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetFluxoVeiculosRadaresCSV", TempoRequisicao);

            return result;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetTipoVeiculosRadaresCSV")]
        public async Task<IActionResult> GetTipoVeiculosRadaresCSV(string Radares, string DataConsulta)
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetTipoVeiculosRadaresCSV(Radares, DataConsulta);
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "TipoVeiculosRadares.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetTipoVeiculosRadaresCSV", TempoRequisicao);

            return result;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetInfracoesRadaresCSV")]
        public async Task<IActionResult> GetInfracoesRadaresCSV(string Radares, string DataConsulta)
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetInfracoesPorRadarCSV(Radares, DataConsulta);
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "InfracoesRadares.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetInfracoesRadaresCSV", TempoRequisicao);

            return result;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetAcuraciaIdentificacaoRadaresCSV")]
        public async Task<IActionResult> GetAcuraciaIdentificacaoRadaresCSV(string Radares, string DataConsulta)
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetAcuraciaIdentificacaoRadaresCSV(Radares, DataConsulta);
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "AcuraciaIdentificacaoRadares.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/AcuraciaIdentificacaoRadaresCSV", TempoRequisicao);

            return result;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetPerfilVelocidadesRadarCSV")]
        public async Task<IActionResult> GetPerfilVelocidadesRadarCSV(int VelocidadeMin, int VelocidadeMax)
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetPerfilVelocidadesRadarCSV(VelocidadeMin, VelocidadeMax);
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "PerfilVelocidadesRadar.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetPerfilVelocidadesRadarCSV", TempoRequisicao);

            return result;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetTrajetosCSV")]
        public async Task<IActionResult> GetTrajetosCSV(string DataConsulta, string Radares)
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetTrajetosCSV(DataConsulta, Radares);
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "Trajetos.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetTrajetosCSV", TempoRequisicao);

            return result;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetVelocidadeMediaTrajetoCSV")]
        public async Task<IActionResult> GetVelocidadeMediaTrajetoCSV(string DataConsulta, string Radares)
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetVelocidadeMediaTrajetoCSV(DataConsulta, Radares);
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "VelocidadeMediaTrajeto.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetVelocidadeMediaTrajetoCSV", TempoRequisicao);

            return result;
        }


        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetViagensCSV")]
        public async Task<IActionResult> GetViagensCSV(string DataConsulta, string Radares)
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetViagensCSV(DataConsulta, Radares);
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "GetViagens.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetViagensCSV", TempoRequisicao);

            return result;
        }

        //[Authorize("Bearer")]
        [HttpGet]
        [Route("/v1/GetDistanciaViagemCSV")]
        public async Task<IActionResult> GetDistanciaViagemCSV(string DataConsulta)
        {
            var watch = new Stopwatch();
            watch.Start();
            byte[] csv = _serv.GetDistanciaViagemCSV(DataConsulta);
            var result = new FileContentResult(csv, "application/octet-stream");
            result.FileDownloadName = "GetDistanciaViagem.csv";

            watch.Stop();
            var TempoRequisicao = watch.ElapsedMilliseconds;

            await LogRequest("/v1/GetDistanciaViagemCSV", TempoRequisicao);

            return result;
        }

    }
}

