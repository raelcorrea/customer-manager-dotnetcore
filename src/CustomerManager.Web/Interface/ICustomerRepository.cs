using CustomerManager.Web.Models;
using System.Linq.Expressions;

namespace CustomerManager.Web.Interface
{
    public interface ICustomerRepository
    {
        Task<int> CreateAsync(Customer model);
        Task<int> UpdateAsync(Customer model);
        Task<int> DeleteAsync(int id);
        Task<Customer?> GetByIdAsync(int id);
        Task<Customer?> GetByCPFAsync(string cpf);
        Task<Customer?> GetByEmailAsync(string email);
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
