using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TomTomEcommerce.Core;

namespace TomTomEcommerce.EFCore
{
    public class TTUserService
    {
        private TTContext dbContext { get; set; }

        public TTUserService(TTContext tTContext)
        {
            this.dbContext = tTContext;
        }

        public void CreateNewUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public User GetUser(string email)
        {
            var user = dbContext.Users.Where(x => x.Email == email).SingleOrDefault();
            return user;

        }

        public bool LoginUser(User user)
        {
            var log = dbContext.Users.Where(x=>x.Email==user.Email && x.Password==user.Password).SingleOrDefault();
            bool login = false;
            if (log !=null)
            {
                login = true;
            }
            return login;
        }
    }
}
