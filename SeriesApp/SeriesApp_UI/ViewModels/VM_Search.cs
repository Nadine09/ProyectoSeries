using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesApp_DAL.DAO;
using SeriesApp_Entities.Classes;
using SeriesApp_UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Search : ObservableObject
    {
        private SeriesDAO seriesDAO;

        [ObservableProperty]
        string serie;

        [ObservableProperty]
        ClsSeries selectedSerie;

        [ObservableProperty]
        string searchText;

        [ObservableProperty]
        List<ClsSeries> searchResult;

        public VM_Search()
        {
            seriesDAO = new SeriesDAO();
            searchResult = seriesDAO.GetAll();
            Serie = "No se ha añadido ninguna todavía";
        }

        [RelayCommand]
        public async Task AddSerie(ClsSeries series)
        {
            Serie = $"Serie -> Id: {series.Id} Nombre: {series.Name}";
        }

        [RelayCommand]
        public async Task SeriesDetails(ClsSeries series)
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Series", series);
            await Shell.Current.GoToAsync("/SeriesDetailsPage", dictionary);

            //await Shell.Current.GoToAsync("SeriesDetailsPage", new Dictionary<string, object>
            //{
            //    {"Series", series}
            //});
            //await Shell.Current.GoToAsync($"/SeriesDetailsPage?Id={series.Id}&Name={series.Name}&ImageUrl={series.ImageUrl}&Synopsis={series.Synopsis}");
        }
    }
}
