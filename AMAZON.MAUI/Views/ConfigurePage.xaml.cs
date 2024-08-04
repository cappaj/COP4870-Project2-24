using Microsoft.Maui.Controls;

namespace AMAZON.MAUI.Views
{
    public partial class ConfigurePage : ContentPage
    {
        public ConfigurePage()
        {
            InitializeComponent();
        }

        private void BackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
