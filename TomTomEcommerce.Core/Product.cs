using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TomTomEcommerce.Core
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a product name...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a description...")]
        public string Description { get; set; }

        public Brand Brand { get; set; }
        public int BrandId { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "Enter a stock data...")]
        public int Stock { get; set; }


        [Required(ErrorMessage = "Enter a price data...")]
        public double Price { get; set; }

        [NotMapped]
        public IFormFile DocumentFile { get; set; }


        public List<ProductImage> ProductImages { get; set; }





    }
}
