using Infra.DataAccess.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Repository
{
    public class MahasiswaRepository
    {
        private readonly IMongoCollection<Mahasiswa> _mahasiswa;

        public MahasiswaRepository()
        {
            DatabaseSettings databaseSettings = new DatabaseSettings();
            string connectionString = databaseSettings.ConnectionString;
            string mahasiswaCollection = databaseSettings.MahasiswaCollection;
            string database = databaseSettings.Database;

            var connection = new MongoClient(connectionString);
            var _database = connection.GetDatabase(database);

            _mahasiswa = _database.GetCollection<Mahasiswa>(mahasiswaCollection);
        }

        public async Task<Mahasiswa> CreateMahasiswa(Mahasiswa mahasiswa)
        {
            _mahasiswa.InsertOneAsync(mahasiswa).GetAwaiter();
            return mahasiswa;
        }
    }
}
