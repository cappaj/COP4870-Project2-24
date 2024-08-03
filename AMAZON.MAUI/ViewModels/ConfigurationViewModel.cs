using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AMAZON.MAUI.ViewModels
{
    public class ConfigurationViewModel : INotifyPropertyChanged
    {
        private decimal taxRate;

        public decimal TaxRate
        {
            get => taxRate;
            set
            {
                taxRate = value;
                OnPropertyChanged(nameof(TaxRate));
            }
        }

        public ICommand SaveCommand => new Command(SaveConfiguration);

        private void SaveConfiguration()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
