using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TestsMoneyShield
{
    //Classe abstrata focada na conexão com o banco de dados
    class DatabaseConnector
    {
        public static string strConnection = "datasource=localhost;database=mytests;port=3306;username=root;password=";
        private static bool canConnect = true;
        public static MySqlConnection connection;
        public static void Connection()
        {
            try
            {
                //Verificação de funcionalidade
                connection = new MySqlConnection(strConnection);
                connection.Open();
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Eureka");
                    canConnect = false;
                }
                else
                {
                    Console.WriteLine("Volte ao trabalho");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           
        }
    }
}
