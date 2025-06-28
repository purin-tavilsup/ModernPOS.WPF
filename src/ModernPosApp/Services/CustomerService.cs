using Microsoft.EntityFrameworkCore;
using ModernPosApp.Data;
using ModernPosApp.Models;

namespace ModernPosApp.Services;

public class CustomerService : ICustomerService
{
	private readonly AppDbContext _dbContext;

	public CustomerService(AppDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<List<Customer>> GetAllCustomersAsync()
	{
		return await _dbContext.Customers.ToListAsync();
	}

	public async Task AddCustomerAsync(Customer customer)
	{
		_dbContext.Customers.Add(customer);
		await _dbContext.SaveChangesAsync();
	}
	
	public async Task DeleteCustomerAsync(Customer customer)
	{
		_dbContext.Customers.Remove(customer);
		await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteCustomerByIdAsync(int id)
	{
		var customer = await GetCustomerByIdAsync(id);

		if (customer is null)
		{
			return;
		}
		
		await DeleteCustomerAsync(customer);
	}
	
	public async Task<Customer?> GetCustomerByIdAsync(int id)
	{
		return await _dbContext.Customers.FindAsync(id);
	}
}