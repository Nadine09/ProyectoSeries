namespace Leteo_UI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //Rutas (Nombre ruta, tipo)
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
	}
}
