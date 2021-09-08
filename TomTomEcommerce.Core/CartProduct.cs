using System;
using System.Collections.Generic;
using System.Text;

namespace TomTomEcommerce.Core
{
    public class CartProduct
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


    }
}
