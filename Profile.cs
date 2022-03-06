using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsMoneyShield
{
    class Profile
    {

        //EM PRODUÇÃO
        public static string user_Name;
        public static double age;
        public static string main_Occupation;
        static public bool[] oddJob;
        public static string[] goals;

        public void ShowProfile()
        {
            MainPage main = new MainPage();
         
             //Tenta mostrar os dados do usuário
            Console.WriteLine("NOME: " + main.name.ToUpper());
            Console.WriteLine("IDADE: " + main.age);
            Console.WriteLine("EMPREGO: " + main.mainJob.ToUpper());
          
            Console.ReadKey();
        }

    }
}
