using CustomerManager.Core.Interfaces;
using CustomerManager.Core.Models;
using CustomerManager.Core.Services;
using CustomerManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManager.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AddressService _addressService;
        private readonly CustomerService _customerService;
        public CustomerController(ICustomerRepository customerRepository, IAddressRepository addressRepository)
        {
            _addressService = new AddressService(addressRepository);
            _customerService = new CustomerService(customerRepository);
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllAsync();
            return View(customers);
        }
        public async Task<IActionResult> Register()
        {
            var customers = await _customerService.GetAllAsync();
            return View(customers);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var customerViewModel = new CustomerEditFormViewModel();
            customerViewModel.Customer= await _customerService.GetAsync(id);
            customerViewModel.Addresses = await _addressService.GetAllAsync(id);
            return View(customerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var customerRegistered = await _customerService.RegisterAsync(customer);
                    var customerSelected = await _customerService.GetByCpfAsync(customer.CPF);
                    if (customerSelected is null) return BadRequest("Não foi possivel encontrar o cliente");
                    return RedirectToAction("Edit", new { id = customerSelected.Id });

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("CustomerIsRegistered", ex.Message);
                    return View(customer);
                }
            }
            else
            {
                return View(customer);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Customer customer)
        {
            var customerViewModel = new CustomerEditFormViewModel();

            if (ModelState.IsValid)
            {
                try
                {
                    var customers = await _customerService.EditAsync(customer);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("CustomerIsRegistered", ex.Message);
                    customerViewModel.Customer = customer;
                    customerViewModel.Addresses = await _addressService.GetAllAsync(customer.Id);
                    return View(customerViewModel);
                }
            }
            else
            {
                customerViewModel.Customer = customer;
                customerViewModel.Addresses = await _addressService.GetAllAsync(customer.Id);
                return View(customer);
            }
        }

    }
}
