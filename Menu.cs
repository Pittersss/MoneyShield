using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsMoneyShield
{
    public class Menu
    {
        public MainPage menu;
        public Menu()
        {
            
            //Inicio de um menu qque vai se expandir
            Console.WriteLine("** Menu **");
            Console.WriteLine("1- Cadastrar-se");
            Console.WriteLine("2- Mostrar Perfil");
            Console.WriteLine("3- Sair");
            if (Console.ReadLine() == "1")
            {
                menu = new MainPage();
                menu.oddJobCheck();
                menu.CalcAmbs();      
            }
            if(Console.ReadLine() == "2")
            {
                Profile.ShowProfile();
            }
            if(Console.ReadLine() == "3")
            {
                Console.WriteLine("Obrigado por utilizar a minha aplicação");
            }
        }
    }
}
