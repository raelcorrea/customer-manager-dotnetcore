﻿using CustomerManager.Core.Interfaces;
using CustomerManager.Core.Models;

namespace CustomerManager.Core.Services
{
    public class CustomerService
    {
        #region Constructor
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Public Methods
        public async Task<int> EditAsync(Customer customer)
        {

            var customerSelected = await _repository.GetByIdAsync(customer.Id);

            var currentDate = DateTime.UtcNow;
            customer.UpdatedAt = currentDate;

            customer.CPF = NormalizeString(customer.CPF);
            customer.Phone = NormalizeString(customer.Phone);

            if (customerSelected != null && customerSelected.CPF != customer.CPF)
            {
                var isCpfRegistered = await _repository.GetByCPFAsync(customer.CPF);
                if (isCpfRegistered is not null) throw new Exception("CPF já está cadastrado");
            }

            return await _repository.UpdateAsync(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Customer?> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<Customer?> GetByCpfAsync(string cpf)
        {
            return await _repository.GetByCPFAsync(cpf);
        }

        public async Task<int> RegisterAsync(Customer customer)
        {
            var currentDate = DateTime.UtcNow;
            customer.UpdatedAt = currentDate;
            customer.CreatedAt = currentDate;

            customer.CPF = NormalizeString(customer.CPF);
            customer.Phone = NormalizeString(customer.Phone);

            var isCustomerRegistered = await _repository.GetByCPFAsync(customer.CPF);

            if (isCustomerRegistered is not null) throw new Exception("CPF já está cadastrado");


            return await _repository.CreateAsync(customer);
        }

        public async Task<int> RemoveAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
        #endregion

        #region Private Methods

        private string NormalizeString(string str)
        {
            return str.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
        }

        #endregion
    }
}
