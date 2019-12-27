using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Cryptography;
using Amazon.SQS;
using Amazon.SQS.Model;
using MilenioRadartonaAPI.Context;
using MilenioRadartonaAPI.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MilenioRadartonaAPI.Models.MongoDB;
using MilenioRadartonaAPI.DTO;

namespace MilenioRadartonaAPI.Repository
{
    public interface IOptimusRepository
    {
        byte[] ConverteStreamToByteArray2(Stream stream);
        Task<byte[]> GetAudio(int caminhaoId);
        Task<MemoryStream> PegaAudioPolly(string text);
        Task<string> SalvaAudioNoS3(Stream audioStream);
        Task SalvaMensagemBanco(string link, string msgSite, int usuarioId, int caminhaoId, string sender);
        Task<string> GetLinkAudioNaFilaDoMongoPraChatterBox(int caminhaoId);
        List<Mensagem> GetMensagensToList(int usuarioId, int caminhaoId);
        Task SalvaMensagemChatterBoxMongoDB(string LinkS3, string Mensagem, int caminhaoId);
    }

    public class OptimusRepository : IOptimusRepository
    {
        private readonly IAmazonS3 _amazonS3;
        private readonly IConfiguration configuration;
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        private readonly ApplicationContext _ctx;

        public OptimusRepository(IAmazonS3 amazonS3, IConfiguration configuration, ApplicationContext ctx)
        {
            _amazonS3 = amazonS3;
            this.configuration = configuration;
            _ctx = ctx; 
        }

        public async Task<byte[]> GetAudio(int caminhaoId)
        {
            byte[] retorno = null;

            string CaminhoArquivo = await GetLinkAudioNaFilaDoMongoPraChatterBox(caminhaoId);

            if (!CaminhoArquivo.Equals(String.Empty))
            {

                string Arquivo = CaminhoArquivo.Substring(CaminhoArquivo.LastIndexOf("/") + 1, CaminhoArquivo.Length - CaminhoArquivo.LastIndexOf("/") - 1);
                GetObjectRequest request = new GetObjectRequest
                {
                    Key = Arquivo,
                    BucketName = "milenio-tech-optimus"
                };


                using (GetObjectResponse response = await _amazonS3.GetObjectAsync(request))
                {
                    using (Stream responseStream = response.ResponseStream)
                    {
                        retorno = ConverteStreamToByteArray2(responseStream);
                    }
                }
            }

            return retorno;

        }

        public byte[] ConverteStreamToByteArray2(Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }


        public async Task<MemoryStream> PegaAudioPolly(string text)
        {
            AmazonPollyClient _amazonPolly = new AmazonPollyClient(RegionEndpoint.USEast1);

            try {

                var response = await _amazonPolly.SynthesizeSpeechAsync(new SynthesizeSpeechRequest
                {
                    OutputFormat = "mp3",
                    Text = text,
                    TextType = TextType.Text,
                    VoiceId = VoiceId.Camila,
                    Engine = Engine.Neural,
                });

                var retornoMemoryStream = new MemoryStream();
                response.AudioStream.CopyTo(retornoMemoryStream);

                return retornoMemoryStream;
            }
            catch (Exception e)
            {
                Console.WriteLine("deu ruim");
            }

            return null;
        }



        public async Task<string> SalvaAudioNoS3(Stream audioStream)
        {
            try
            {

                /* CRIA PALAVRA ALEATÓRIA */
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var palavraAleatoria = new string(Enumerable.Repeat(chars, chars.Length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());

                /* CRIPTOGRAFA PALAVRA */
                SHA256 shaHash = SHA256.Create();
                byte[] data = shaHash.ComputeHash(Encoding.UTF8.GetBytes(palavraAleatoria));
                StringBuilder nome = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    nome.Append(data[i].ToString());
                }

                /*  CONFIGURA ENVIO PARA O S3 */
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = audioStream,
                    Key = nome.ToString() + ".mp3",
                    BucketName = "milenio-tech-optimus",
                    CannedACL = S3CannedACL.PublicRead,
                };

                var fileTransferUtility = new TransferUtility(_amazonS3);
                await fileTransferUtility.UploadAsync(uploadRequest);

                return "https://milenio-tech-optimus.s3.amazonaws.com/" + uploadRequest.Key;
            }
            catch (Exception e)
            {

            }

