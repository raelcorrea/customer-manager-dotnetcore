using CustomerManager.Web.Interface;
using CustomerManager.Web.Models;
using Dapper;
using System.Data;

namespace CustomerManager.Web.Repositories
{
	public class CustomerRepository : IRepositoryAsync<Customer>
	{
		private readonly IDbConnection _connection;

		public CustomerRepository(IDbConnection connection)
		{
			_connection = connection;
		}

		public Task<int> CreateAsync(Customer model)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Customer>> GetAllAsync()
		{
			var query = "SELECT * FROM Customer"; 
			return await _connection.QueryAsync<Customer>(query);
		}

		public Task<Customer?> GetByIdAsync(object id)
		{
			throw new NotImplementedException();
		}

		public Task<int> UpdateAsync(Customer model)
		{
			throw new NotImplementedException();
		}
	}
}
