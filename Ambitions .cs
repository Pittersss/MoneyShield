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
        public static List<String> ambName;
        public static List<Double> value;
        public static int ja = 0;
        public static bool havePlans = true;


        public static void OrganizeAbm()
        {
            Console.WriteLine("Você possui alguma meta/objetivo que dependa do seu dinheiro?  1- Sim  2- Não");
            if(Console.ReadLine() == "1")
            {
            havePlans = true;
            Console.WriteLine("Dê um nome para o seu objetivo/meta");
            ambName.Add(Console.ReadLine());
            Console.WriteLine("Quanto dinheiro você precisa para atingir esse objetivo/meta?");
            value.Add(double.Parse(Console.ReadLine()));
            }
            else
            {
                havePlans = false;
            }
            
        }
        

    }
}
