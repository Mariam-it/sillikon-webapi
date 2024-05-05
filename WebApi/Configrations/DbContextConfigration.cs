using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configrations;

public static class DbContextConfigration
{
    public static void RegisterDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApiContext>(x => x.UseSqlServer(configuration.GetConnectionString("WebApi_Database")));
    }
}
