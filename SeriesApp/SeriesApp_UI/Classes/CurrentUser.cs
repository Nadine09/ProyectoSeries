
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
        #region Singleton
        private static CurrentUser _instance;

        private CurrentUser()
        {
            observers = new List<IObserver>();
        }

        public static CurrentUser GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CurrentUser();
            }
            return _instance;
        }
        #endregion

        private ClsUser user;

        public ClsUser User {
            get { return user; } 
            set {
                this.user = value;
                NotifyAll();
            } 
        }

        private List<IObserver> observers;           

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

    }
}
