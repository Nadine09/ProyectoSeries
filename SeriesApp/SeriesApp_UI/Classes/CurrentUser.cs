
using LeteoApp_UI.Interfaces;
using SeriesApp_Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeteoApp_UI.Classes
{
    public class CurrentUser : IObservable
    {
        #region Propiedades
        private static CurrentUser _instance;

        private List<IObserver> observers;

        private ClsUser user;
        public ClsUser User
        {
            get { return user; }
            set
            {
                this.user = value;
                NotifyAll();
            }
        }
        #endregion

        #region Constructores       
        private CurrentUser()
        {
            observers = new List<IObserver>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Este método devuelve la instancia de CurrentUser almacenada. En caso de que no haya una instancia ya 
        /// almacenada esta se crea, se guarda y después se devuelve.
        /// </summary>
        /// <returns>Instancia de CurrentUser</returns>
        public static CurrentUser GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CurrentUser();
            }
            return _instance;
        }

        public void AddObserver(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void NotifyAll()
        {
            foreach (IObserver observer in observers)
            {
                observer.Notify();
            }
        }
        #endregion

    }
}