using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ContactID))]
    public class CustomerContactDetails
    {
        public int ContactID { get; set; }

        public List<CustomerAddressDetails> AddressDetails { get; set; }
        public List<CustomerEmailDetails> EmailDetails { get; set; }
        public List<CustomerPhoneDetails> PhoneDetails { get; set; }
    }
}
