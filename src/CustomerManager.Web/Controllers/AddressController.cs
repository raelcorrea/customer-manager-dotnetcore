using CustomerManager.Web.Interface;
using CustomerManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManager.Web.Controllers
{
    public class AddressController : Controller
    {

        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register(Address address)
        {
            var addressCreated = await _service.AddAsync(address);
            return Ok(address);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Address address)
        {
            return Ok(address);
        }
    }
}
