using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Graham.Models
{
    public class EnterMovie // Movie entry model
    {
        [Key] // Primary key
        [Required] // Required field
        public int MovieId { get; set; } // Movie ID

        [ForeignKey("CategoryId")] // Category foreign key
        public int? CategoryId { get; set; } // Nullable category ID
        public Category? Category { get; set; } // Navigation property for category

        [Required(ErrorMessage = "Title is required.")] // Title is required
        public string Title { get; set; } // Movie title

        [Range(1888, 2024, ErrorMessage = "Year is required.")] // Year validation
        public int Year { get; set; } // Release year
        public string? Director { get; set; } // Optional director
        public string? Rating { get; set; } // Optional rating

        [Required(ErrorMessage = "Edited is required.")] // Edited status is required
        public bool? Edited { get; set; } // Nullable edited status

        public string? LentTo { get; set; } // Optional lent to

        [Required(ErrorMessage = "CopiedToPlex is required.")] // CopiedToPlex status is required
        public bool? CopiedToPlex { get; set; } // Nullable CopiedToPlex status

        [StringLength(25)] // Notes length constraint
        public string? Notes { get; set; } // Optional notes
    }
}
