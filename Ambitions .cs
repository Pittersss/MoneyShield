using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.IO;

namespace TestsMoneyShield
{
    public class Ambitions 
    {
        public static List<String> ambName;
        public static List<Double> value;
        public static int conter = -1;
        public static bool havePlans = false;
        public static string[] lines = new string[5];
        public static void OrganizeAbm()
        {
            Console.WriteLine("Você possui alguma meta/objetivo que dependa do seu dinheiro?  1- Sim  2- Não");
            if (Console.ReadLine() == "1")
            {
                havePlans = true;
                Addabm();
            }
            if (Console.ReadLine() == "2")
            {
                havePlans = false;
                Console.WriteLine("Passei por aqui");
            }
         
        }


        static void Addabm()
        {

            while (havePlans == true)
            {
                Console.WriteLine("Dê um nome para o seu objetivo/meta");
                //Salvando dados das metas em um arquivo
                ambName.Add(Console.ReadLine());
                Console.WriteLine("Quanto dinheiro você precisa para atingir esse objetivo/meta?");
                value.Add(double.Parse(Console.ReadLine()));
                conter++;
                Console.WriteLine("Você possui mais alguma meta/objetivo que dependa do seu dinheiro?  1- Sim  2- Não");
                if (Console.ReadLine() == "2")
                {
                    havePlans = false;
                }
                
            }
            StreamWriter writer = new StreamWriter("D:\\sample.txt");
            for (int i = 0; i < conter + 1; i++)
            {
                writer.WriteLine(ambName[i]);
            }

        }
    }
}
