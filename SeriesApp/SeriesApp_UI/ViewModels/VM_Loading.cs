namespace SeriesApp_UI.ViewModels
{
    public class VM_Loading
    {
        public VM_Loading()
        {
            
        }

        public async void Init()
        {
            long userId = long.Parse(await SecureStorage.Default.GetAsync("Account"));
            if (userId == 0)
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
        }
    }
}
