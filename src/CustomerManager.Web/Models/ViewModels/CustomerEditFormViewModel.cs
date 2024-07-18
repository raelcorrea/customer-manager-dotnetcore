namespace CustomerManager.Web.Models.ViewModels
{
    public class CustomerEditFormViewModel
    {
        public Customer? Customer { get; set; } = null!;
        public IEnumerable<Address> Addresses { get; set; } = null!;
    }
}
