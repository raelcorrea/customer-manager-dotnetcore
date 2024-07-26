using CustomerManager.Core.Models;

namespace CustomerManager.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> CreateAsync(Customer model);
        Task<int> UpdateAsync(Customer model);
        Task<int> DeleteAsync(int id);
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer?> GetByCPFAsync(string cpf);
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
