using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        BindingContext = new VM_Home();
    }
}