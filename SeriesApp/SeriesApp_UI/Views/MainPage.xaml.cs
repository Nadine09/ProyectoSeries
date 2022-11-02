using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        BindingContext = new VM_MainPage();
    }
}

