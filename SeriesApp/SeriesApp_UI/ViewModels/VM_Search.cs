using CommunityToolkit.Mvvm.ComponentModel;
using SeriesApp_Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Search : ObservableObject
    {
        [ObservableProperty]
        string searchText;

        [ObservableProperty]
        List<ClsSeries> searchResult;
    }
}
