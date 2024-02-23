using System.ComponentModel.DataAnnotations;

namespace Mission06_Graham.Models
{
    public class Category
    {
        [Key] // Primary key
        [Required] // Required field
        public int CategoryId { get; set; } // Category ID

        [Required] // Required field
        public string CategoryName { get; set; } // Category name
    }
}
