using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    public abstract partial class VM_Base : ObservableObject
    {
        [ObservableProperty]
        ClsUser user;

        protected VM_Base()
        {
            User = App.Current.User;
        }
    }
}
