using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsMoneyShield
{
    public class Menu
    {
        public void inicialMenu()
        {
            Console.Clear();
            Console.WriteLine("** Menu **");
            Console.WriteLine("1- Cadastrar-se");
            Console.WriteLine("2- Mostrar Perfil");
            Console.WriteLine("3- Sair");
        }
        public void  MenuShow()
        {
            string index = Console.ReadLine();
            Profile pf = new Profile();
            //Inicio de um menu que vai se expandir
            while (index != "3")
            {
            switch(index)
              {
                case "1":
                    MainPage main = new MainPage();
                    main.oddJobCheck();
                    main.CalcAmbs();
                    index = "";
                    inicialMenu();
                    break;
                case "2":
                    pf.ShowProfile();
                        index = "";
                        inicialMenu();
                        break;
                case "3":
                    Console.WriteLine("Muito obrigado. Até mais!");
                        index = "";
                        inicialMenu();
                        break;    
              }
                
            }
            
        }
    }
}
