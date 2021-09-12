using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TomTomEcommerce.Core
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public List<Adress> Adresses { get; set; }

    }
}
