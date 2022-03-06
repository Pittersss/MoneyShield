using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace TestsMoneyShield
{
    class Program
    {
        static void Main(string[] args)
        {
            //EM PRODUÇÃO
            Menu menu = new Menu();
            menu.VisualMenu();

            Console.ReadKey();
        }
    }
}
