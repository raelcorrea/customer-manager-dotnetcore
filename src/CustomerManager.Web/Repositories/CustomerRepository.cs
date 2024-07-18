using CustomerManager.Web.Interface;
using CustomerManager.Web.Models;
using Dapper;
using System.Data;

namespace CustomerManager.Web.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _connection;

        public CustomerRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Task<int> CreateAsync(Customer model)
        {
            var query = "INSERT INTO Customer(Name,Phone,Email,CPF,CreatedAt,UpdatedAt) VALUES(@Name,@Phone,@Email,@CPF,@CreatedAt,@UpdatedAt)";
            return _connection.ExecuteAsync(query, model);
        }

        public Task<int> DeleteAsync(int id)
        {
            var query = $"DELETE FROM Customer WHERE Id=@Id";
            return _connection.ExecuteAsync(query, new { Id = id });
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var query = "SELECT * FROM Customer";
            return await _connection.QueryAsync<Customer>(query);
        }

        public async Task<Customer?> GetByCPFAsync(string cpf)
        {
            var query = "SELECT * FROM Customer WHERE CPF=@Cpf";
            return await _connection.QueryFirstOrDefaultAsync<Customer?>(query, new { Cpf = cpf });
        }

        public async Task<Customer?> GetByEmailAsync(string email)
        {
            var query = "SELECT * FROM Customer WHERE Email=@Email";
            return await _connection.QueryFirstOrDefaultAsync<Customer?>(query, new { Email = email});
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Customer WHERE Id=@Id";
            return await _connection.QueryFirstOrDefaultAsync<Customer?>(query, new { Id = id });
        }

        public async Task<int> UpdateAsync(Customer model)
        {
            var query = "UPDATE Customer SET Name=@Name,Phone=@Phone,Email=@Email,UpdatedAt=@UpdatedAt WHERE Id=@Id";
            return await _connection.ExecuteAsync(query, model);
        }
    }
}
