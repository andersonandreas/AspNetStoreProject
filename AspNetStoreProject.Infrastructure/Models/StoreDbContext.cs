using AspNetStoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetStoreProject.Infrastructure.Models
{
	public class StoreDbContext : DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }


	}
}
