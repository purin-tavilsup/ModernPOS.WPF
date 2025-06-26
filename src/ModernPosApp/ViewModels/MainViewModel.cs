using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ModernPosApp.Services;
using ModernPosApp.Views;

namespace ModernPosApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
	private readonly INavigationService _navigationService;
	private readonly IThemeService _themeService;

	public string ThemeButtonLabel => IsDarkTheme ? "Light Theme" : "Dark Theme";
	
	[ObservableProperty]
	private string currentPage;
	
	[ObservableProperty]
	private bool isDarkTheme = true;

	public MainViewModel(INavigationService navigationService, IThemeService themeService)
	{
		_navigationService = navigationService;
		_themeService = themeService;
	}

	[RelayCommand]
	private void NavigateHome()
	{
		_navigationService.NavigateTo<HomeView>();
		CurrentPage = "Home";
	}

	[RelayCommand]
	private void NavigateCustomer()
	{
		_navigationService.NavigateTo<CustomerView>();
		CurrentPage = "Customer";
	}
	
	[RelayCommand]
	private void ToggleTheme()
	{
		var theme = IsDarkTheme ? AppTheme.Dark : AppTheme.Light;
		
		_themeService.ApplyTheme(theme);
	}

	partial void OnIsDarkThemeChanged(bool value)
	{
		OnPropertyChanged(nameof(ThemeButtonLabel));
	}
}