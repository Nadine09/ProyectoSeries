using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views;

public partial class UserSeriesPage : ContentPage
{
	public UserSeriesPage()
	{
		InitializeComponent();
        BindingContext = App.Current.Services.GetService<VM_UserSeries>();
    }

    /// <summary>
    /// Evento asociado a la aparición de la vista. Se actualiza el listado de series.
    /// </summary>
    protected override void OnAppearing()
    {
        Page paginaAnterior = Navigation.NavigationStack.First();
        base.OnAppearing();
        var bindingContext = (VM_UserSeries)this.BindingContext;
        bindingContext.RefreshCommand.Execute(null);
    }
}