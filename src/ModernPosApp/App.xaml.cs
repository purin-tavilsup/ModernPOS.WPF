using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModernPosApp.Data;
using ModernPosApp.Services;
using ModernPosApp.ViewModels;
using ModernPosApp.Views;

namespace ModernPosApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	public static IHost AppHost { get; private set; }

	public App()
	{
		AppHost = Host.CreateDefaultBuilder()
					  .ConfigureServices((context, services) =>
					  {
						  // services
						  services.AddDbContext<AppDbContext>();
						  services.AddSingleton<INavigationService, NavigationService>();
						  services.AddSingleton<IThemeService, ThemeService>();

						  // ViewModels
						  services.AddSingleton<MainViewModel>();
						  services.AddTransient<HomeViewModel>();
						  services.AddTransient<CustomerViewModel>();

						  // Views
						  services.AddSingleton<MainWindow>();
						  services.AddTransient<HomeView>();
						  services.AddTransient<CustomerView>();
					  })
					  .Build();
	}

	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);
		
		var mainWindow = AppHost.Services.GetService<MainWindow>();
		
		mainWindow?.Show();
	}

	protected override async void OnExit(ExitEventArgs e)
	{
		await AppHost.StopAsync();
	}
}