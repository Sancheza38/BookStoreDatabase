using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ContactID), nameof(Email))]
    public class CustomerEmailDetails
    {
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public CustomerContactDetails CustomerContactDetails { get; set; }

        public string Email { get; set; }

    }
}
