using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LeteoApp_UI.ViewModels;
using SeriesApp_DAL.DAO;
using SeriesApp_UI.Utils;

namespace SeriesApp_UI.ViewModels
{
    [QueryProperty("Series", "Series")]
    public partial class VM_UsersAddSeries : VM_Observer, IQueryAttributable
    {
        public const string EMPTY_FIELDS = "Los campos no pueden estar vacíos ni el episodio puede ser 0";
        #region Properties
        private SeriesConverter converter;
        private UsersEpisodesDAO usersEpisodesDAO;

        [ObservableProperty]
        bool edit;

        [ObservableProperty]
        bool add;

        [ObservableProperty]
        ClsSeries series;

        [ObservableProperty]
        ClsSeriesWithEpisodesPerSeason seriesEpi;

        [ObservableProperty]
        ClsSeasonNumberWithMaxEpisode seasonEpisodes;

        [ObservableProperty]
        int episode;
        #endregion

        #region Constructors
        public VM_UsersAddSeries() : base()
        {
            converter = new SeriesConverter();
            usersEpisodesDAO = new UsersEpisodesDAO();
        }
        #endregion

        #region Methods
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Object obj;
            bool hasValue = query.TryGetValue("Series", out obj);

            if (hasValue)
            {
                try
                {
                    SeriesEpi = converter.ConvertToSeriesWithEpisodesPerSeason((ClsSeries)obj);
                    CheckRelation();
                }
                catch
                {
                    ShowErrorMessage(DB_ERROR);
                }
            }
            else
            {
                ShowErrorMessage(GENERIC_ERROR);
            }
        }

        /// <summary>
        /// Este método averigua si el usuario tiene progreso anterior guardado y si lo tiene inicializa Episode y SeasonsEpisodes de acuerdo al progreso
        /// </summary>
        private void CheckRelation()
        {
            try
            {
                int season = 0, lastEpisode = 0;
                usersEpisodesDAO.LastEpisode(User.Id, SeriesEpi.Id, ref season, ref lastEpisode);

                Edit = season != 0;
                Add = !Edit;

                if (Edit)
                {
                    Episode = lastEpisode;
                    SeasonEpisodes = SeriesEpi.Episodes.Find(x => x.SeasonNumber == season);
                }
            }
            catch (Exception)
            {
                ShowErrorMessage(DB_ERROR);
            }
        }

        /// <summary>
        /// Este método verificará los datos y si están bien intentará añadir el progreso.
        /// </summary>
        [RelayCommand]
        public async void SaveProgress()
        {
            try
            {
                if (SeriesEpi != null && SeasonEpisodes != null && Episode != 0 && User != null)
                {
                    usersEpisodesDAO.AddProgress(SeriesEpi.Id, SeasonEpisodes.SeasonNumber, Episode, User.Id);
                    GoBack();
                }
                else
                {
                    ShowErrorMessage(EMPTY_FIELDS);
                }
            }
            catch (Exception)
            {
                ShowErrorMessage(DB_ERROR);
            }

        }

        /// <summary>
        /// Este método verificará los datos y si están bien intentará actualizar el progreso.
        /// </summary>
        [RelayCommand]
        public async void EditProgress()
        {
            try
            {
                if (SeriesEpi != null && SeasonEpisodes != null && Episode != 0 && User != null)
                {
                    int lastEpisode = 0, lastSeason = 0;
                    bool equalsSeason, increasedProgress;

                    //Averiguamos el último episodio que ha visto el usuario
                    usersEpisodesDAO.LastEpisode(User.Id, SeriesEpi.Id, ref lastSeason, ref lastEpisode);

                    equalsSeason = lastSeason == SeasonEpisodes.SeasonNumber;

                    //Vemos si el progreso a cambiado
                    if (!(equalsSeason && lastEpisode == Episode))
                    {
                        //Vemos si el progreso ha aumentado (vamos por un capítulo superior a la última vez)
                        increasedProgress = lastSeason < SeasonEpisodes.SeasonNumber || (lastSeason == SeasonEpisodes.SeasonNumber && lastEpisode < Episode);


                        if (equalsSeason)
                        {
                            usersEpisodesDAO.UpdateProgress(SeriesEpi.Id, lastSeason, lastEpisode, Episode, User.Id, increasedProgress);
                        }
                        else
                        {
                            usersEpisodesDAO.UpdateProgress(SeriesEpi.Id, lastSeason, SeasonEpisodes.SeasonNumber, lastEpisode, Episode, User.Id, increasedProgress);
                        }

                    }

                    GoBack();
                }
            }
            catch (Exception)
            {
                ShowErrorMessage(DB_ERROR);
            }
        }
        #endregion
    }
}
