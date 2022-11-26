using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ItemNumber))]
    public class OrderItem
    {
        public int ItemNumber { get; set; }
        [Precision(7, 2)]
        public decimal ItemPrice { get; set; }
        
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order Orders { get; set;}

        public long ISBN { get; set; }
        [ForeignKey("ISBN")]
        public Book Books { get; set;}
    }
}
