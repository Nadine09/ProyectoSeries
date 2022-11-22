using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views;

public partial class UserSeriesPage : ContentPage
{
	public UserSeriesPage()
	{
		InitializeComponent();
		this.BindingContext = new VM_UserSeries();
	}
}