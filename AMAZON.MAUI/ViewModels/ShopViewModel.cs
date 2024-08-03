using Amazon.Library.Models;
using Amazon.Library.Services;
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
        public ObservableCollection<InventoryViewModel> AvailableItems
        {
            get
            {
                return new ObservableCollection<InventoryViewModel>
                    (InventoryServiceProxy.Instance.Products.Where(s => s.Quantity > 0).Select(c => new InventoryViewModel(c)).ToList());
            }
        }
        public ObservableCollection<CartItemViewModel> CartItems
        {
            get
            {
                return new ObservableCollection<CartItemViewModel>
                    (ShoppingCartService.Instance.CartItems.Select(c => new CartItemViewModel(c)).ToList());
            }
        }

        public ICommand AddToCartCommand { get; }

        public ShopViewModel()
        {

         


                // CartItems = new ObservableCollection<InventoryItem>();
                /*
                            foreach(CartItem p in ShoppingCartService.Instance.CartItems)
                            {
                                CartItems.Add(new InventoryItem(p));

                            }
                */

                //     AddToCartCommand = new Command<InventoryItem>(OnAddToCart);
        /*    
            
            private void OnAddToCart(InventoryItem item)
            {
                CartItems.Add(item);
                NotifyPropertyChanged(nameof(TotalPrice));
            }

            public double TotalPrice => CartItems.Sum(item => item.Price);
            */
        }
        public void RefreshAvailableItemList()
        {
            NotifyPropertyChanged(nameof(AvailableItems));
        }

        public void RefreshCartList()
        {
            NotifyPropertyChanged(nameof(CartItems));
        }

        public class InventoryItem
        {
            public string Name { get; set; }
            public double Price { get; set; }

            public int ItemQuantity { get; set; }

            public InventoryItem() { }
            public InventoryItem(Product p)
            {
                Name = p.Name;
                Price = (double)p.Price;
                ItemQuantity = p.Quantity;
            }

            public InventoryItem(CartItem c)
            {
                Name = c.Product.Name;
                Price = (double)c.Product?.Price;
            }

        }
    }
}
