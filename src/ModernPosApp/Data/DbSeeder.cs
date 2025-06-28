using ModernPosApp.Models;

namespace ModernPosApp.Data;

public static class DbSeeder
{
	public static void Seed(AppDbContext dbContext)
	{
		if (dbContext.Customers.Any())
		{
			return;
		}
		
		dbContext.Customers.AddRange(new Customer { Name = "Alice Mayfair", Phone = "555-1234", Email = "alice@example.com" },
									 new Customer { Name = "Bob Cain", Phone = "555-5678", Email = "bob@example.com" },
									 new Customer { Name = "Charlie Lee", Phone = "555-9876", Email = "charlie@example.com" });
		
		dbContext.SaveChanges();
	}
}