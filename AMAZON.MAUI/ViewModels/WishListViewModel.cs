using Amazon.Library.Models;
using Amazon.Library.Services;
using System.ComponentModel;
using System.Windows.Input;

public class WishListViewModel : BaseViewModel
{
    private WishListService _wishListService = WishListService.Instance;

    public List<ShoppingCart> Carts => _wishListService.WishList.Carts;

    public ICommand AddCartCommand => new Command<ShoppingCart>(AddCart);
    public ICommand RemoveCartCommand => new Command<ShoppingCart>(RemoveCart);
    public ICommand CheckoutAllCartsCommand => new Command(CheckoutAllCarts);

    private void AddCart(ShoppingCart cart)
    {
        _wishListService.AddCart(cart);
        NotifyPropertyChanged(nameof(Carts));
    }

    private void RemoveCart(ShoppingCart cart)
    {
        _wishListService.RemoveCart(cart);
        NotifyPropertyChanged(nameof(Carts));
    }

    private void CheckoutAllCarts()
    {
        var receipt = _wishListService.CheckoutAllCarts();
        
    }

  
}
