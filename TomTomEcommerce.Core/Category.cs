﻿using System;
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
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a description...")]
        public string Description { get; set; }

    }
}
