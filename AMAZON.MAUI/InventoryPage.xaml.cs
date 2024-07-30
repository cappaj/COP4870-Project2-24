using AMAZON.MAUI.ViewModels;

namespace AMAZON.MAUI
{
    public partial class InventoryPage : ContentPage
    {
        public InventoryPage()
        {
            InitializeComponent();
            BindingContext = new InventoryViewViewModel();
        }

        private void BackClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//MainPage");
        }
    }
}
