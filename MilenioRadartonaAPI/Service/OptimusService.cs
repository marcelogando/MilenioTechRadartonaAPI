using Amazon.Polly.Model;
using MilenioRadartonaAPI.DTO;
using MilenioRadartonaAPI.Models;
using MilenioRadartonaAPI.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Service
{
    public interface IOptimusService
    {
        Task<byte[]> GetAudio(int caminhaoId);
        Task<MemoryStream> PegaAudioPolly(string msgSite);
        Task<string> SalvaAudioNoS3(Stream audio);
        Task SalvaMensagemBanco(string link, string msgSite, int usuarioId, int caminhaoId, string sender);
        List<MensagemDTO> GetMensagensToList(int usuarioId, int caminhaoId);
        Task SalvaMensagemChatterBoxMongoDB(string LinkS3, string Mensagem, int caminhaoId);
    }


    public class OptimusService : IOptimusService
    {

        private readonly IOptimusRepository _rep;

        public OptimusService(IOptimusRepository rep)
        {
            _rep = rep;
        }

        public async Task<byte[]> GetAudio(int caminhaoId)
        {
            return await _rep.GetAudio(caminhaoId);
        }

        public List<MensagemDTO> GetMensagensToList(int usuarioId, int caminhaoId)
        {
            var msgs = _rep.GetMensagensToList(usuarioId, caminhaoId);

            List<MensagemDTO> listMsgsDTO = new List<MensagemDTO>();

            foreach(Mensagem msg in msgs)
            {
                MensagemDTO msgDTO = new MensagemDTO()
                {
                    CaminhaoId = msg.CaminhaoId,
                    Corpo = msg.Corpo,
                    DataHora = msg.DataHora,
                    LinkAudio = msg.LinkAudio,
                    Sender = msg.Sender,
                    UsuarioId = msg.UsuarioId,
                };

                listMsgsDTO.Add(msgDTO);
            }

            return listMsgsDTO;
        }


        public async Task<MemoryStream> PegaAudioPolly(string msgSite)
        {
            return await _rep.PegaAudioPolly(msgSite);
        }

        public async Task<string> SalvaAudioNoS3(Stream audio)
        {
            return await _rep.SalvaAudioNoS3(audio);            
        }

        public async Task SalvaMensagemBanco(string link, string msgSite, int usuarioId, int caminhaoId, string sender)
        {
            await _rep.SalvaMensagemBanco(link, msgSite, usuarioId, caminhaoId, sender);
        }

        public async Task SalvaMensagemChatterBoxMongoDB(string LinkS3, string Mensagem, int caminhaoId)
        {
            await _rep.SalvaMensagemChatterBoxMongoDB(LinkS3, Mensagem, caminhaoId);
        }





        /* DEPRECATED */
        //public async Task PoeLinkAudioNaFilaDoSQS(string link)
        //{
        //    await _rep.PoeLinkAudioNaFilaDoSQS(link);
        //}

        //     ***************************************************************************




    }
}
