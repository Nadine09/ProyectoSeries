using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views;

public partial class UsersAddSeriesPage : ContentPage
{
	public UsersAddSeriesPage()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetService<VM_UsersAddSeries>();
    }
}