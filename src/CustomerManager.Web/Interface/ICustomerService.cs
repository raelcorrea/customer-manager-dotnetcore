using CustomerManager.Web.Models;

namespace CustomerManager.Web.Interface
{
	public interface ICustomerService
	{
		Task<int> RegisterAsync(Customer customer);
		Task<int> EditAsync(Customer customer, int customerId);
		Task<int> RemoveAsync(object id);
		Task<Customer> GetAsync(int id);
		Task<IEnumerable<Customer>> GetAllAsync();
	}
}
