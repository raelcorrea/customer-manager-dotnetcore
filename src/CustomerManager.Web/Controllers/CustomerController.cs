using CustomerManager.Web.Interface;
using CustomerManager.Web.Models;
using CustomerManager.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace CustomerManager.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IAddressService _addressService;
        public CustomerController(ICustomerService service, IAddressService addressService)
        {
            _service = service;
            _addressService = addressService;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _service.GetAllAsync();
            return View(customers);
        }
        public async Task<IActionResult> Register()
        {
            var customers = await _service.GetAllAsync();
            return View(customers);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var customerViewModel = new CustomerEditFormViewModel();
            customerViewModel.Customer= await _service.GetAsync(id);
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
                    var customerRegistered = await _service.RegisterAsync(customer);
                    var customerSelected = await _service.GetByCpfAsync(customer.CPF);
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
                    var customers = await _service.EditAsync(customer);
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
