using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Infra.BusinessLogic.Fakultas;
using Infra.BusinessLogic.Fakultas.DTO;

namespace Infra.FrontEndAPI.FakultasController
{
    public class FakultasController
    {
        private readonly FakultasService fakultasService;

        public FakultasController()
        {
            fakultasService ??= new FakultasService();
        }

        [FunctionName("CreateFakultas")]
        public async Task<IActionResult> CreateMahasiswa(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Fakultas/Create")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var param = JsonConvert.DeserializeObject<FakultasPostDTO>(requestBody);

            try
            {
                Guid fakultasId = Guid.NewGuid();
                param.FakultasId = fakultasId.ToString();
                var res = await fakultasService.CreateFakultas(param);
                return new OkObjectResult(res);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [FunctionName("GetFakultasById")]
        public async Task<IActionResult> GetFakultasById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Fakultas/GetFakultasById/{id}")] HttpRequest req,
            ILogger log, string id)
        {
            try
            {
                var res = await fakultasService.GetFakultasById(id);
                return new OkObjectResult(res);
            }catch(Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }

        [FunctionName("GetFakultas")]
        public async Task<IActionResult> GetFakultas(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Fakultas/GetFakultasBy")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var res = await fakultasService.GetFakultas();
                return new OkObjectResult(res);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
