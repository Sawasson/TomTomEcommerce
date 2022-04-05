using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TomTomEcommerce.Core;

namespace TreeMenuWebApp.Models
{
    public class CategoryModelView
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a category name...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a description...")]
        public string Description { get; set; }

        public Category Parent { get; set; }
        public int? ParentId { get; set; }

        public IEnumerable<CategoryModelView> Childs { get; set; }
    }
}
