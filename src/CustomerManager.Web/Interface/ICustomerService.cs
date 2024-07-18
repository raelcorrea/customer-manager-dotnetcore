using CustomerManager.Web.Models;

namespace CustomerManager.Web.Interface
{
	public interface ICustomerService
	{
		Task<int> RegisterAsync(Customer customer);
		Task<int> EditAsync(Customer customer);
		Task<int> RemoveAsync(int id);
		Task<Customer?> GetAsync(int id);
        Task<Customer?> GetByCpfAsync(string cpf);
        Task<IEnumerable<Customer>> GetAllAsync();
	}
}
