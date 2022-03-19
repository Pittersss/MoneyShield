using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace TestsMoneyShield
{
    public class Ambitions
    {
        public static List<String> ambName;
        public static List<Double> value;
        public static int conter = -1;
        public static bool havePlans = true;
        public static bool moreAbm = true;

        public static void OrganizeAbm()
        { 
            Console.WriteLine("Você possui alguma meta/objetivo que dependa do seu dinheiro?  1- Sim  2- Não");
           
            if(Console.ReadLine() == "1")
            {
            while(moreAbm == true)
            {
            conter++;
            havePlans = true;
            Console.WriteLine("Dê um nome para o seu objetivo/meta");
            ambName.Add(Console.ReadLine());
            Console.WriteLine("Quanto dinheiro você precisa para atingir esse objetivo/meta?");
            value.Add(double.Parse(Console.ReadLine()));
                    //Adicionar mais ambições
                    DatabaseConnector.Connection();
                    string insertValue = "INSERT INTO mytests.usuario(metas) VALUES('" +ambName[conter].ToString() + "')";
                    
                    MySqlCommand comando = new MySqlCommand(insertValue, DatabaseConnector.connection);
                    MySqlDataReader dataReaderr;
                    dataReaderr = comando.ExecuteReader();
                    
                    DatabaseConnector.connection.Close();

                    Console.WriteLine("Você possui mais alguma meta/objetivo que dependa do seu dinheiro?  1- Sim  2- Não");
            
            if (Console.ReadLine() == "2")
            {
                havePlans = false;
                moreAbm = false;
            }
            }
            }   
        }
        

    }
}
