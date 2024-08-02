using AMAZON.MAUI.ViewModels;
using System.Net.Security;

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

        private void AddClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//InventoryDetailPage");
        }

        private void EditClicked(object sender, EventArgs e)
        {
            (BindingContext as InventoryViewViewModel).RefreshInventoryList();
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            (BindingContext as InventoryViewViewModel).RefreshInventoryList();

        }

        private void OnArriving(object sender, NavigatedToEventArgs e)
        {
            (BindingContext as InventoryViewViewModel).RefreshInventoryList();
        }
    }
}
