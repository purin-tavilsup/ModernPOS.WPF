using CommunityToolkit.Mvvm.ComponentModel;

namespace ModernPosApp.ViewModels;

public partial class HomeViewModel : ObservableObject
{
	[ObservableProperty]
	private string welcomeMessage = "Welcome to Modern POS";
	
}