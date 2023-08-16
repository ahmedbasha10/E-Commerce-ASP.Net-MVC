using E_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}
        public DbSet<Item> Items { get; set; }
		public DbSet<Cart> CartItems { get; set; }
        

    }
}
