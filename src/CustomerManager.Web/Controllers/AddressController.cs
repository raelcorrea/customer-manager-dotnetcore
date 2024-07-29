using CustomerManager.Core.Interfaces;
using CustomerManager.Core.Models;
using CustomerManager.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManager.Web.Controllers
{
    public class AddressController : Controller
    {

        private readonly AddressService _service;

        public AddressController(IAddressRepository repository)
        {
            _service = new AddressService(repository);
        }


        [HttpGet("/Address/{customerId}")]
        public async Task<IActionResult> Index(int customerId)
        {
            var addresses = await _service.GetAllAsync(customerId);
            return Ok(addresses);
        }


        [HttpPost]
        public async Task<IActionResult> Register(Address address)
        {

            if (ModelState.IsValid)
            {
                var addressCreated = await _service.AddAsync(address);
                var addressSelected = await _service.GetByZipCodeAsync(address.ZipCode, address.CustomerId);
                return Ok(addressSelected);
            }

            return Ok(address);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Address address)
        {
            if (ModelState.IsValid)
            {
                await _service.EditAsync(address);
            }
            return Ok(address);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int addressId, int customerId)
        {
            var address = await _service.GetAsync(addressId, customerId);
            if (address is not null)
                await _service.RemoveAsync(address);

            return NoContent();
        }

    }
}
