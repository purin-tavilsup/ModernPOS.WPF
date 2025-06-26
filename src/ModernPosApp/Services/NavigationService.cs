using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace ModernPosApp.Services;

public class NavigationService : INavigationService
{
	private readonly IServiceProvider _serviceProvider;
	
	public ContentControl ContentHost { get; set; }
	
	public NavigationService(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public void NavigateTo<T>() where T: class
	{
		var view = _serviceProvider.GetRequiredService<T>() as UserControl;

		if (view is null)
		{
			throw new InvalidOperationException($"View '{typeof(T).Name}' must inherit from UserControl");
		}

		ContentHost.Content = view;
	}
	
}