using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TomTomEcommerce.Core
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a category name...")]
        [RegularExpression(@"^.{3,}$", ErrorMessage = "Minimum 3 characters required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Maximum 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a description...")]
        [RegularExpression(@"^.{10,}$", ErrorMessage = "Minimum 10 characters required")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Maximum 150 characters")]
        public string Description { get; set; }

    }
}
