using System.Windows;
using ModernPosApp.Services;
using ModernPosApp.ViewModels;

namespace ModernPosApp.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
	public MainWindow(MainViewModel viewModel, INavigationService navigationService)
	{
		InitializeComponent();
		
		DataContext = viewModel;

		if (navigationService is NavigationService nav)
		{
			nav.ContentHost = MainContent;
		}
		
		// This line has to be executed after ContentHost is initialized/assigned
		viewModel.NavigateHomeCommand.Execute(null);
	}
}