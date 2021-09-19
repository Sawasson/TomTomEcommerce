using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TomTomEcommerce.Core
{
    public class CartProduct
    {
        [Key]
        public int Id { get; set; }
        public int CartId { get; set; }
        public int? OrderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


    }
}
