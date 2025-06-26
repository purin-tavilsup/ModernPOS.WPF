using Microsoft.EntityFrameworkCore;
using ModernPosApp.Models;

namespace ModernPosApp.Data;

public class AppDbContext : DbContext
{
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Product> Products { get; set; }
	
	protected override void OnConfiguring(DbContextOptionsBuilder options) 
		=> options.UseSqlite("Data Source=pos-app.db");
}