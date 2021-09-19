using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TomTomEcommerce.Core
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }
        public int? UserId { get; set; }

        public List<CartProduct> cartProducts { get; set; }

        public Adress Adress { get; set; }
        public int? AdressId { get; set; }


        public DateTime OrderDate { get; set; }



        public double TotalPrice { get; set; }


    }
}
