using Microsoft.Data.SqlClient;
using System.Data;

namespace CustomerManager.Web.Data
{
	public static class DataConnection
	{
		public static IServiceCollection AddDataConnection(this IServiceCollection services, IConfiguration configuration)
		{
            var connectionString = configuration.GetConnectionString("AppDataConnectionStr");

			if (connectionString is not null && connectionString.Contains("%CONTENT_PATH%")) {

				var contentPath = System.IO.Directory.GetCurrentDirectory();
				connectionString = connectionString.Replace("%CONTENT_PATH%", contentPath);
            }
            services.AddTransient<IDbConnection>(database=> new SqlConnection(connectionString));
			return services;
		}
	}
}
