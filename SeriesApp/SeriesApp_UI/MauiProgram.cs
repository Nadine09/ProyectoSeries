using SeriesApp_UI.ViewModels;
using SeriesApp_UI.Views;

namespace SeriesApp_UI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		
		//Login
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<VM_Login>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<VM_MainPage>();


        return builder.Build();
	}
}
