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
        public static List<String> ambName = new List<string>();
        public static List<String> value = new List<string>();
        public static string caminho = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        public static int conter = -1;
        public static bool havePlans = false;
        public static string[] lines = new string[5];
        public static int x = 0;
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
                conter++;
                //Como escrever em um arquivo já existendo no computador
                if(conter == 0)
                using (StreamWriter writer = new StreamWriter("metas.txt"))
                {
                    writer.WriteLine(ambName[conter]);
                }
                if (conter > 0)
                using(StreamWriter writer = new StreamWriter(@"C:\Users\Pedro\source\repos\TestsMoneyShield\TestsMoneyShield\bin\Debug\metas.txt", true))
                {
                  writer.WriteLine(ambName[conter]);
                }
                //Como escrever um arquivo e já escrever nele
                /*
                 using(StreamWriter writer = new StreamWriter(Novoteste.txt", true))
                {
                  writer.WriteLine("Puts");
                }
                */
                Console.WriteLine("Quanto dinheiro você precisa para atingir esse objetivo/meta?");
                value.Add((Console.ReadLine()));
                MainPage.TimeToDoAmbitions();
                //Armezara quanto custa os seus objetivos\metas
                if (conter == 0)
                    using (StreamWriter writer = new StreamWriter("valores.txt"))
                    {
                        writer.WriteLine(value[conter]);
                    }
                if (conter > 0)
                    using (StreamWriter writer = new StreamWriter(@"C:\Users\Pedro\source\repos\TestsMoneyShield\TestsMoneyShield\bin\Debug\valores.txt", true))
                    {
                        writer.WriteLine(value[conter]);
                    }
                //Armazena os meses que você terá que juntar dinheiro
                if (conter == 0)
                    using (StreamWriter writer = new StreamWriter("meses.txt"))
                    {
                        writer.WriteLine(MainPage.TimeAbm[conter]);
                    }
                if (conter > 0)
                    using (StreamWriter writer = new StreamWriter(@"C:\Users\Pedro\source\repos\TestsMoneyShield\TestsMoneyShield\bin\Debug\meses.txt", true))
                    {
                        writer.WriteLine(MainPage.TimeAbm[conter]);
                    }
                Console.WriteLine("Você possui mais alguma meta/objetivo que dependa do seu dinheiro?  1- Sim  2- Não");
                if (Console.ReadLine() == "2")
                {
                    havePlans = false;
                }     
            }
        }
        public static void LoadAmbitions()
        {
            string[] linesAbm = System.IO.File.ReadAllLines(@"C:\Users\Pedro\source\repos\TestsMoneyShield\TestsMoneyShield\bin\Debug\metas.txt");
            string[] linesValues = System.IO.File.ReadAllLines(@"C:\Users\Pedro\source\repos\TestsMoneyShield\TestsMoneyShield\bin\Debug\valores.txt");
            string[] mesesValues = System.IO.File.ReadAllLines(@"C:\Users\Pedro\source\repos\TestsMoneyShield\TestsMoneyShield\bin\Debug\meses.txt");

            //ambName = new List<string>();
            for (x = 0; x < linesAbm.Length; x++)
            {     
                //Carregando os dados que estão em arquivos
                ambName.Add(linesAbm[x]);
                value.Add(linesValues[x]);
                MainPage.TimeAbm.Add(mesesValues[x]);
            }
        }
    }
}
