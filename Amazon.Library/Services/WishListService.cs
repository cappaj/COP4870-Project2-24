using Amazon.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Library.Models
{
    public class WishList
    {
        public List<ShoppingCart> Carts { get; set; } = new List<ShoppingCart>();
    }
}

namespace Amazon.Library.Services
{
    public class WishListService
    {
        private static readonly WishListService instance = new WishListService();
        private WishList wishList = new WishList();

        private WishListService() { }

        public static WishListService Instance => instance;

        public WishList WishList => wishList;

        public void AddCart(ShoppingCart cart)
        {
            wishList.Carts.Add(cart);
        }

        public void RemoveCart(ShoppingCart cart)
        {
            wishList.Carts.Remove(cart);
        }

        public string CheckoutAllCarts()
        {
            if (!wishList.Carts.Any())
            {
                return "No carts to checkout.";
            }

            var receiptBuilder = new StringBuilder();
            foreach (var cart in wishList.Carts)
            {
                receiptBuilder.AppendLine(cart.Checkout());
            }
            wishList.Carts.Clear();
            return receiptBuilder.ToString();
        }
    }
}
