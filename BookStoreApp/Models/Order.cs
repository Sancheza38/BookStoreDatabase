using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(OrderID))]
    public class Order
    {
        public int OrderID { get; set; }
        [Precision(7, 2)]
        public decimal OrderValue { get; set; }
        public string OrderDate { get; set; }

        //many to one
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}
