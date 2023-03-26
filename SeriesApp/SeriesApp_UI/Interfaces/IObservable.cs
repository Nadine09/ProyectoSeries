using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeteoApp_UI.Interfaces
{
    public interface IObservable
    {
        /// <summary>
        /// Este metodo añadirá el IObserver pasado por parametros a la lista de observadores suscritos
        /// </summary>
        /// <param name="observer">Se añadirá a la lista de observadores suscritos</param>
        void AddObserver(IObserver observer);

        /// <summary>
        /// Este método notificará a todos los subscriptores el cambio en el objeto observado cuando ocurra.
        /// </summary>
        void NotifyAll();
    }
}
