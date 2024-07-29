using AMAZON.MAUI.ViewModels;
using System.Net.Security;

namespace AMAZON.MAUI
{
    public partial class MainPage : ContentPage
    {
       // int count = 0;
       //idk if needed
        public MainPage()
        {

            InitializeComponent();
            BindingContext = new MainViewModel();

        }
        
        private void InventoryClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//InventoryPage");
        }

        private void ShopClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ShopPage");
        }

    }
}