using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ModernPosApp.Models;
using ModernPosApp.Services;

namespace ModernPosApp.ViewModels;

public partial class CustomerViewModel : ObservableObject
{
	private readonly ICustomerService _customerService;
	
	[ObservableProperty]
	private ObservableCollection<Customer> _customers = [];
	
	public CustomerViewModel(ICustomerService customerService)
	{
		_customerService = customerService;
		_ = LoadCustomersAsync();
	}
	
	private async Task LoadCustomersAsync()
	{
		var list = await _customerService.GetAllCustomersAsync();
		
		Customers = new ObservableCollection<Customer>(list);
	}
}