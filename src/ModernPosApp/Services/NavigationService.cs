using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace ModernPosApp.Services;

public class NavigationService : INavigationService
{
	private readonly IServiceScopeFactory _scopeFactory;
	
	public ContentControl ContentHost { get; set; }
	
	public NavigationService(IServiceScopeFactory scopeFactory)
	{
		_scopeFactory = scopeFactory;
	}

	public void NavigateTo<T>() where T: class
	{
		using var scope = _scopeFactory.CreateScope();

		var view = scope.ServiceProvider.GetRequiredService<T>() as UserControl;

		if (view is null)
		{
			throw new InvalidOperationException($"View '{typeof(T).Name}' must inherit from UserControl");
		}

		ContentHost.Content = view;
	}
	
}