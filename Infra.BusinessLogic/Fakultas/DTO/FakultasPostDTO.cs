using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.BusinessLogic.Fakultas.DTO
{
    public class FakultasPostDTO
    {
        [JsonProperty("fakultasId")]
        public string FakultasId { get; set; }

        [JsonProperty("nama")]
        public string Nama { get; set; }

        [JsonProperty("jurusan")]
        public string Jurusan { get; set; }
    }
}
