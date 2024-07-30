using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Library.Services;
using Amazon.Library.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AMAZON.MAUI.ViewModels
{
    public class InventoryViewViewModel : BaseViewModel
    {

        public InventoryViewViewModel() 
        { 
        
        }
        
        public ObservableCollection<InventoryViewModel> InventoryItems { get { return new ObservableCollection<InventoryViewModel>
                    (InventoryServiceProxy.Instance.Products.Select(c => new InventoryViewModel(c)).ToList());
            }
        }


       
    }
}
