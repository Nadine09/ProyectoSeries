using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetService<VM_Search>();
    }
}