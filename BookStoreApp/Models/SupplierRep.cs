
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    [PrimaryKey(nameof(Email))]
    public class SupplierRep
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string WorkNumber { get; set; }
        [Required]
        [Phone]
        public string CellNumber { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Fname { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string Lname { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Organization cannot be longer than 50 characters.")]
        public string Organization { get; set; }
        
        public int SupplierID { get; set; }
        [ForeignKey("SupplierID")]
        public Supplier Supplier { get; set; }

    }
}
