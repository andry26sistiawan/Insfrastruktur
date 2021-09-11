using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataAccess.Model
{
    public class Test
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [JsonProperty("testID")]
        public string TestId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
