using CustomerManager.Core.Models;

namespace CustomerManager.Web.Models
{
    public class CustomerEditFormViewModel
    {
        public Customer? Customer { get; set; } = null!;
        public IEnumerable<Address> Addresses { get; set; } = null!;
    }
}
