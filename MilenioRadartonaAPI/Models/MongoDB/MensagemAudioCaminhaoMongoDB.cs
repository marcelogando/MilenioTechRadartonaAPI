using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models.MongoDB
{
    [BsonDiscriminator("mensagemAudioCaminhao")]
    public class MensagemAudioCaminhaoMongoDB
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string _id { get; set; }
        public int mensagemId { get; set; }
        public string linkS3 { get; set; }
        public string mensagem { get; set; }
        public int caminhaoId { get; set; }
        public DateTime dataHoraMensagem { get; set; }
    }
}
