using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Mvc;
using MilenioRadartonaAPI.Service;
using MilenioRadartonaAPI.Repository;
using MilenioRadartonaAPI.DTO;
using Microsoft.AspNetCore.Http;
using Google.Cloud.Speech.V1;

namespace MilenioRadartonaAPI.Controllers
{
    public class OptimusController : Controller
    {

        private readonly IOptimusService _serv;

        public OptimusController(IOptimusService serv)
        {
            _serv = serv;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Main()
        {
            return View();
        }


        [HttpGet]
        [Route("Optimus/Conversar/{usuarioId}/{caminhaoId}")]
        public IActionResult Conversar(int usuarioId, int caminhaoId)
        {
            ViewData["Mensagens"] = _serv.GetMensagensToList(usuarioId, caminhaoId);            
            return View();
        }


        [HttpGet]
        [Route("Optimus/AtualizaChat")]
        public List<MensagemDTO> AtualizaChat(int usuarioId, int caminhaoId)
        {
            var lista = _serv.GetMensagensToList(usuarioId, caminhaoId);
            return lista;
        }


        [HttpPost]
        [Route("Optimus/SendMensagemAsync")]
        public async Task SendMensagemAsync([FromBody] MensagemDTO msg) 
        {


            /* ENVIA PRA POLLY */
            var audio = await _serv.PegaAudioPolly(msg.Corpo);

            /* Grava no S3*/
            var link = await _serv.SalvaAudioNoS3(audio);

            /* COLOCA NO SQS o link */
            //await _serv.PoeLinkAudioNaFilaDoSQS(link);

            await _serv.SalvaMensagemBanco(link, msg.Corpo, msg.UsuarioId, msg.CaminhaoId, msg.Sender);

        }







        [HttpGet]
        [Route("Optimus/GetAudio/{macAddress}/{caminhaoId}")]
        public async Task<IActionResult> GetAudio([FromRoute] string macAddress, [FromRoute] int caminhaoId)
        {
            byte[] Audio = await _serv.GetAudio(caminhaoId);

            if (Audio != null)
            {
                var result = new FileContentResult(Audio, "application/octet-stream");
                result.FileDownloadName = "AudioChat.mp3";

                return result;
            }
            else
            {
                return StatusCode(204);
            }
        }

        [HttpPost]
        [Route("Optimus/InsertAudio")]
        public async Task<IActionResult> InsertAudio(int caminhaoId, IFormFile file)
        {
            try
            {
                MemoryStream msAudio = new MemoryStream();
                file.CopyTo(msAudio);

                /* Grava no S3*/
                var link = await _serv.SalvaAudioNoS3(msAudio);

                /* Transcreve audio */
                string AudioTranscrito = String.Empty;

                var speech = SpeechClient.Create();
                var response = speech.Recognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.EncodingUnspecified,
                    LanguageCode = "pt-br",
                },
                await RecognitionAudio.FromStreamAsync(file.OpenReadStream()));

                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        AudioTranscrito = alternative.Transcript;
                    }
                }

                    await _serv.SalvaMensagemBanco(link, AudioTranscrito, 1, caminhaoId, "you");
                    return Ok(file);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}