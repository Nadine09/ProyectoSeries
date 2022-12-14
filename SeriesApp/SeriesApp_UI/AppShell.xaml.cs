using SeriesApp_UI.Views;

namespace SeriesApp_UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage));
        Routing.RegisterRoute(nameof(CreateAccountPage), typeof(CreateAccountPage));
        Routing.RegisterRoute(nameof(SeriesDetailsPage), typeof(SeriesDetailsPage));
        Routing.RegisterRoute(nameof(UsersAddSeriesPage), typeof(UsersAddSeriesPage));
        Routing.RegisterRoute(nameof(ErrorPage), typeof(ErrorPage));
    }
}
