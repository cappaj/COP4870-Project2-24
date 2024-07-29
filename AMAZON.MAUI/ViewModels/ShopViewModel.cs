using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AMAZON.MAUI.ViewModels
{
    public class ShopViewModel : BaseViewModel
    {
        public ObservableCollection<InventoryItem> AvailableItems { get; }
        public ObservableCollection<InventoryItem> CartItems { get; }

        public ICommand AddToCartCommand { get; }

        public ShopViewModel()
        {
            AvailableItems = new ObservableCollection<InventoryItem>
            {
                new InventoryItem { Name = " ", Price = 00.0 },
                new InventoryItem { Name = " ", Price = 00.0 }
            };

            CartItems = new ObservableCollection<InventoryItem>();
            AddToCartCommand = new Command<InventoryItem>(OnAddToCart);
        }

        private void OnAddToCart(InventoryItem item)
        {
            CartItems.Add(item);
            OnPropertyChanged(nameof(TotalPrice));
        }

        public double TotalPrice => CartItems.Sum(item => item.Price);
    }

   public class InventoryItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
