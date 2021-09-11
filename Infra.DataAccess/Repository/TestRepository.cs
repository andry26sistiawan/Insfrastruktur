using Infra.DataAccess.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataAccess.Repository
{
    public class TestRepository
    {
        private readonly IMongoCollection<Test> _test;

        public TestRepository()
        {
            DatabaseSettings databaseSettings = new DatabaseSettings();
            string connectionString = databaseSettings.ConnectionString;
            string testCollection = databaseSettings.TestCollection;
            string database = databaseSettings.Database;

            var connection = new MongoClient(connectionString);
            var _database = connection.GetDatabase(database);

            _test = _database.GetCollection<Test>(testCollection);
        }

        public Test CreateTest(Test test)
        {
            _test.InsertOne(test);
            return test;
        }
    }
}
