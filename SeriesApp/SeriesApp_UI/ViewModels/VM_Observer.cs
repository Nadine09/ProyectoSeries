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
    /// <summary>
    /// Clase que heredarán todos los ViewModel que se necesite que observen 
    /// el CurrentUser
    /// </summary>
    public partial class VM_Observer : VM_Base, IObserver
    {
        #region Propiedades
        private IObservable observable;

        [ObservableProperty]
        ClsUser user;
        #endregion

        #region Constructores
        public VM_Observer() : base()
        {
            //Inicializamos el observable y nos suscribimos
            observable = CurrentUser.GetInstance();
            observable.AddObserver(this);
            Notify();
        }
        #endregion

        #region Métodos        
        public void Notify()
        {
            //Actualizamos la propiedad User
            this.User = ((CurrentUser) observable).User;
        }
        #endregion
    }
}
