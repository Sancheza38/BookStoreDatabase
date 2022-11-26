using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(AuthorID))]
    public class AuthorOfBooks
    {
        public int AuthorID { get; set; }
        
        //public int ContactID { get; set; }
        //[ForeignKey("ContactID")]
        public AuthorContactDetails AuthorContactDetails { get; set; }

        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public List<Write> Writes { get; set; }
    }
}
