using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesApp_DAL.DAO;
using SeriesApp_Entities.Classes;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace SeriesApp_UI.ViewModels
{
    [QueryProperty("UserId", "UserId")]
    public partial class VM_Home : ObservableObject
    {
        private SeriesDAO seriesDAO;

        [ObservableProperty]
        List<ClsSeries> newSeries;

        [ObservableProperty]
        List<ClsSeries> top10Series;

        [ObservableProperty]
        ClsUser userId;

        public VM_Home()
        {
            //newSeries = new ObservableCollection<ClsSeries>();
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu", "https://w0.peakpx.com/wallpaper/574/104/HD-wallpaper-haikyuu-anime-all-characters-anime.jpg"));
            //newSeries.Add(new ClsSeries("Haikyuu 2", "https://image.tmdb.org/t/p/original/3TUUTiiuvjKg8BcnrGbuuj2Ov5L.jpg"));

            seriesDAO = new SeriesDAO();
            newSeries = seriesDAO.GetAll();
            top10Series = seriesDAO.GetTop10();
        }

        [RelayCommand]
        void Refresh()
        {
            Top10Series = seriesDAO.GetTop10();
        }

        [ObservableProperty]
        long serieId;

        [RelayCommand]
        void AddSerie()
        {
            SerieId = 1;
        }

    }
}
