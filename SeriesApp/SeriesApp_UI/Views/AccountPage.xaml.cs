using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views;

public partial class AccountPage : ContentPage
{
	public AccountPage()
	{
		InitializeComponent();
		this.BindingContext = new VM_Account();
	}
}