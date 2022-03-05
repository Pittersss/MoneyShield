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
        public string[] Ambname = new string[3];
        public double[] value = new double[3];
        public void OrganizeAbm()
        {

            Console.WriteLine("Qual o nome do seu objetivo ou meta, como por exemplo 'Comprar carro' ");
            Ambname[0] = Console.ReadLine();
            Console.WriteLine("Quanto dinheiro você precisa para atingir esse objetivo/meta?");
            value[0] = double.Parse(Console.ReadLine());
        }
        

    }
}
