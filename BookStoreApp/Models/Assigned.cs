using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(CategoryCode), nameof(ISBN))]
    public class Assigned
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int  CategoryCode  { get; set; }
        [ForeignKey("CategoryCode")]
        public BookCategory BooksCategories { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ISBN { get; set; }
        [ForeignKey("ISBN")]
        public Book Books { get; set; }
    }
}
