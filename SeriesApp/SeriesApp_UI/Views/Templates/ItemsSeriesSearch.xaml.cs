using AndroidX.Lifecycle;
using SeriesApp_UI.ViewModels;

namespace SeriesApp_UI.Views.Templates;

public partial class ItemsSeriesSearch : ContentView
{
    private readonly VM_Search viewmodel;

    public ItemsSeriesSearch()
	{
        try
        {
            viewmodel = App.Current.Services.GetService<VM_Search>();
            InitializeComponent();
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}