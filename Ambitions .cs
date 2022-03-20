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
        public static bool havePlans = false;

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
            }


            void Addabm()
            {
                while (havePlans == true)
                {
                    conter++;
                    Console.WriteLine("Dê um nome para o seu objetivo/meta");
                    ambName.Add(Console.ReadLine());
                    Console.WriteLine("Quanto dinheiro você precisa para atingir esse objetivo/meta?");
                    value.Add(double.Parse(Console.ReadLine()));
                    //Adicionar mais ambições        
                    /*string insertValue = "INSERT INTO mytests.usuario(metas) VALUES('" + ambName[conter].ToString() + "')";
                    if(DatabaseConnector.connection.State == System.Data.ConnectionState.Closed)
                    {
                        DatabaseConnector.connection.Open();
                    }
                    MySqlCommand comando = new MySqlCommand(insertValue, DatabaseConnector.connection);
                    MySqlDataReader dataReaderr;
                    dataReaderr = comando.ExecuteReader();
                    DatabaseConnector.connection.Close();
                    */

                    SetDataInBD();
                    Console.WriteLine("Você possui mais alguma meta/objetivo que dependa do seu dinheiro?  1- Sim  2- Não");
                    if (Console.ReadLine() == "2")
                    {
                        havePlans = false;
                    }

                }
                
            }
            
        }

        public static void SetDataInBD()
        {
            MainPage.isRegister = 1;
            string insertProfileValue = "INSERT INTO mytests.usuario(nome, emprego, idade_, cpf_, isRegister, salario, rendaLiquida, metas, metasIndex) VALUES('" +MainPage.name + "', '" + MainPage.mainJob + "', '" + MainPage.age + "', '" + MainPage.cpf + "', '" + MainPage.isRegister + "' , '" + MainPage.rent + "' , '" + MainPage.actualMoney + "', '" + ambName[conter].ToString() + "', '" + conter + "')";
            MySqlCommand comando = new MySqlCommand(insertProfileValue, DatabaseConnector.connection);
            MainPage.dataReader = comando.ExecuteReader();
            MainPage.dataReader.Close();
            if (DatabaseConnector.connection.State == System.Data.ConnectionState.Closed)
            {
                DatabaseConnector.connection.Open();
            }
            if (comando.ExecuteNonQuery() == 1)
            {
                Console.WriteLine("Eureka 2.0");
            }
            else
            {
                Console.Write("Volte ao trabalho");
            }
        }


    }
}
