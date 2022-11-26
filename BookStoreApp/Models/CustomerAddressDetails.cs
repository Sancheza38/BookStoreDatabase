using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ContactID), nameof(Address))]
    public class CustomerAddressDetails
    {
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public CustomerContactDetails CustomerContactDetails { get; set; }

        public string Address { get; set; }
    }
}
