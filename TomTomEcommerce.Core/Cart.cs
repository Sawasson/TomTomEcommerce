using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TomTomEcommerce.Core
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }

    }
}
