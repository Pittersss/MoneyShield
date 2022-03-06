using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TestsMoneyShield
{
    public class Ambitions
    {
        public static int arrayIndex = -1;
        public static string[] ambName;
        public static double[] value;
        
        public static void OrganizeAbm()
        {
            arrayIndex++;
            Console.WriteLine("Dê um nome para o seu objetivo/meta");
            ambName[arrayIndex] = Console.ReadLine();
            Console.WriteLine("Quanto dinheiro você precisa para atingir esse objetivo/meta?");
            value[arrayIndex] = double.Parse(Console.ReadLine());
            
        }
        

    }
}
