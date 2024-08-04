using Amazon.Library.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AMAZON.MAUI.ViewModels
{
    public class ConfigureViewModel : INotifyPropertyChanged
    {
        private decimal _taxRate;
        private decimal _markdownAmount;
        private Product _selectedProduct;
        private ObservableCollection<Product> _products;

        public decimal TaxRate
        {
            get => _taxRate;
            set
            {
                _taxRate = value;
                OnPropertyChanged();
            }
        }

        public decimal MarkdownAmount
        {
            get => _markdownAmount;
            set
            {
                _markdownAmount = value;
                OnPropertyChanged();
            }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public ConfigureViewModel()
        {
            // Initialize Products with sample data or fetch from your service
            Products = new ObservableCollection<Product>
            {
                new Product { Id = 1, Name = "Sample Product 1", Price = 10.00m },
                new Product { Id = 2, Name = "Sample Product 2", Price = 20.00m }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
