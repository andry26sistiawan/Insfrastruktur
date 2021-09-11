using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataAccess.Model
{
    public class Mahasiswa
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [JsonProperty("nip")]
        public string NIP { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("alamat")]
        public Alamat Alamat { get; set; }

        [JsonProperty("hobby")]
        public List<string> Hobby { get; set; }

        [JsonProperty("fakultasId")]
        public string FakultasId { get; set; }
    }

    public class Alamat
    {

        [JsonProperty("kota")]
        public string Kota { get; set; }

        [JsonProperty("kecamatan")]
        public string Kecamatan { get; set; }

        [JsonProperty("kabupaten")]
        public string Kabupaten { get; set; }

    }


}
