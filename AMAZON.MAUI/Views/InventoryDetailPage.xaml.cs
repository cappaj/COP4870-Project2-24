using AMAZON.MAUI.ViewModels;
using System.ComponentModel;
namespace AMAZON.MAUI.Views;

[QueryProperty(nameof(ProductId), "ProductId")]
public partial class InventoryDetailPage : ContentPage
{


  

    public bool Edit { get; set; }
	public InventoryDetailPage()
	{
        InitializeComponent();

        BindingContext = new InventoryViewModel();
	}

    public int ProductId {  get; set; }

    

    public void IsEdit()
    {
        if (ProductId == 0) { 
        
            Edit = false;
        }
        Edit = true;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new InventoryViewModel(ProductId);
        IsEdit();
    }

    private void ExitClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//InventoryPage");
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//InventoryPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as InventoryViewModel).AddOrUpdate();
        Shell.Current.GoToAsync("//InventoryPage");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}