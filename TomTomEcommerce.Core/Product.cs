using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TomTomEcommerce.Core
{
    public class Product
    {
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public Category Category { get; set; }
        public int CategoryId { get; set; }


        public int Stock { get; set; }


        public double Price { get; set; }


        public Brand Brand { get; set; }
        public int BrandId { get; set; }




    }
}
