using CustomerManager.Core.Interfaces;
using CustomerManager.Core.Models;

namespace CustomerManager.Core.Services
{
    public class AddressService
    {
        #region Constructor
        private readonly IAddressRepository _repository;
        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Public Methods
        public async Task<int> AddAsync(Address address)
        {
            return await _repository.CreateAsync(address);
        }

        public async Task<int> EditAsync(Address address)
        {
            return await _repository.UpdateAsync(address);
        }

        public async Task<IEnumerable<Address>> GetAllAsync(int customerId)
        {
            return await _repository.GetAllAsync(customerId);
        }

        public async Task<Address?> GetAsync(int addressId, int customerId)
        {
            return await _repository.GetByIdAsync(addressId, customerId);
        }

        public async Task<Address?> GetByZipCodeAsync(string zipCode, int customerId)
        {
            return await _repository.GetByZipCodeAsync(zipCode, customerId);
        }

        public async Task<int> RemoveAsync(Address address)
        {
            return await _repository.DeleteAsync(address.Id, address.CustomerId);
        }
        #endregion
    }
}
