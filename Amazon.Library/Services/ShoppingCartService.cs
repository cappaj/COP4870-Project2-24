using Amazon.Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amazon.Library.Services
{
    public class ShoppingCartService
    {
        private static readonly ShoppingCartService instance = new ShoppingCartService();
        private List<CartItem> cartItems = new List<CartItem>();

        private ShoppingCartService() { }

        public static ShoppingCartService Instance => instance;

        public List<CartItem> CartItems => cartItems;

        public void AddToCart(Product product, int quantity)
        {
            var cartItem = cartItems.FirstOrDefault(ci => ci.Product.Id == product.Id);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }

            var inventoryProduct = InventoryServiceProxy.Instance.Products.FirstOrDefault(p => p.Id == product.Id);
            if (inventoryProduct != null)
            {
                inventoryProduct.Quantity -= quantity;
            }
        }

        public void RemoveFromCart(Product product, int quantity)
        {
            var cartItem = cartItems.FirstOrDefault(ci => ci.Product.Id == product.Id);
            if (cartItem != null)
            {
                if (cartItem.Quantity > quantity)
                {
                    cartItem.Quantity -= quantity;
                }
                else
                {
                    cartItems.Remove(cartItem);
                }

                var inventoryProduct = InventoryServiceProxy.Instance.Products.FirstOrDefault(p => p.Id == product.Id);
                if (inventoryProduct != null)
                {
                    inventoryProduct.Quantity += quantity;
                }
            }
        }

        public string Checkout()
        {
            if (!cartItems.Any())
            {
                return "Your cart is empty.";
            }

            decimal subtotal = 0;
            var receipt = new StringBuilder();
            receipt.AppendLine("Receipt:");

            foreach (var item in cartItems)
            {
                if (item.Product.BuyOneGetOneFree)
                {
                  
                    int effectiveQuantity = (item.Quantity / 2) + (item.Quantity % 2); // Pay for half and get the extra
                    subtotal += item.Product.Price * effectiveQuantity;
                }
                else
                {
                    subtotal += item.Product.Price * item.Quantity;
                }

                receipt.AppendLine($"{item.Product.Name} - {item.Product.Description}, Price: {item.Product.Price:C}, Quantity: {item.Quantity}");
            }

            decimal taxes = subtotal * 0.07M;
            decimal total = subtotal + taxes;

            receipt.AppendLine($"Subtotal: {subtotal:C}");
            receipt.AppendLine($"Taxes (7%): {taxes:C}");
            receipt.AppendLine($"Total: {total:C}");

            cartItems.Clear();

            return receipt.ToString();
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItem(Product p)
        {
            Product = p;
            Quantity = 1;
        }

        public CartItem() { }
    }
}

