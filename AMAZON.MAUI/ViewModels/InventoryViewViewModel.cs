using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.Library.Services;

namespace AMAZON.MAUI.ViewModels
{
    public class InventoryViewViewModel
    {

        public InventoryViewViewModel() { }
        
        public ObservableCollection<InventoryViewModel> InventoryItems { get { return new ObservableCollection<InventoryViewModel>
                    (InventoryServiceProxy.Instance.Products.Select(c => new InventoryViewModel(c)).ToList());
            }
        }
        

    }
}
