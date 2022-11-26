using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(AuthorID), nameof(ISBN))]
    public class Write
    {
        //many to many
        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]
        public AuthorOfBooks AuthorOfBooks { get; set; }


        public long ISBN { get; set; }
        [ForeignKey("ISBN")]
        public Book Books { get; set; }
    }
}
