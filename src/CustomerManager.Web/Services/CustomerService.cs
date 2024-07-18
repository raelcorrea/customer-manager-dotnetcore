using CustomerManager.Web.Interface;
using CustomerManager.Web.Models;

namespace CustomerManager.Web.Services
{
    public class CustomerService : ICustomerService
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

            var currentDate = DateTime.UtcNow;
            customer.UpdatedAt = currentDate;

            customer.CPF = NormalizeString(customer.CPF);
            customer.Phone = NormalizeString(customer.Phone);

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

            return await _repository.CreateAsync(customer);
        }

        public async Task<int> RemoveAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
        #endregion


        #region Private Methods
        private void CpfValidate(string CPF)
        {

        }

        private void Validate()
        {

        }

        private string NormalizeString(string str) {
            return str.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ","");
        }

        #endregion

    }
}
