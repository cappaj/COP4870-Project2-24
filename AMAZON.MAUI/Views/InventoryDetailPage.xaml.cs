using AMAZON.MAUI.ViewModels;
namespace AMAZON.MAUI.Views;

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
}