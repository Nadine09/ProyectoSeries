namespace SeriesApp_UI.Views;

public partial class ErrorPage : ContentPage
{
	public ErrorPage()
	{
		InitializeComponent();
        BindingContext = new VM_Error();
    }
}