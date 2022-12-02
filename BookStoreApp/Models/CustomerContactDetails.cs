using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ContactID))]
    public class CustomerContactDetails
    {
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public Customer Customer { get; set; }

        public List<CustomerAddressDetails> AddressDetails { get; set; }
        public List<CustomerEmailDetails> EmailDetails { get; set; }
        public List<CustomerPhoneDetails> PhoneDetails { get; set; }
    }
}
