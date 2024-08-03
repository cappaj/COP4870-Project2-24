using Amazon.Library.Models;
using Amazon.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMAZON.MAUI.ViewModels
{
    public class CartItemViewModel
    {
        public Product Model { get; set; }

       public CartItemViewModel() {  Model = new Product(); } 



        public CartItemViewModel(Product model) { 
            if (model.Id !=0)
            {
                Model = model;
            }
        }

        public CartItemViewModel(CartItem c)
        {
            Model = c.Product;

        }
    
    }
}
