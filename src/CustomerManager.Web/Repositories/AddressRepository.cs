using CustomerManager.Web.Interface;
using CustomerManager.Web.Models;
using Dapper;
using System.Data;

namespace CustomerManager.Web.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDbConnection _connection;

        public AddressRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> CreateAsync(Address model)
        {
            var query = "INSERT INTO Address (CustomerId, Street,City,State,ZipCode) VALUES(@CustomerId, @Street,@City,@State,@ZipCode)";
            return await _connection.ExecuteAsync(query, model);
        }

        public async Task<int> DeleteAsync(int addressId, int customerId)
        {
            var query = "DELETE FROM Address WHERE Id=@Id AND CustomerId=@CustomerId";
            return await _connection.ExecuteAsync(query, new { CustomerId = customerId, Id = addressId });
        }

        public Task<IEnumerable<Address>> GetAllAsync(int customerId)
        {
            var query = "SELECT * FROM Address WHERE CustomerId = @CustomerId";
            return _connection.QueryAsync<Address>(query, new { CustomerId = customerId });
        }

        public async Task<Address?> GetByIdAsync(int addressId, int customerId)
        {
            var query = "SELECT * FROM Address WHERE CustomerId = @CustomerId AND Id = @AddressId";
            return await _connection.QueryFirstOrDefaultAsync<Address?>(query, new { CustomerId = customerId, AddressId = addressId });
        }

        public async Task<Address?> GetByZipCodeAsync(string zipCode, int customerId)
        {
            var query = "SELECT * FROM Address WHERE CustomerId = @CustomerId AND ZipCode = @ZipCode";
            return await _connection.QueryFirstOrDefaultAsync<Address?>(query, new { CustomerId = customerId, ZipCode = zipCode });
        }

        public async Task<int> UpdateAsync(Address model)
        {
            var query = "UPDATE Address SET ZipCode=@ZipCode, Street=@Street, City=@City, State=@State WHERE Id=@Id AND CustomerId=@CustomerId";
            return await _connection.ExecuteAsync(query, model);
        }
    }
}
