using Microsoft.EntityFrameworkCore;
using WebMVC_Project.Models;

namespace WebMVC_Project.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		
		public DbSet<Category> Categories { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>().HasData(
				new Category {Id = 1, CategoryOrder = 1, Name="Action" },
				new Category {Id = 2, CategoryOrder = 2, Name="SciFi" },
				new Category {Id = 3, CategoryOrder = 3, Name="History" }
				);

		}
	}
}
