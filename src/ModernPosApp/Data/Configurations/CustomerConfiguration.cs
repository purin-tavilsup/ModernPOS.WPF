using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernPosApp.Models;

namespace ModernPosApp.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		builder.ToTable("Customers");
		
		builder.HasKey(c => c.Id);

		builder.Property(c => c.Name)
			   .HasMaxLength(100)
			   .IsRequired()
			   .HasColumnType("VARCHAR(100)");

		builder.Property(c => c.Email)
			   .HasMaxLength(100)
			   .HasColumnType("VARCHAR(100)");

		builder.Property(c => c.Phone)
			   .HasMaxLength(20)
			   .HasColumnType("VARCHAR(20)");
	}
}