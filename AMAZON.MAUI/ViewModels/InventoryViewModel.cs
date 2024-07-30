using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Amazon.Library.Models;
using Amazon.Library.Services;

namespace AMAZON.MAUI.ViewModels
{
    public class InventoryViewModel : BaseViewModel
    {
        public InventoryViewModel() { }

        public Product? Model { get; set; }

        public InventoryViewModel(Product c)
        {
            if (c.Id == 0)
            {
                Model = new Product();
            }
            else
            {
                Model = InventoryServiceProxy.Instance.Get(c.Id);

            }
            //SetupCommands();
        }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }


    }
}
