using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views;

public partial class SeriesDetailsPage : ContentPage
{
    public SeriesDetailsPage()
    {
        InitializeComponent();
        BindingContext = App.Current.Services.GetService<VM_SeriesDetails>();
    }

    public SeriesDetailsPage(VM_SeriesDetails vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}