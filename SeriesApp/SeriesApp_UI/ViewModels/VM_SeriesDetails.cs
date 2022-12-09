using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SeriesApp_UI.ViewModels
{
    //[QueryProperty("Id", "Id")]
    //[QueryProperty("Name", "Name")]
    //[QueryProperty("ImageUrl", "ImageUrl")]
    //[QueryProperty("Synopsis", "Synopsis")]
    [QueryProperty("Series", "Series")]
    public partial class VM_SeriesDetails : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        ClsSeries series;
        
        [ObservableProperty]
        long id;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string imageUrl;

        [ObservableProperty]
        string synopsis;

        public VM_SeriesDetails()
        {
        }


        public VM_SeriesDetails(ClsSeries series)
        {
            Id = series.Id;
            Name = series.Name;
            ImageUrl = series.ImageUrl;
            synopsis = series.Synopsis;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Object obj;
            bool hasValue = query.TryGetValue("Series", out obj);

            if (hasValue)
            {
                Series = (ClsSeries) obj;
            }
            else
            {
                throw new Exception();
            }
        }

        [RelayCommand]
        public async void GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
