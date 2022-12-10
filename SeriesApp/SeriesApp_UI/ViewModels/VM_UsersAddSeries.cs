﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesApp_DAL.DAO;
using SeriesApp_UI.Utils;

namespace SeriesApp_UI.ViewModels
{
    [QueryProperty("Series", "Series")]
    public partial class VM_UsersAddSeries : VM_Base, IQueryAttributable
    {
        #region Properties
        private SeriesConverter converter;
        private UsersEpisodesDAO usersEpisodesDAO;
        private UsersSeriesDAO usersSeriesDAO;

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
            usersSeriesDAO = new UsersSeriesDAO();
        }
        #endregion

        #region Methods
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Object obj;
            bool hasValue = query.TryGetValue("Series", out obj);

            if (hasValue)
            {
                SeriesEpi = converter.ConvertToSeriesWithEpisodesPerSeason((ClsSeries)obj);
                CheckRelation();
            }
            else
            {
                throw new Exception();
            }
        }

        private void CheckRelation()
        {
            Edit = usersSeriesDAO.UserHasSeries(User.Id, SeriesEpi.Id);
            Add = !Edit;
        }

        [RelayCommand]
        public async void SaveProgress()
        {
            if (SeriesEpi != null && SeasonEpisodes != null && Episode != 0 && User != null)
            {
                usersEpisodesDAO.AddProgress(SeriesEpi.Id, SeasonEpisodes.SeasonNumber, Episode, User.Id);
                usersSeriesDAO.UserAddSeries(User.Id, SeriesEpi.Id);
                GoBack();
            }
        }

        [RelayCommand]
        public async void EditProgress()
        {
            if (SeriesEpi != null && SeasonEpisodes != null && Episode != 0 && User != null)
            {
                int lastEpisode = 0, lastSeason = 0;
                bool equalsSeason, increasedProgress;

                //Averiguamos el último episodio que ha visto el usuario
                usersEpisodesDAO.LastEpisode(User.Id, SeriesEpi.Id, ref lastSeason, ref lastEpisode);

                equalsSeason = lastSeason == SeasonEpisodes.SeasonNumber;
                
                //Vemos si el progreso a cambiado
                if (!(lastSeason == SeasonEpisodes.SeasonNumber && lastEpisode == Episode)) 
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
        #endregion
    }
}
