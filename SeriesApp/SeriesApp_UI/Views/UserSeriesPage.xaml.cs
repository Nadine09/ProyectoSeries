using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views;

public partial class UserSeriesPage : ContentPage
{
	public UserSeriesPage()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetService<VM_UserSeries>();
    }
}