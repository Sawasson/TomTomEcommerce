using Microsoft.EntityFrameworkCore;
using TomTomEcommerce.Core;

namespace TomTomEcommerce.EFCore
{
    public class TTContext : DbContext
    {
        public TTContext(DbContextOptions<TTContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
