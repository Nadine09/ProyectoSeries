namespace SeriesApp_UI.Views;
using ViewModels;
public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new VM_Login();
	}
}