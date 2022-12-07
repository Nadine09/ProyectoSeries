namespace Leteo_UI;

public partial class App : Application
{
    public new static App Current => (App)Application.Current;
    public IServiceProvider Services { get; }
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
		
		//Views
		services.AddSingleton<LoginPage>();
		services.AddSingleton<HomePage>();

		return services.BuildServiceProvider();
	}
}
