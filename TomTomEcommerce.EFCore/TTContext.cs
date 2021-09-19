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
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Order> Orders { get; set; }




    }
}
