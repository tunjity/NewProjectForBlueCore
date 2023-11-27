using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NewProject.Domain;

public static class Helper
{
    public static void InstallServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Services
      //  services.AddScoped(CompanyService, ICompanyService);
        //services.AddSingleton(configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>());
    }
}