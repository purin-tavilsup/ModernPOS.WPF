using System.Windows.Controls;
using ModernPosApp.ViewModels;

namespace ModernPosApp.Views;

public partial class HomeView : UserControl
{
	public HomeView(HomeViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}