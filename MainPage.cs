﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsMoneyShield
{
    public class MainPage
    {
        ///Variáveis que não podem perder o valor, devem ser fixas nos valores impostos
        public static string name, mainJob, oddJobName;
        public static double age;
        public static double rent, oddRent;
        public static double expenses = 0.0;
        public static bool haveOddJob;
        public static double actualMoney;

        ///Variáveis Voláteis 
        public double[] oddjob;
        public int indexOddJob;
        public bool Oddfortnightly, OddeveryWeek, Oddmonthly, Odddaily;
        public bool fortnightly, everyWeek, monthly, other;
        public bool fortnightlyExt, everyWeekExt, monthlyExt, dailyExt;
        
        ////Inicialização de Funções que vão construir a página central da aplicação

        //Cadastro do usuário
        public void MainPageIntro()
        {
            Console.WriteLine("Qual é o seu nome?");
            name = Console.ReadLine();
            Console.WriteLine("Qual é a sua idade?");
            age = Convert.ToDouble(Console.ReadLine()); 
            //Análise de renda
            Console.WriteLine("Qual é o seu emprego principal?");
            mainJob = Console.ReadLine();
            Console.WriteLine("Qual é a sua renda nesse emprego?");
            rent = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Você recebe de forma: 1.Quinzenal, 2.Mensal ou 3.Semanal? Caso seja de outro modo digite 4");
            int geralInts = int.Parse(Console.ReadLine());
            switch(geralInts)
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
        public void oddJobCheck()
        {
            //ampliar o calculo de renda para pessoas que teem outras fontes de dinheiro
         Console.WriteLine("Você possui alguma outra fonte de renda? Digite 1 para 'Sim' ou digite 2 para 'Não'");
         if (Convert.ToString(Console.ReadLine()) == "1")
         {
                haveOddJob = true;
                OddJobs();
                CalcExpenses();
         }
        if (Convert.ToString(Console.ReadLine()) == "2")
        {
          haveOddJob = false;
         
        }
            CalcExpenses();
        }
        public void OddJobs()
        {
            if (haveOddJob == true)
            {
                //Quantas rendas extras você tem
            double result = 0;
            Console.WriteLine("Quantos você tem?");
            indexOddJob = int.Parse(Console.ReadLine());
            oddjob = new double[indexOddJob];
            double[] oddjobRent = new double[indexOddJob];
            //Repetição da análise de ganhos a mais para juntar no cálculo final
            //Sempre com uma consideração mensal
                foreach (double s in oddjob)
                {
                    Console.WriteLine("Qual é o seu cargo na sua renda extra?");
                    oddJobName = Console.ReadLine();
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
                            break;
                        case 2:
                            everyWeekExt = true;
                            break;
                        case 3:
                            dailyExt = true;
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
            Console.WriteLine("NOME: " + name.ToUpper());
            Console.WriteLine("IDADE: " + age);
            Console.WriteLine("EMPREGO: " + mainJob.ToUpper());
            Console.WriteLine("SALÁRIO: " + rent);
            Console.WriteLine("RENDA LÍQUIDA: " + actualMoney);
        }
        //Calculara quanto tempo preciso juntar dinheiro para comprar algo que desejo
        public void CalcAmbs()
        {
            Ambitions.OrganizeAbm();
            double calculo;
            calculo = Ambitions.value[Ambitions.arrayIndex] / actualMoney;
            Console.WriteLine("Você terá que guardar do dinheiro que lhe sobra, por aproximadamente {0} meses", Convert.ToInt32(calculo));
        }
    }
}
