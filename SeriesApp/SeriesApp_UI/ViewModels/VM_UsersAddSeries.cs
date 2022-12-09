using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesApp_UI.Utils;

namespace SeriesApp_UI.ViewModels
{
    [QueryProperty("Series", "Series")]
    public partial class VM_UsersAddSeries : VM_Base, IQueryAttributable
    {
        private SeriesConverter converter;
        private UsersEpisodesDAO usersEpisodesDAO;

        [ObservableProperty]
        ClsSeries series;

        [ObservableProperty]
        ClsSeriesWithEpisodesPerSeason seriesEpi;

        [ObservableProperty]
        ClsSeasonNumberWithMaxEpisode seasonEpisodes;

        [ObservableProperty]
        int episode;

        public VM_UsersAddSeries() : base()
        {
            converter = new SeriesConverter();
            usersEpisodesDAO = new UsersEpisodesDAO();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Object obj;
            bool hasValue = query.TryGetValue("Series", out obj);

            if (hasValue)
            {
                SeriesEpi = converter.ConvertToSeriesWithEpisodesPerSeason((ClsSeries)obj);
            }
            else
            {
                throw new Exception();
            }
        }

        [RelayCommand]
        public async void Save()
        {
            if (SeriesEpi != null && SeasonEpisodes != null && Episode != 0 && User != null)
            {
                usersEpisodesDAO.AddProgress(SeriesEpi.Id, SeasonEpisodes.SeasonNumber, Episode, User.Id);
            }
        }

        [RelayCommand]
        public async void GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
