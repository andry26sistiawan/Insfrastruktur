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
using System.Collections.Generic;

namespace Infra.FrontEndAPI.MahasiswaController
{
    public class MahasiswaController
    {
        private readonly MahasiswaService mahasiswaService;

        public MahasiswaController()
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

        [FunctionName("GetMahasiswaByNIP")]
        public async Task<IActionResult> GetMahasiswaByNIP(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Mahasiswa/GetMahasiswaByNIP/{NIP}")] HttpRequest req,
            ILogger log, string NIP)
        {
            try
            {
                var res = await mahasiswaService.GetMahasiswaByNIP(NIP);
                return new OkObjectResult(res);

            }catch(Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [FunctionName("CreateListMahasiswa")]
        public async Task<IActionResult> CreateListMahasiswa(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route ="Mahasiswa/CreateListMahasiswa")] HttpRequest req,
            ILogger log)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                List<MahasiswaPostDTO> param = JsonConvert.DeserializeObject<List<MahasiswaPostDTO>>(requestBody);
                var res = await mahasiswaService.CreateListMahasiswa(param);
                return new OkObjectResult(res);
            }
            catch(Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [FunctionName("GetMahasiswa")]
        public async Task<IActionResult> GetMahasiswa(
            [HttpTrigger(AuthorizationLevel.Function, "Get", Route ="Mahasiswa/GetMahasiswa")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var res = await mahasiswaService.GetMahasiswa();
                return new OkObjectResult(res);

            }catch(Exception e)
            {
                return new OkObjectResult(e.Message);
            }
        }
    }
}
