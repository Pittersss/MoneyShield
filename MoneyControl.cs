using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsMoneyShield
{
     abstract class MoneyControl
    {
        private double salary;
        private double[] expenses;
        private double totality;
        //private double extra;

        public abstract void LeftOver_Calc(double salary, double expenses);

    }
}
