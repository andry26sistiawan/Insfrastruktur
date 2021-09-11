using Infra.DataAccess.Repository;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

[assembly: FunctionsStartup(typeof(Infra.FrontEndAPI.Startup))]

namespace Infra.FrontEndAPI
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.Configure<DatabaseSettings>(
            //    Configuration.GetSection(nameof(DatabaseSettings)));

            //builder.Services.AddSingleton<IDatabaseSettings>(sp =>
            //    sp.GetService<IConfiguration>().Get<DatabaseSettings>());

            //depency injection
            //builder.Services.AddSingleton<IMahasiswaService>((s) =>
            //{
            //    return new MahasiswaService();
            //});

            //builder.Services.Configure<MyDatabaseSettings>(
            //Configuration.GetSection(nameof(MyDatabaseSettings)));


        }
    }
}
