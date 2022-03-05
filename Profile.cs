using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsMoneyShield
{
   static class Profile
    {

        //EM PRODUÇÃO
        public static string user_Name;
        public static double age;
        public static string main_Occupation;
        static public bool[] oddJob;
        public static string[] goals;

        public static void ShowProfile()
        {
            try
            {

            Console.WriteLine("NOME: " + user_Name.ToUpper());
            Console.WriteLine("IDADE: " + age);
            Console.WriteLine("EMPREGO: " + main_Occupation.ToUpper());
          
            Menu menu = new Menu(); 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            Console.ReadKey();
        }
    }
}
