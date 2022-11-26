
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(Email))]
    public class SupplierRep
    {
        public string Email { get; set; }
        public int WorkNumber { get; set; }
        public int CellNumber { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Organization { get; set; }
        
        public int SupplierID { get; set; }
        [ForeignKey("SupplierID")]
        public Supplier Supplier { get; set; }

    }
}
