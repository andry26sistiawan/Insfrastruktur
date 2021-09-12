using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.DataAccess.Repository
{
    public class DatabaseSettings
    {

        public string ConnectionString = "mongodb+srv://andrysistiawan:Aa12345!@cluster0.snuji.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
        public string Database = "myFirstDatabase";
        public string TestCollection = "Test";
        public string MahasiswaCollection = "Mahasiswa";

    }

}
