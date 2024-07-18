using CustomerManager.Web.Models;

namespace CustomerManager.Web.Interface
{
    public interface IAddressRepository
    {
        Task<int> CreateAsync(Address model);
        Task<int> UpdateAsync(Address model);
        Task<int> DeleteAsync(int id);
        Task<Address?> GetByIdAsync(int addressId, int customerId);
        Task<IEnumerable<Address>> GetAllAsync(int customerId);
    }
}
