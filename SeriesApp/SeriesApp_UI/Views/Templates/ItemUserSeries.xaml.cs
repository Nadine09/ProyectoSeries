using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views.Templates;

public partial class ItemUserSeries : ContentView
{
    private readonly VM_UserSeries viewmodel;

    public ItemUserSeries()
	{
        try
        {
            viewmodel = App.Current.Services.GetService<VM_UserSeries>();
            InitializeComponent();
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}