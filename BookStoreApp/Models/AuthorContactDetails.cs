using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ContactID))]
    public class AuthorContactDetails
    {
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public AuthorOfBooks AuthorOfBooks { get; set; }

        public List<AuthorAddressDetails> AddressDetails { get; set; }
        public List<AuthorEmailDetails> EmailDetails { get; set; }
        public List<AuthorPhoneDetails> PhoneDetails { get; set; }
    }
}
