using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace TestsMoneyShield
{
    public class MainPage
    {
        ///Variáveis que não podem perder o valor, devem ser fixas nos valores impostos

        public static string name, mainJob;
        public static List<String> oddJobName = new List<string>();
        public static double age, cpf;
        public static double rent, oddRent;
        public static double expenses = 0.0;
        public static bool haveOddJob;
        public static Int16 isRegister = 0;
        public static double actualMoney;
        public static MySqlDataReader dataReader;

        ///Variáveis Voláteis 

        public double[] oddjob;
        public int indexOddJob;
        private bool Oddfortnightly, OddeveryWeek, Oddmonthly, Odddaily;
        private bool fortnightly, everyWeek, monthly, other;
        private bool fortnightlyExt, everyWeekExt, monthlyExt, dailyExt;
        
        ////Inicialização de Funções que vão construir a página central da aplicação

        //Cadastro do usuário
        public void MainPageIntro()
        {                  
            if (isRegister == 0)
            {
                Console.WriteLine("Qual é o seu nome?");
                name = Console.ReadLine();
                Console.WriteLine("Qual é a sua idade?");
                age = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Qual é o seu CPF?");
                cpf = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Qual é o seu emprego principal?");
                mainJob = Console.ReadLine();
                Console.WriteLine("Qual é a sua renda nesse emprego?");
                rent = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Você recebe de forma: 1.Quinzenal, 2.Mensal ou 3.Semanal? Caso seja de outro modo digite 4");
                int geralInts = int.Parse(Console.ReadLine());

                //Ainda faltam otimizações
                switch (geralInts)
                {
                    case 1:
                        fortnightly = true;
                        break;
                    case 2:
                        monthly = true;
                        break;
                    case 3:
                        everyWeek = true;
                        break;
                    case 4:
                        other = true;
                        break;
                }
                Console.WriteLine("Seja bem vindo {0}, agora você terá a possibilidade de organizar as suas finaças de maneira simples gratuitamente", name);
            }
            else
            {
                Console.Write("Você já tem cadastro!");
            }
        }
        public void oddJobCheck()
        {
            if (isRegister == 0)
            {
                //ampliar o calculo de renda para pessoas que teem outras fontes de dinheiro
                Console.WriteLine("Você possui alguma outra fonte de renda? Digite 1 para 'Sim' ou digite 2 para 'Não'");
                if (Convert.ToString(Console.ReadLine()) == "1")
                {
                    haveOddJob = true;
                    OddJobs();
                }
                if (Convert.ToString(Console.ReadLine()) == "2")
                {
                    haveOddJob = false;

                }
                CalcExpenses();
            }
        }
        public void OddJobs()
        {
            if (haveOddJob == true)
            {
                //Quantas rendas extras você tem
            double result = 0;
            Console.WriteLine("Quantas rendas extra você tem?");
            indexOddJob = int.Parse(Console.ReadLine());
            oddjob = new double[indexOddJob];
            double[] oddjobRent = new double[indexOddJob];
            //Repetição da análise de ganhos a mais para juntar no cálculo final
            //Sempre com uma consideração mensal
                foreach (double s in oddjob)
                {
                    Console.WriteLine("Qual é o seu cargo na sua renda extra?");
                    oddJobName.Add(Console.ReadLine());
                    Console.WriteLine("Lá você recebe 1.diariamente, 2.semanalmente, 3.quinzenalmente ou 4.mensalmente? Digite o número correspondente");
                    result = double.Parse(Console.ReadLine());
                    switch (result)
                    {
                        case 1:
                            Console.WriteLine("Quanto você recebe?");
                            oddjobRent[Convert.ToInt64(s)] = double.Parse(Console.ReadLine());
                            Odddaily = true;
                            rent += oddjobRent[Convert.ToInt64(s)] * 30;
                            break;
                        case 2:
                            Console.WriteLine("Quanto você recebe?");
                            oddjobRent[Convert.ToInt64(s)] = double.Parse(Console.ReadLine());
                            OddeveryWeek = true;
                            rent += oddjobRent[Convert.ToInt64(s)] * 4;
                            break;
                        case 3:
                            Console.WriteLine("Quanto você recebe?");
                                oddjobRent[Convert.ToInt64(s)] = double.Parse(Console.ReadLine());
                                Oddfortnightly = true;
                                rent += oddjobRent[Convert.ToInt64(s)] * 2;
                            break;
                        case 4:
                            Console.WriteLine("Quanto você recebe?");
                                oddjobRent[Convert.ToInt64(s)] = double.Parse(Console.ReadLine());
                                Oddmonthly = true;
                                rent += oddjobRent[Convert.ToInt64(s)];
                            break;    
                    }     
                }
            }
            else
            {
             Console.WriteLine("Parabéns seu cadastro foi concluído! {0} A sua renda é {1} ", name, rent);
            }
            
        }

        //Calculador de dispesas para mostrar o que resta do salário
        public void CalcExpenses()
        {
            if(monthly == true)
            {
            Console.WriteLine("Quanto você gasta em despesas, {0}?", "Mensalmente");
            expenses += double.Parse(Console.ReadLine());
            actualMoney = rent - expenses;
            Console.WriteLine("Sobra para você mensalmente {0}", (actualMoney));
            }
            if (fortnightly == true)
            {
              Console.WriteLine("Quanto você gasta em despesas, aproximadamente {0}?", "Quinzenalmente");
              expenses += double.Parse(Console.ReadLine()) * 2;
              actualMoney = rent - expenses;             
            }
            if (everyWeek == true)
            {
              Console.WriteLine("Quanto você gasta em despesas, {0}?", "Semanalmente");
              expenses += double.Parse(Console.ReadLine()) * 4;
              actualMoney = rent - expenses;
                Console.WriteLine("Sobra para você mensalmente, aproximadamente {0}", (actualMoney));
            }

            Console.WriteLine("Você paga mais despesas, mas em outro período de tempo? Como curso, passagens de transporte público etc 1.Sim ou 2.Não");
            CalcOthersExps();
            
            
        }
        //Ás vezes só colocamos no papel o que gatamos no geral, mas tudo desde um salgado na rua a uma passagem conta
        //Por esse motivo temos esse função
        public void CalcOthersExps()
        {
            if (Convert.ToString(Console.ReadLine()) == "1")
            {
                Console.Clear();
                Console.WriteLine("Quantas?");
                //Array caso você tenha mais de um dispesa extra e repetir a lógica no foreach abaixo
                int[] otherExpens = new int[int.Parse(Console.ReadLine())];
                
                foreach (int y in otherExpens)
                {
                    Console.WriteLine("Você paga de forma: 1.Quinzenal, 2.Semanal, 3.Diária? Caso seja de outro modo digite 4");
                    int geralInts = int.Parse(Console.ReadLine());
                    switch (geralInts)
                    {
                        case 1:
                            fortnightlyExt = true;
                            everyWeekExt = false;
                            dailyExt = false;
                            break;
                        case 2:
                            everyWeekExt = true;
                            fortnightlyExt = false;
                            dailyExt = false;
                            break;
                        case 3:
                            dailyExt = true;
                            fortnightlyExt = false;
                            everyWeekExt = false;
                            break;
                    }
                    if (fortnightlyExt)
                    {
                        Console.WriteLine("Quanto você gasta em despesas, {0}?", "Quinzenalmente");
                        expenses += double.Parse(Console.ReadLine()) * 2;
                        actualMoney = rent - expenses;
                        Console.WriteLine("Sobra para você mensamente, aproximadamente {0}", (actualMoney));
                    }

                    if (everyWeekExt)
                    {
                        Console.WriteLine("Quanto você gasta em despesas, aproximadamente {0}?", "Semanalmente");
                        expenses += double.Parse(Console.ReadLine()) * 4;
                        actualMoney = rent - expenses;
                        Console.WriteLine("Sobra para você {0}", (actualMoney));
                    }


                    if (dailyExt)
                    {
                        Console.WriteLine("Quanto você gasta em despesas, {0}?", "Diariamente");
                        double otherExp = double.Parse(Console.ReadLine()) * 30;
                        expenses += otherExp;
                        actualMoney = rent - expenses;
                        Console.WriteLine("Sobra para você mensalmente, aproximadamente {0}", (actualMoney));
                    }

                }

            }
            if (Convert.ToString(Console.ReadLine()) == "2")
            {
                Console.WriteLine("Sobra para você {0}", (actualMoney));
            }
        }
        public void ShowProfile()
        {
            //Mostrar o perfil
            try
            {       
                if(haveOddJob)
                {
                    Console.WriteLine("NOME: " + name.ToUpper());
                    Console.WriteLine("IDADE: " + age);
                    Console.WriteLine("CPF: " + cpf);
                    Console.WriteLine("EMPREGO: " + mainJob.ToUpper());
                    Console.WriteLine("SERVIÇOS SECUNDÁRIOS " + String.Join(", ", oddJobName));
                    Console.WriteLine("SALÁRIO: " + rent);
                    Console.WriteLine("RENDA LÍQUIDA: " + actualMoney);
                    Console.WriteLine("METAS/OBJETIVOS: " + String.Join(", ", Ambitions.ambName));
                }
                else
                {
                    Console.WriteLine("NOME: " + name.ToUpper());
                    Console.WriteLine("IDADE: " + age);
                    Console.WriteLine("CPF: " + cpf);
                    Console.WriteLine("EMPREGO: " + mainJob.ToUpper());
                    Console.WriteLine("SALÁRIO: " + rent);
                    Console.WriteLine("RENDA LÍQUIDA: " + actualMoney);
                    Console.WriteLine("METAS/OBJETIVOS: " + String.Join(", ", Ambitions.ambName));
                }
            
            }
            //Caso o usuário tente ver o perfil, sem ter criado um
            catch(Exception ex)
            {
                Console.WriteLine("Crie um perfil para vizualiza-lo em 'Cadastrar-se'!");
            }
            
        }
        //Calculara quanto tempo preciso juntar dinheiro para comprar algo que desejo
        public void CalcAmbs()
        {
            if (isRegister == 0)
            {  
                
                Ambitions.OrganizeAbm();
                double calculo;
                if (Ambitions.havePlans == true)
                {
                    calculo = Ambitions.value.Last<Double>() / actualMoney;
                    if (calculo <= 12)
                    {
                        Console.WriteLine("Você terá que guardar do dinheiro que lhe sobra, por aproximadamente {0} meses", Convert.ToInt32(calculo));
                    }
                    else
                    {
                        Console.WriteLine("Você terá que guardar do dinheiro que lhe sobra, por aproximadamente {0} anos", Convert.ToInt32(calculo) / 12);
                    }  
                }
                isRegister = 1;
               

            }      
                    string insertProfileValue = "INSERT INTO mytests.usuario(nome, emprego, idade_, cpf_, isRegister, salario, rendaLiquida) VALUES('" + MainPage.name + "', '" + MainPage.mainJob + "', '" + MainPage.age + "', '" + MainPage.cpf + "', '" + MainPage.isRegister + "' , '" + MainPage.rent + "' , '" + MainPage.actualMoney + "')";
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
        public static void InicializeBD()
        {
            //Tentando ler os dados do banco de dados e verificar se o usuario tem ou não cadastro
            string selectQuery = "SELECT * FROM mytests.usuario";
            MySqlCommand cmdSelectQuery = new MySqlCommand(selectQuery, DatabaseConnector.connection);
            try
            {
                int i = 0;
                dataReader = cmdSelectQuery.ExecuteReader();
                if (dataReader.Read())
                {
                    isRegister = dataReader.GetInt16("isRegister");
                    name = dataReader.GetString("nome");
                    age = dataReader.GetDouble("idade_");
                    cpf = dataReader.GetDouble("cpf_");
                    Console.WriteLine(i);      
                    mainJob = dataReader.GetString("emprego");
                    if (dataReader.IsDBNull(2) == false)
                        oddJobName.Add(dataReader.GetString("rendaSecundaria"));
                    rent = dataReader.GetDouble("salario");
                    actualMoney = dataReader.GetDouble("rendaLiquida");
                }
            }
            finally
            {
                dataReader.Close();
            }
        }
    }
}
