using Microsoft.Maui.Controls;
using AMAZON.MAUI.ViewModels;

namespace AMAZON.MAUI.Views
{
    public partial class ConfigurePage : ContentPage
    {
        public ConfigurePage()
        {
            BindingContext = new ConfigureViewModel();

            var taxRateEntry = new Entry
            {
                Placeholder = "Enter Tax Rate",
                Keyboard = Keyboard.Numeric
            };
            taxRateEntry.SetBinding(Entry.TextProperty, new Binding("TaxRate", BindingMode.TwoWay));

            var productPicker = new Picker
            {
                Title = "Select Product"
            };
            productPicker.SetBinding(Picker.ItemsSourceProperty, "Products");
            productPicker.SetBinding(Picker.SelectedItemProperty, "SelectedProduct");
            productPicker.ItemDisplayBinding = new Binding("Name");

            var markdownEntry = new Entry
            {
                Placeholder = "Enter Markdown Amount",
                Keyboard = Keyboard.Numeric
            };
            markdownEntry.SetBinding(Entry.TextProperty, new Binding("MarkdownAmount", BindingMode.TwoWay));

            var bogoSwitch = new Switch();
            bogoSwitch.SetBinding(Switch.IsToggledProperty, "SelectedProduct.BuyOneGetOneFree");

            Content = new StackLayout
            {
                Padding = new Thickness(20),
                Children =
                {
                    new Label { Text = "Configure Settings", FontSize = 24, HorizontalOptions = LayoutOptions.Center },
                    new Label { Text = "Tax Rate:" },
                    taxRateEntry,
                    new Label { Text = "Select Product:" },
                    productPicker,
                    new Label { Text = "Markdown Amount:" },
                    markdownEntry,
                    new Label { Text = "Buy One Get One Free:" },
                    bogoSwitch
                }
            };
        }




        private void BackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
