using AMAZON.MAUI.ViewModels;
using System.Net.Security;

namespace AMAZON.MAUI
{
    public partial class MainPage : ContentPage
    {
       // int count = 0;
       //idk if needed
        public MainPage()
        {

            InitializeComponent();
            BindingContext = new MainViewModel();

        }
    }
}