using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(CategoryCode))]
    public class BookCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryCode { get; set; }

        public string CategoryDescription { get; set; }

        //many to many
        public List<Assigned> Assigns { get; set; }
    }
}
