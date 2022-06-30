using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public class HomeLoan : Expense

    {
        private double propPrice;
        private double totDep;
        private double intRate;
        private int months;

        public double PropPrice { get => propPrice; set => propPrice = value; }
        public double TotDep { get => totDep; set => totDep = value; }
        public double IntRate { get => intRate; set => intRate = value; }
        public int Months { get => months; set => months = value; }

        public override double availableMoney(double grossInc)
        {
            double prinAmnt = propPrice - totDep;
            double interest = intRate / 100;
            int years = months / 12;

            // monthly repayment
            double monRepay = (prinAmnt + (1 * (interest * years))) / months;
            double money = grossInc - (monRepay + GetTotalExp());
            expenses.Add("Home Loan Repayment",Math.Round(monRepay, 2));

            return money;

           
        }

    }

}
