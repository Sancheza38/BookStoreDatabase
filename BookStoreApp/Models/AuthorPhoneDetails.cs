using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ContactID), nameof(Phone))]
    public class AuthorPhoneDetails
    {
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public AuthorContactDetails AuthorContactDetails { get; set; }

        public string Phone { get; set; }

    }
}
