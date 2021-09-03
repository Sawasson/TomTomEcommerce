using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TomTomEcommerce.Core
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
        public string PathSmall { get; set; }
        public string PathMedium { get; set; }
        public string PathLarge { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