            return null;
        }


        public async Task<string> GetLinkAudioNaFilaDoMongoPraChatterBox(int caminhaoId)
        {
            var connectionString = "mongodb+srv://aplicacao:0LwenKSzTbFPQ349@cluster0-o5d1u.mongodb.net/test?retryWrites=true&w=majority";
            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("mileniotech");
            IMongoCollection<MensagemCaminhaoMongoDB> caminhao = db.GetCollection<MensagemCaminhaoMongoDB>("mensagemCaminhao");

            SortDefinition<MensagemCaminhaoMongoDB> sortCaminhaoData = Builders<MensagemCaminhaoMongoDB>.Sort.Ascending("MensagemId");
            var FilterBuilderCaminhao = Builders<MensagemCaminhaoMongoDB>.Filter;
            FilterDefinition<MensagemCaminhaoMongoDB> filterCaminhaoId = FilterBuilderCaminhao.Eq(d => d.CaminhaoId, caminhaoId);
            FindOptions<MensagemCaminhaoMongoDB> optionsCaminhao = new FindOptions<MensagemCaminhaoMongoDB> { Sort = sortCaminhaoData };

            MensagemCaminhaoMongoDB Mensagem = (await caminhao.FindAsync(filterCaminhaoId, optionsCaminhao).Result.ToListAsync()).FirstOrDefault();
            if (Mensagem != null)
            {
                string Link = Mensagem.LinkAudio;

                FilterDefinition<MensagemCaminhaoMongoDB> filterMensagemId = FilterBuilderCaminhao.Eq(d => d._id, Mensagem._id);
                caminhao.DeleteOne(filterMensagemId);

                return Link;
            }
            else
            {
                return String.Empty;
            }

        }



        public async Task SalvaMensagemBanco(string link, string msgSite, int usuarioId, int caminhaoId, string sender)
        {
            Mensagem msg = new Mensagem()
            {
                CaminhaoId = caminhaoId,
                UsuarioId = usuarioId,
                DataHora = DateTime.Now,
                Corpo = msgSite,
                LinkAudio = link,
                Sender = sender, 
            };

            _ctx.Mensagens.Add(msg);
            await _ctx.SaveChangesAsync();

            MensagemCaminhaoMongoDB msgCaminhao = new MensagemCaminhaoMongoDB()
            {
                MensagemId = msg.MensagemId,
                CaminhaoId = caminhaoId,
                UsuarioId = usuarioId,
                DataHora = msg.DataHora,
                LinkAudio = link
            };

            var connectionString = "mongodb+srv://aplicacao:0LwenKSzTbFPQ349@cluster0-o5d1u.mongodb.net/test?retryWrites=true&w=majority";
            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("mileniotech");
            IMongoCollection<MensagemCaminhaoMongoDB> caminhao = db.GetCollection<MensagemCaminhaoMongoDB>("mensagemCaminhao");

            await caminhao.InsertOneAsync(msgCaminhao);

        }

        public List<Mensagem> GetMensagensToList(int usuarioId, int caminhaoId)
        {
            return _ctx.Mensagens.Where(msg => msg.UsuarioId == usuarioId && msg.CaminhaoId == caminhaoId).ToList().TakeLast(20).ToList();
        }



        /* DEPRECATED */
        //public async Task PoeLinkAudioNaFilaDoSQS(string link)
        //{
        //    try
        //    {

        //        AmazonSQSClient client = new AmazonSQSClient(RegionEndpoint.USEast1);
        //        try
        //        {

