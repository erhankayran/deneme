using Microsoft.EntityFrameworkCore;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=ShopDb;Integrated Security=SSPI");
        }

       


    }
}