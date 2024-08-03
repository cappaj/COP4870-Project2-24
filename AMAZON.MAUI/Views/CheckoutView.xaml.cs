using AMAZON.MAUI.ViewModels;

namespace AMAZON.MAUI.Views;

public partial class CheckoutView : ContentPage
{
	public CheckoutView()
	{
		InitializeComponent();
		BindingContext = new ShoppingCartDetailViewModel();

	}
}