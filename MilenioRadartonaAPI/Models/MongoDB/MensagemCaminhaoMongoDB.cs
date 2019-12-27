using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilenioRadartonaAPI.Models.MongoDB
{
    [BsonDiscriminator("mensagemCaminhao")]
    public class MensagemCaminhaoMongoDB
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string _id { get; set; }
        public int MensagemId { get; set; }
        public string LinkAudio { get; set; }
        public DateTime DataHora { get; set; }
        public int CaminhaoId { get; set; }
        public int UsuarioId { get; set; }
    }
}
