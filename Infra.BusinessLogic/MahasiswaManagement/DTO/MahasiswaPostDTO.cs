using Infra.DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.BusinessLogic.MahasiswaManagement.DTO
{
    public class MahasiswaPostDTO
    {
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
}
