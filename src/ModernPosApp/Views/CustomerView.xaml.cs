using System.Windows.Controls;
using ModernPosApp.ViewModels;

namespace ModernPosApp.Views;

public partial class CustomerView : UserControl
{
	public CustomerView(CustomerViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}