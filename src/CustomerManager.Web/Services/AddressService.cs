using CustomerManager.Web.Interface;
using CustomerManager.Web.Models;

namespace CustomerManager.Web.Services
{
    public class AddressService : IAddressService
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

        public async Task<int> RemoveAsync(Address address)
        {
            return await _repository.DeleteAsync(address.Id);
        }
        #endregion


    }
}
