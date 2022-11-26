using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ContactID), nameof(Email))]
    public class AuthorEmailDetails
    {
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public AuthorContactDetails AuthorContactDetails { get; set; }

        public string Email { get; set; }
    }
}
