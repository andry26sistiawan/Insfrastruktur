using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Infra.BusinessLogic.MahasiswaManagement;
using Infra.BusinessLogic.MahasiswaManagement.DTO;

namespace Infra.FrontEndAPI.MahasiswaController
{
    public class MahasiswController
    {
        private readonly MahasiswaService mahasiswaService;

        public MahasiswController()
        {
            mahasiswaService ??= new MahasiswaService();
        }

        [FunctionName("MahasiswController")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Mahasiswa/Test")] HttpRequest req,
            ILogger log)
        {
            var res = mahasiswaService.TestMahasiswa();

            return new OkObjectResult(res);
        }

        [FunctionName("CreateMahasiswa")]
        public async Task<IActionResult> CreateMahasiswa(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Mahasiswa/Create")] HttpRequest req,
            ILogger log)
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var param = JsonConvert.DeserializeObject<MahasiswaPostDTO>(requestBody);

            try
            {
                var res = await mahasiswaService.CreateMahasiswa(param);
                return new OkObjectResult(res);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
            
        }
    }
}
