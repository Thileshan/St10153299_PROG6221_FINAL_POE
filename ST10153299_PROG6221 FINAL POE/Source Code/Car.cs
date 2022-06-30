using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    public class Car : Expense
    {
       private string make;
       private double purPrice;
       private double deposit; 
       private double interest;
       private double premium;

        public string Make { get => make; set => make = value; }
        public double PurPrice { get => purPrice; set => purPrice = value; }
        public double Deposit { get => deposit; set => deposit = value; }
        public double Interest { get => interest; set => interest = value; }
        public double Premium { get => premium; set => premium = value; }
       

        override public double availableMoney(double grossInc)
        {
           


            double principleAmt = purPrice - deposit;
            interest = interest / 100;
            double vehCost = principleAmt * (1 + (interest * 5));
            double monthlyPay = (vehCost / 60) + premium;



            double avaMoney = grossInc - (monthlyPay + GetTotalExp());

            expenses.Add("Vehicle", Math.Round(monthlyPay, 2));

            return avaMoney;
        }


    }
}
