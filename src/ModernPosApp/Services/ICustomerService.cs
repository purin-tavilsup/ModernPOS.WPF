using ModernPosApp.Models;

namespace ModernPosApp.Services;

public interface ICustomerService
{
	Task<List<Customer>> GetAllCustomersAsync();

	Task AddCustomerAsync(Customer customer);

	Task DeleteCustomerAsync(Customer customer);

	Task DeleteCustomerByIdAsync(int id);

	Task<Customer?> GetCustomerByIdAsync(int id);
}