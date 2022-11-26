using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(CustomerID))]
    public class Customer
    {
        public int CustomerID { get; set; }
        
        public int ContactID { get; set; }
        [ForeignKey("ContactID")]
        public CustomerContactDetails CustomerContactDetails { get; set; }
        
        public string Fname { get; set; }
        public string Lname { get; set; }

        //one to many
        public List<Order> Orders { get; set; }


    }
}
