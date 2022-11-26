using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(ISBN))]
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ISBN { get; set; }

        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        [Precision(7, 2)] 
        public decimal Price { get; set; }
        //[DisplayFormat(NullDisplayText = "No rating")]
        [Range(1,5)]
        public int UserReview { get; set; }

        //many to many
        public List<Supplies> Supplies { get; set; }
        //many to many
        public List<Assigned> Assigns { get; set; }
        //many to many
        public List<Write> Writes { get; set; }
        //one to many
        public List<OrderItem> OrderItems { get; set; }
    }
}
