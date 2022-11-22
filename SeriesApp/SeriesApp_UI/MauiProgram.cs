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
		
		//CreateAccount
		builder.Services.AddSingleton<CreateAccountPage>();
		builder.Services.AddSingleton<VM_CreateAccount>();

		//MainPage
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<VM_MainPage>();

        //Home
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<VM_Home>();

        //UserSeries
        builder.Services.AddTransient<UserSeriesPage>();
        builder.Services.AddTransient<VM_UserSeries>();

        //Account
        builder.Services.AddTransient<AccountPage>();
        builder.Services.AddTransient<VM_Account>();


        return builder.Build();
	}
}
