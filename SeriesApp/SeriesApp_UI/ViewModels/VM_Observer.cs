using CommunityToolkit.Mvvm.ComponentModel;
using LeteoApp_UI.Classes;
using LeteoApp_UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeteoApp_UI.ViewModels
{
    public partial class VM_Observer : VM_Base, IObserver
    {
        private IObservable observable;

        [ObservableProperty]
        ClsUser user;

        public VM_Observer() : base()
        {
            observable = CurrentUser.GetInstance();
            observable.AddObserver(this);
            Notify();
        }

        public void Notify()
        {
            this.User = ((CurrentUser) observable).User;
        }
    }
}
