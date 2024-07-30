using AMAZON.MAUI.ViewModels;

namespace AMAZON.MAUI;

public partial class ShopPage : ContentPage
{
	public ShopPage()
	{
		InitializeComponent();
       BindingContext = new ShopViewModel();
	}
    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}