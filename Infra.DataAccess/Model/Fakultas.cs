using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataAccess.Model
{
    public class Fakultas
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [JsonProperty("fakultasId")]
        public string FakultasId { get; set; }

        [JsonProperty("nama")]
        public string Nama { get; set; }

        [JsonProperty("jurusan")]
        public string Jurusan { get; set; }
    }
}
