using CustomerManager.Core.Models;

namespace CustomerManager.Web.Models
{
    public class AddressListView
    {
        public int CustomerId { get; set; }
        public IList<Address> Addresses { get; set; } = null!;
    }
}
