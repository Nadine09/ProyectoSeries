using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeteoApp_UI.Interfaces
{
    public interface IObserver
    {
        /// <summary>
        /// Este método se ejecutara cuando el observable al que se haya suscrito este 
        /// observer detecte un cambio en el objeto observado
        /// </summary>
        void Notify();
    }
}
