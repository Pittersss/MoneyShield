using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using MySql.Data.MySqlClient;

namespace TestsMoneyShield
{
    class Program
    {
        static void Main(string[] args)
        {
            //EM PRODUÇÃO
            DatabaseConnector.Connection();
            Ambitions.ambName = new List<string>();
            Ambitions.value = new List<double>();
            Menu menu = new Menu();
            menu.VisualMenu();
            
            Console.ReadKey();
        }
    }
}
