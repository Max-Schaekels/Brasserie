using Brasserie.ViewModel;

namespace Brasserie.View;

public partial class MenuPage : ContentPage
{
	public MenuPage(MenuPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}