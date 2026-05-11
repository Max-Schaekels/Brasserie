using Brasserie.ViewModel;
using CommunityToolkit.Maui.Views;

namespace Brasserie.View;

public partial class ItemPopup : Popup
{
	public ItemPopup(MenuPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private void buttonClose_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }
}