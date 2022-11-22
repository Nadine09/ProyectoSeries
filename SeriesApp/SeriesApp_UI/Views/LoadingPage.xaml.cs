using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
        BindingContext = new VM_Loading();
    }
}