using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Amazon.Library.Models;
using Amazon.Library.Services;
using Microsoft.Maui.Controls;

namespace AMAZON.MAUI.ViewModels
{
    public class WishlistPage : INotifyPropertyChanged
    {
        private ShoppingCartService _shoppingCartService = ShoppingCartService.Instance;

        public ObservableCollection<ShoppingCart> Wishlists { get; set; }
        public ICommand AddWishlistCommand { get; }
        public ICommand RemoveWishlistCommand { get; }
        public ICommand CheckoutWishlistCommand { get; }

        public WishlistPage()
        {
            Wishlists = new ObservableCollection<ShoppingCart>();
            AddWishlistCommand = new Command(AddWishlist);
            RemoveWishlistCommand = new Command<ShoppingCart>(RemoveWishlist);
            CheckoutWishlistCommand = new Command<ShoppingCart>(CheckoutWishlist);
        }

        private void AddWishlist()
        {
            Wishlists.Add(new ShoppingCart());
            OnPropertyChanged(nameof(Wishlists));
        }

        private void RemoveWishlist(ShoppingCart wishlist)
        {
            if (wishlist != null)
            {
                Wishlists.Remove(wishlist);
                OnPropertyChanged(nameof(Wishlists));
            }
        }

        private void CheckoutWishlist(ShoppingCart wishlist)
        {
            if (wishlist != null)
            {
                string receipt = wishlist.Checkout();
                // Display receipt or process checkout as needed
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ShoppingCart : INotifyPropertyChanged
    {
        public ObservableCollection<CartItem> CartItems { get; set; }
        public decimal TotalPrice => CartItems.Sum(item => item.Product.Price * item.Quantity);

        public ShoppingCart()
        {
            CartItems = new ObservableCollection<CartItem>();
        }

        public void AddToCart(Product product, int quantity)
        {
            var cartItem = CartItems.FirstOrDefault(ci => ci.Product.Id == product.Id);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                CartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
            OnPropertyChanged(nameof(TotalPrice));
        }

        public string Checkout()
        {
            decimal subtotal = CartItems.Sum(item => item.Product.Price * item.Quantity);
            decimal taxes = subtotal * 0.07M;
            decimal total = subtotal + taxes;

            var receipt = new StringBuilder();
            receipt.AppendLine("Receipt:");
            foreach (var item in CartItems)
            {
                receipt.AppendLine($"{item.Product.Name} - {item.Product.Description}, Price: {item.Product.Price:C}, Quantity: {item.Quantity}");
            }
            receipt.AppendLine($"Subtotal: {subtotal:C}");
            receipt.AppendLine($"Taxes (7%): {taxes:C}");
            receipt.AppendLine($"Total: {total:C}");

            CartItems.Clear();
            OnPropertyChanged(nameof(TotalPrice));
            return receipt.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
