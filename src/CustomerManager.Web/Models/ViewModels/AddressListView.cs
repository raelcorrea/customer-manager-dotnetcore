namespace CustomerManager.Web.Models.ViewModels
{
    public class AddressListView
    {
        public int CustomerId { get; set; }
        public IList<Address> Addresses { get; set; } = null!;
    }
}
