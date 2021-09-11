using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Infra.BusinessLogic.InfraManagement;
using Infra.DataAccess.Model;
using System.Collections.Generic;
using Infra.BusinessLogic.TestManagement;
using Infra.DataAccess.Repository;
using Infra.BusinessLogic.MahasiswaManagement;
using Infra.BusinessLogic.MahasiswaManagement.DTO;

namespace Infra.FrontEndAPI
{
    public class Function1
    {
        private readonly InfraService infraService;
        private readonly TestService testService;
        private readonly TestRepository testRepository;
        private readonly MahasiswaService mahasiswaService;

        public Function1()
        {
            infraService ??= new InfraService();
            testService ??= new TestService(testRepository);
            mahasiswaService ??= new MahasiswaService();
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
       
            var res = infraService.TestInfra();
            return new OkObjectResult(res);
        }

        [FunctionName("FormatQueryParam")]
        public async Task<IActionResult> FormatQueryParam(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Training/FormatQueryParam")] HttpRequest req,
            ILogger log)
        {
            string firstName = req.Query["firstname"];
            string lastName = req.Query["lastName"];
            string fullname = firstName + lastName;

            return new OkObjectResult(fullname);
        }

        [FunctionName("FormatReqForm")]
        public async Task<IActionResult> FormatReqForm(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Training/Form")] HttpRequest req,
            ILogger log)
        {
            string firstname = req.Form["firstname"];
            string lastname = req.Form["lastname"];
            string fullname = firstname + " " + lastname;

            return new OkObjectResult(fullname);
        }

        [FunctionName("FormatBodyJSON")]
        public async Task<IActionResult> FormatBodyJSON(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Training/FormatBodyJSON")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic param = JsonConvert.DeserializeObject(requestBody);

            string firstname = param.firstname;
            string lastname = param.lastname;
            string fullname = firstname + " " + lastname;

            return new OkObjectResult(fullname);
        }

        [FunctionName("InsertTest")]
        public async Task<IActionResult> InsertTest(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Test/Insert")] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var param = JsonConvert.DeserializeObject<Test>(requestBody);

            var res = testService.InsertTest(param);
            return new OkObjectResult(res);
        }

        [FunctionName("TestMapper")]
        public async Task<IActionResult> TestMapper(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "TestMapper")] HttpRequest req,
            ILogger log
            )
        {

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var param = JsonConvert.DeserializeObject<TestDTO>(requestBody);
            var res = await mahasiswaService.TestMapper(param);
            return new OkObjectResult(res);
        }
    }
}
