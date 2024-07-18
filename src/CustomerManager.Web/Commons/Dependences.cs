using CustomerManager.Web.Interface;
using CustomerManager.Web.Repositories;
using CustomerManager.Web.Services;

namespace CustomerManager.Web.Commons
{
    public static class Dependences
    {
        public static void AddDependences(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();
        }
    }
}
