using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesApp_DAL.DAO;
using SeriesApp_Entities.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_UserSeries : ObservableObject
    {
        [ObservableProperty]
        List<ClsSeries> series;

        private long userId;

        private SeriesDAO seriesDAO;

        public VM_UserSeries()
        {
            GetUserId();
            seriesDAO = new SeriesDAO();
            Series = seriesDAO.GetByUser(userId);
        }

        private async void GetUserId()
        {
            userId = long.Parse(await SecureStorage.Default.GetAsync("Account"));
        }

        [RelayCommand]
        void Refresh()
        {
            seriesDAO = new SeriesDAO();
            Series = seriesDAO.GetByUser(userId);
        }
    }
}
