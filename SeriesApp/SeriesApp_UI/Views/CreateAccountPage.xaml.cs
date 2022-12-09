namespace SeriesApp_UI.Views;

public partial class CreateAccountPage : ContentPage
{
	public CreateAccountPage()
	{
		InitializeComponent();
        BindingContext = new VM_CreateAccount();
    }
}