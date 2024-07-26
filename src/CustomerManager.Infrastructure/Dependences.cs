using CustomerManager.Core.Interfaces;
using CustomerManager.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManager.Infrastructure
{
    public static class Dependences
    {
        public static void AddDependences(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
        }
    }
}