        //            var requestQueue = new GetQueueUrlRequest
        //            {
        //                QueueName = "optimus.fifo",
        //                QueueOwnerAWSAccountId = "158808530917"
        //            };
        //            var responseQueue = await client.GetQueueUrlAsync(requestQueue);
        //            string queueUrl = responseQueue.QueueUrl;

        //            var requestSendMessage = new SendMessageRequest
        //            {
        //                DelaySeconds = (int)TimeSpan.FromSeconds(5).TotalSeconds,
        //                MessageAttributes = new Dictionary<string, MessageAttributeValue>
        //                {
        //                    {
        //                        "Chat", new MessageAttributeValue
        //                        { DataType = "String", StringValue = link }
        //                    },
        //                },
        //                MessageBody = "Usuario Chat para Caminhoneiro",
        //                QueueUrl = queueUrl,
        //                MessageGroupId = "teste"
        //                MessageDeduplicationId = link
        //            };

        //            var sendMessageResponse = await client.SendMessageAsync(requestSendMessage);
        //        }
        //        catch (Exception e)
        //        {

        //        }

        //    }

        //    ***********************************************************************************************

        //public Task GetAudioNaFilaDoSQS()
        //{
        //    AmazonSQSClient client = new AmazonSQSClient(RegionEndpoint.USEast1);
        //    string Link = "";

        //    try
        //    {
        //        string queueUrl = "https://sqs.us-east-1.amazonaws.com/158808530917/optimus.fifo";
        //        var request = new ReceiveMessageRequest
        //        {
        //            QueueUrl = queueUrl,
        //            MessageAttributeNames = new List<string>() { "All" },
        //            MaxNumberOfMessages = 1,
        //            VisibilityTimeout = (int)TimeSpan.FromSeconds(10).TotalSeconds,
        //            WaitTimeSeconds = (int)TimeSpan.FromSeconds(15).TotalSeconds

        //        };

        //        var getMessageResponse = client.ReceiveMessageAsync(request);
        //        getMessageResponse.Wait();

        //        if (getMessageResponse.Result.Messages.Count != 0)
        //        {
        //            for (int i = 0; i < getMessageResponse.Result.Messages.Count; i++)
        //            {
        //                if (getMessageResponse.Result.Messages[i].Body == "Usuario Chat para Caminhoneiro")
        //                {
        //                    string receiptHandle = getMessageResponse.Result.Messages[i].ReceiptHandle;

        //                    if (getMessageResponse.Result.Messages[i].MessageAttributes.Count > 0)
        //                    {
        //                        Link = getMessageResponse.Result.Messages[i].MessageAttributes["Chat"].StringValue;
        //                    }

        //                    var deleteMessageRequest = new DeleteMessageRequest();

        //                    deleteMessageRequest.QueueUrl = queueUrl;
        //                    deleteMessageRequest.ReceiptHandle = receiptHandle;

        //                    var responseDelete = await client.DeleteMessageAsync(deleteMessageRequest);
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {

        //    }


        //}

        //      ********************************************************************************************






        public async Task SalvaMensagemChatterBoxMongoDB(string LinkS3, string Mensagem, int caminhaoId)
        {
            MensagemAudioCaminhaoMongoDB mensagem = new MensagemAudioCaminhaoMongoDB
            {
                caminhaoId = caminhaoId,
                linkS3 = LinkS3,
                mensagem = Mensagem,
                dataHoraMensagem = DateTime.Now
            };

            var connectionString = "mongodb+srv://aplicacao:0LwenKSzTbFPQ349@cluster0-o5d1u.mongodb.net/test?retryWrites=true&w=majority";
            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("mileniotech");
            IMongoCollection<MensagemAudioCaminhaoMongoDB> mensagemAudio = db.GetCollection<MensagemAudioCaminhaoMongoDB>("mensagemAudioCaminhao");

            await mensagemAudio.InsertOneAsync(mensagem);
        }

    }
}
