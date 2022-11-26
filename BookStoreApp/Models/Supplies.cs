
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ID), nameof(ISBN))]
    public class Supplies
    {
        public int ID { get; set; }
        [ForeignKey("ID")]
        public Supplier Supplier { get; set; }

        public long ISBN { get; set; }
        [ForeignKey("ISBN")]
        public Book Books { get; set; } 
    }
}
