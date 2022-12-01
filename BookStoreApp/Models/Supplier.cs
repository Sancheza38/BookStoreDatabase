using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ID))]
    public class Supplier
    {
        public int ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        public List<SupplierRep> SupplierRep { get; set; }
        public List<Supplies> Supplies { get; set; }
    }
}