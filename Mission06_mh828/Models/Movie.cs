using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_mh828.Models
{
    public class Movie
    {
        // Movie Attribute Declarations and Required Marks for those that need to be
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Year field is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Year must be a positive number!")]
        public int? Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string LentTo { get; set; } 
        [MaxLength(25)]
        public string Notes { get; set; }

        // Foreign Key Relationship with Category
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
