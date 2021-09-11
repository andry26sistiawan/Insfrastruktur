using Infra.DataAccess.Model;
using Infra.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.BusinessLogic.TestManagement
{
    public class TestService 
    {
        private readonly TestRepository _testRepository;   
        //fasfsd

        public TestService(TestRepository testRepository)
        {
            this._testRepository ??= testRepository;
        }

        public async Task<Test> InsertTest(Test test)
        {
            //var res = _testRepository.CreateTest(test);
            TestRepository testRepository = new TestRepository();
            var res = testRepository.CreateTest(test);
            return res;
        }
    }
}
