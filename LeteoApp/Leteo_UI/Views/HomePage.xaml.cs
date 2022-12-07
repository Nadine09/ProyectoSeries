namespace Leteo_UI.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		BindingContext = App.Current.Services.GetRequiredService<VM_Home>();
		InitializeComponent();
	}
}