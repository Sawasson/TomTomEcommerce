using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TomTomEcommerce.Core.Models
{
    public class CategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a category name...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a description...")]
        public string Description { get; set; }

        public Category Parent { get; set; }
        public int? ParentId { get; set; }

        public IEnumerable<CategoryViewModel> Childs { get; set; }
    }
}
