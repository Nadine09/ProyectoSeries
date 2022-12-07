using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views.Templates;

public partial class ItemSeriesBase : ContentView
{
    private readonly VM_Home viewmodel;

    public ItemSeriesBase()
    {
        try
        {
            viewmodel = App.Current.Services.GetService<VM_Home>();
            InitializeComponent();
        }
        catch (Exception e)
        {
            throw e;
        }

    }
}