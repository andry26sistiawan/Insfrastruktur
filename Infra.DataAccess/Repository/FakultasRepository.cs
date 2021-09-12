using Infra.DataAccess.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repository
{
    public class FakultasRepository
    {
        private readonly IMongoCollection<Fakultas> _fakultas;

        public FakultasRepository()
        {
            DatabaseSettings databaseSettings = new DatabaseSettings();
            string connectionString = databaseSettings.ConnectionString;
            string fakultasCollection = databaseSettings.FakultasCollection;
            string database = databaseSettings.Database;

            var connection = new MongoClient(connectionString);
            var _database = connection.GetDatabase(database);

            _fakultas = _database.GetCollection<Fakultas>(fakultasCollection);
        }
         
        public async Task<Fakultas> CreateFakultas(Fakultas fakultas)
        {
            _fakultas.InsertOneAsync(fakultas).GetAwaiter();
            return fakultas;
        }

        public async Task<Fakultas> GetByID(string id)
        {
            var res = await _fakultas.Find(x => x.FakultasId == id).FirstOrDefaultAsync();
            return res;
        }

        public async Task<List<Fakultas>> CreateListFakultas(List<Fakultas> data)
        {
            _fakultas.InsertManyAsync(data).GetAwaiter().GetResult();
            return data;
        }

        public async Task<List<Fakultas>> GetFakultas()
        {
            var res = await _fakultas.Find(Fakultas => true).ToListAsync();
            return res;
        }

    }
}
