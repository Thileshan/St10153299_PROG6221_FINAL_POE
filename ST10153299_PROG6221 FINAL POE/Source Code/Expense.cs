using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public abstract class Expense
    {
        protected Dictionary<string, double> expenses = new Dictionary<string, double>();
        protected double totExp = 0;

        public void SetExp(Dictionary<string, double> e)
        {
            expenses = e;
        }

        public double GetTotalExp()
        {
            foreach (int value in expenses.Values)
            {
                totExp += value;
            }
            return totExp;
        }

        public abstract double availableMoney(double grossInc);
    }
}
