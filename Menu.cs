using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsMoneyShield
{
    public class Menu
    {
        private MainPage main = new MainPage();
        public void VisualMenu()
        {
            Console.Clear();
            Console.WriteLine("** Menu **");
            Console.WriteLine("1- Cadastrar-se");
            Console.WriteLine("2- Mostrar Perfil");
            Console.WriteLine("3- Adicionar Meta/Objetivo");
            Console.WriteLine("4- Sair");
            MenuLogic();
        }
        public void  MenuLogic()
        {
            Console.WriteLine("Escreva o número da opção desejada");
            int index = int.Parse(Console.ReadLine());
           
            //Inicio de um menu que vai se expandir
            while (index != 5)
            {
            switch(index)
              {
                case 1:
                    main.MainPageIntro();
                    main.oddJobCheck();
                    main.CalcAmbs();
                    break;
                case 2:
                    main.ShowProfile();
                        break;
                case 3:
                    Ambitions.OrganizeAbm();
                    break;
                case 4:
                    Console.WriteLine("Muito obrigado. Até mais!");
                    break;
                case 5: break;
                default: Console.WriteLine("Opção Inválida");
                break;

              }
                if (index != 6)
                {
                    Console.WriteLine();
                    Console.Write("Tecla [ENTER] para continuar");
                    Console.ReadLine();
                }
                    VisualMenu();
                index = int.Parse(Console.ReadLine());
            }
            Console.ReadKey();
        }
        
    }
}
