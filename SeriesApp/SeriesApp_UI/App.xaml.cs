using SeriesApp_Entities.Classes;
using SeriesApp_UI.ViewModels;
using SeriesApp_UI.Views;

namespace SeriesApp_UI;

public partial class App : Application
{
    public new static App Current => (App)Application.Current;
    public IServiceProvider Services { get; set; }

    public App()
    {
        var services = new ServiceCollection();
        Services = ConfigureServices(services);
        InitializeComponent();
        MainPage = new AppShell();
    }

    private static IServiceProvider ConfigureServices(ServiceCollection services)
    {
        //ViewModels
        services.AddTransient<VM_Login>();
        services.AddTransient<VM_Home>();
        services.AddTransient<VM_Search>();
        services.AddTransient<VM_CreateAccount>();
        services.AddTransient<VM_UserSeries>();
        services.AddTransient<VM_SeriesDetails>();
        services.AddTransient<VM_UsersAddSeries>();
        services.AddTransient<VM_Error>();

        //Views
        services.AddSingleton<LoginPage>();
        services.AddSingleton<HomePage>();
        services.AddSingleton<SearchPage>();
        services.AddSingleton<CreateAccountPage>();
        services.AddSingleton<UserSeriesPage>();
        services.AddSingleton<SeriesDetailsPage>();
        services.AddSingleton<UsersAddSeriesPage>();
        services.AddSingleton<ErrorPage>();

        return services.BuildServiceProvider();
    }
}
