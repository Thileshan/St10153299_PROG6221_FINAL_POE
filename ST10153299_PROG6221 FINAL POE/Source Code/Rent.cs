using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public class Rent : Expense
    {
        private double rentAmnt;

        public double RentAmnt { get => rentAmnt; set => rentAmnt = value; }

        override public double availableMoney(double grossInc)
        {
            double Money = grossInc - (rentAmnt + GetTotalExp());

            expenses.Add("Rent", Math.Round(rentAmnt, 2));

            return Money;
        }
    
    }
}
