using CustomerManager.Web.Models;

namespace CustomerManager.Web.Interface
{
    public interface IAddressService
    {
        Task<int> AddAsync(Address address);
        Task<int> EditAsync(Address address);
        Task<int> RemoveAsync(Address address);
        Task<Address?> GetAsync(int addressId, int customerId);
        Task<Address?> GetByZipCodeAsync(string zipCode, int customerId);
        Task<IEnumerable<Address>> GetAllAsync(int customerId);
    }
}
