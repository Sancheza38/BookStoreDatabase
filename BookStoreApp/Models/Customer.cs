using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(CustomerID))]
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        //public int ContactID { get; set; }

        [Required]
        public string Fname { get; set; }

        [Required]
        public string Lname { get; set; }

        //one to many
        public List<Order> Orders { get; set; }

        public CustomerContactDetails CustomerContactDetails { get; set; }


    }
}
