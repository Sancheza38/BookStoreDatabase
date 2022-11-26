using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ContactID), nameof(Phone))]
    public class CustomerPhoneDetails
    {
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public CustomerContactDetails CustomerContactDetails { get; set; }

        public string Phone { get; set; }

    }
}
