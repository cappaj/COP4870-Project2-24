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
//using Android.Icu.Text;
//using static Android.Graphics.ColorSpace;

namespace AMAZON.MAUI.ViewModels
{
    public class InventoryViewModel : BaseViewModel
    {

        public ICommand DeleteCommand { get; private set; }
        public ICommand EditCommand { get; private set; }
        public InventoryViewModel() {
            Model = new Product();
            SetupCommands();
        }

        public bool Edit { get; set; }
            
        public bool IsEdit()
        {
            if (Model.Id == 0)
            {

              return false;
            }
            return true;
        }


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
            SetupCommands();
        }

        public InventoryViewModel(int id)
        {
            if(id == 0)
            {
                Model = new Product();
            }
            else
            {
                Model = InventoryServiceProxy.Instance.Get(id);
            }
            SetupCommands();
        }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }



        private void SetupCommands()
        {
            DeleteCommand = new Command(
          (c) => ExecuteDelete((c as InventoryViewModel).Model.Id));
            EditCommand = new Command(
              (c) => ExecuteEdit((c as InventoryViewModel).Model.Id));
        }

        private void ExecuteEdit(int id)
        {
            Edit = IsEdit();

            NotifyPropertyChanged("Edit");

            Shell.Current.GoToAsync($"//InventoryDetailPage?pid={id}");

        }

        private void ExecuteDelete(int id)
        {
            InventoryServiceProxy.Instance.Delete(id);
        }

        public void AddOrUpdate()
        {
            InventoryServiceProxy.Instance.AddOrUpdate(Model);
        }
    }


    
}
