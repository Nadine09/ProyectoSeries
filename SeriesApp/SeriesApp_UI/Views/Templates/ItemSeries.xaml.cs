using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views.Templates;

public partial class ItemSeries : ContentView
{
    private readonly VM_Search viewmodel;

    public ItemSeries()
    {
        try
        {
            viewmodel = App.Current.Services.GetService<VM_Search>();
            InitializeComponent();
            //BindingContext = new VM_Search();
        }
        catch (Exception e)
        {
            throw e;
        }

    }
}