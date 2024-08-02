using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AMAZON.MAUI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ICommand NavigateToInventoryCommand { get; }
        public ICommand NavigateToShopCommand { get; }

        public MainViewModel()
        {
            NavigateToInventoryCommand = new Command(OnNavigateToInventory);
            NavigateToShopCommand = new Command(OnNavigateToShop);
        }
        private async void OnNavigateToInventory()
        {
            await Shell.Current.GoToAsync("InventoryPage");
        }

        private async void OnNavigateToShop()
        {
            await Shell.Current.GoToAsync("ShopPage");
        }
    }
}