using Infra.DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.BusinessLogic.MahasiswaManagement.DTO
{
    public class TestDTO
    {
        [JsonProperty("nip1")]
        public string NIP1 { get; set; }

        [JsonProperty("fullname1")]
        public string Fullname1 { get; set; }

        [JsonProperty("alamat1")]
        public Alamat Alamat1 { get; set; }

        [JsonProperty("hobby")]
        public List<string> Hobby { get; set; }

        [JsonProperty("jurusanId")]
        public string JurusanId { get; set; }

        //[JsonProperty("mataKuliah")]
        //public List<MataKuliah> MataKuluiah { get; set; }
    }
}
