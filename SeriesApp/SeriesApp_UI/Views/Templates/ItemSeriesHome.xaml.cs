namespace SeriesApp_UI.Views.Templates;

public partial class ItemSeriesHome : ContentView
{
    private readonly VM_Home viewmodel;

    public ItemSeriesHome()
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