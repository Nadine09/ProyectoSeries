using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetService<VM_Home>();
    }
}