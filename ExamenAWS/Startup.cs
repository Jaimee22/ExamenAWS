using Amazon.Lambda.Annotations;
using ExamenAWS.Data;
using ExamenAWS.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExamenAWS;

[LambdaStartup]
public class Startup
{
    
    public void ConfigureServices(IServiceCollection services)
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true);
        var configuration = builder.Build();
        services.AddSingleton<IConfiguration>(configuration);
        services.AddTransient<RepositoryPeliculas>();
        string connectionString = configuration.GetConnectionString("MySql");
        services.AddDbContext<PeliculasContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

    }
}
