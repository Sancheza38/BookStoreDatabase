using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ContactID), nameof(Address))]
    public class AuthorAddressDetails
    {
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public AuthorContactDetails AuthorContactDetails { get; set; }

        public string Address { get; set; }
    }
}
