using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManager.Infrastructure.Data
{
    public static class AppDataConnection
    {
        public static IServiceCollection AddDataConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AppDataConnectionStr");
            if (connectionString == null) throw new Exception("Connectionstring not defined.");
            services.AddTransient<IDbConnection>(database => new SqlConnection(connectionString));
            return services;
        }
    }
}
