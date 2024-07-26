﻿
using CustomerManager.Core.Models;

namespace CustomerManager.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task<int> CreateAsync(Address model);
        Task<int> UpdateAsync(Address model);
        Task<int> DeleteAsync(int addressId, int customerId);
        Task<Address?> GetByIdAsync(int addressId, int customerId);
        Task<Address?> GetByZipCodeAsync(string zipCode, int customerId);
        Task<IEnumerable<Address>> GetAllAsync(int customerId);
    }
}
