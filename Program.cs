using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using MySql.Data.MySqlClient;
using System.IO;

namespace TestsMoneyShield
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //EM PRODUÇÃO
            DatabaseConnector.Connection();
            MainPage.InicializeBD();  
            Menu menu = new Menu();
            menu.VisualMenu();
            Console.ReadKey();
        }
    }
}
