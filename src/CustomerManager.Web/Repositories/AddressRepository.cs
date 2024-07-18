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

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetAllAsync(int customerId)
        {
            var query = "SELECT * FROM Address WHERE CustomerId = @CustomerId";
            return _connection.QueryAsync<Address>(query, new { CustomerId = customerId});
        }

        public Task<Address?> GetByIdAsync(int addressId, int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Address model)
        {
            throw new NotImplementedException();
        }
    }
}
