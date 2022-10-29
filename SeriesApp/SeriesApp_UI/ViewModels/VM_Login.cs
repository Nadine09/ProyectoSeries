using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    public class VM_Login
    {
        private static string text = "BINDING Funcionaaa !";

        private int number;
        public int Number { get { return number; } set { number = value; } }


        public VM_Login()
        {
            Valor = text;
        }

        public string Valor { get; set; }




    }
}
