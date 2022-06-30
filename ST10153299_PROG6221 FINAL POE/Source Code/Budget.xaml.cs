using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BudgetApp
{
    /// <summary>
    /// Interaction logic for Budget.xaml
    /// </summary>
    public partial class Budget : Window
    {
        public delegate void notifyUserDelegate(double incomeDel, double totalExpenseDel);

        // instant classes
        Rent r = new Rent();
        HomeLoan hl = new HomeLoan();
        Car c = new Car();

        //global variables
        double grossInc;
        public string display = "";

        Dictionary<string, double> exps = new Dictionary<string, double>();

        public Budget()
        {
            InitializeComponent();
        }

        public void CaptureIncome()
        {
            grossInc = Convert.ToDouble(tbInc.Text);
        }

        private void rbRenting_Checked(object sender, RoutedEventArgs e)
        {
            //make rent label and textbox visible
            lblRentAmnt.Visibility = Visibility.Visible;
            tbRentAmnt.Visibility = Visibility.Visible;

            lblpropPrice.Visibility = Visibility.Hidden;
            tbpropPrice.Visibility = Visibility.Hidden;
            lblDepAmnt.Visibility = Visibility.Hidden;
            tbDepAmnt.Visibility = Visibility.Hidden;
            lblIntRate.Visibility = Visibility.Hidden;
            tbIntRate.Visibility = Visibility.Hidden;
            lblTime.Visibility = Visibility.Hidden;
            cmbxTime.Visibility = Visibility.Hidden;

        }

        private void rbBuying_Checked_1(object sender, RoutedEventArgs e)
        {
            lblpropPrice.Visibility = Visibility.Visible;
            tbpropPrice.Visibility = Visibility.Visible;
            lblDepAmnt.Visibility = Visibility.Visible;
            tbDepAmnt.Visibility = Visibility.Visible;
            lblIntRate.Visibility = Visibility.Visible;
            tbIntRate.Visibility = Visibility.Visible;
            lblTime.Visibility = Visibility.Visible;
            cmbxTime.Visibility = Visibility.Visible;

            lblRentAmnt.Visibility = Visibility.Hidden;
            tbRentAmnt.Visibility = Visibility.Hidden;
            
        }

        private void rbYes_Checked_2(object sender, RoutedEventArgs e)
        {
            lblMake.Visibility = Visibility.Visible;
            tbMake.Visibility = Visibility.Visible;
            lblPrice.Visibility = Visibility.Visible;
            tbPrice.Visibility = Visibility.Visible;
            lblAmnt.Visibility = Visibility.Visible;
            tbAmnt.Visibility = Visibility.Visible;
            lblRate.Visibility = Visibility.Visible;
            tbRate.Visibility = Visibility.Visible;
            lblPrem.Visibility = Visibility.Visible;
            tbPrem.Visibility = Visibility.Visible;
        }

        private void rbNo_Checked_3(object sender, RoutedEventArgs e)
        {
            lblMake.Visibility = Visibility.Hidden;
            tbMake.Visibility = Visibility.Hidden;
            lblPrice.Visibility = Visibility.Hidden;
            tbPrice.Visibility = Visibility.Hidden;
            lblAmnt.Visibility = Visibility.Hidden;
            tbAmnt.Visibility = Visibility.Hidden;
            lblRate.Visibility = Visibility.Hidden;
            tbRate.Visibility = Visibility.Hidden;
            lblPrem.Visibility = Visibility.Hidden;
            tbPrem.Visibility = Visibility.Hidden;
        }

        private void btnSub1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CaptureIncome();
                CaptureExpense();
                MyTabControl.SelectedIndex = 1;
                tab1.Visibility = Visibility.Hidden;
                tab2.Visibility = Visibility.Visible;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message+ "\nPlease Enter An Amount For All The Fields");
                
            }
        }

        private void btnSub2_Click(object sender, RoutedEventArgs e)

        {
            if ((rbRenting.IsChecked == true) || (rbBuying.IsChecked == true)){
                if (rbRenting.IsChecked == true)
                {
                    CaptureRent();
                }
                if (rbBuying.IsChecked == true)
                {
                    CaptureBuying();
                }

                MyTabControl.SelectedIndex = 2;
                tab2.Visibility = Visibility.Hidden;
                tab3.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("PLEASE CHOOSE RENTING OR BUYING");
            }

        }

        private void btnSub3_Click(object sender, RoutedEventArgs e)
        {
            if ((rbNo.IsChecked == true) || (rbYes.IsChecked == true))
            {


                try
                {

                    if (rbYes.IsChecked == true)
                    {
                        CaptureCar();//call method
                    }

                    if (rbNo.IsChecked == true)
                    {
                        MessageBox.Show("CONTINUE>>>>");
                    }

                    MyTabControl.SelectedIndex = 3;
                    tab3.Visibility = Visibility.Hidden;
                    tab4.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("PLEASE ENSURE YOU CHOOSE YES OR NO FOR BUYING A VEHICLE");
            }
        }

       
        
        public void CaptureExpense()
        {
            double tax = Convert.ToDouble(tbTax.Text);
            double groceries = Convert.ToDouble(tbGroceries.Text);
            double utility = Convert.ToDouble(tbRates.Text);
            double phone = Convert.ToDouble(tbPhone.Text);
            double travCost = Convert.ToDouble(tbTravCost.Text);
            double othExp = Convert.ToDouble(tbOthExp.Text);

            
            exps.Add("Tax", tax);
            exps.Add("Groceries", groceries);
            exps.Add("Rates", utility);
            exps.Add("Travel", travCost);
            exps.Add("Phone", phone);
            exps.Add("Other", othExp);
        }

        public void CaptureRent()
        {
            
            r.RentAmnt = Convert.ToDouble(tbRentAmnt.Text);
            r.SetExp(exps);
            double money = r.availableMoney(grossInc);
            MessageBox.Show("AVAILABLE MONEY : " + money);

        }

        public void CaptureBuying()
        {
            hl.PropPrice = Convert.ToDouble(tbpropPrice.Text);
            hl.TotDep = Convert.ToDouble(tbDepAmnt.Text);
            hl.IntRate = Convert.ToDouble(tbIntRate.Text);
           
            if (cmbxTime.SelectedIndex == 0)
            {
               hl.Months = 240;
            }
            
            if (cmbxTime.SelectedIndex == 1)
            {
                hl.Months = 360;
            }
            hl.SetExp(exps);
            double money = hl.availableMoney(grossInc);
            MessageBox.Show("AVAILABLE MONEY : " + money);
        }
        public void CaptureCar()
        {
            try
            {
                //get values from textboxes and assign values to variables in the car class
                c.Make = tbMake.Text;
                c.PurPrice = Convert.ToDouble(tbPrice.Text);
                c.Deposit = Convert.ToDouble(tbAmnt.Text);
                c.Interest = Convert.ToDouble(tbRate.Text);
                c.Premium = Convert.ToDouble(tbPrem.Text);

                c.SetExp(exps);
                double money = c.availableMoney(grossInc);
                MessageBox.Show("AVAILABLE MONEY : " + money);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CaptureSavings()
        {
            string reason = tbReason.Text;
            double savAmnt = Convert.ToDouble(tbSave.Text);
            double intRates = Convert.ToDouble(tbintRate.Text);
            int month = Convert.ToInt32(tbMon.Text);

            double interest = intRates / 100;
            int years = month / 12;

            
            double monRepay = (savAmnt + (1 * (interest * years))) / month;
            MessageBox.Show("Reason To Save: " +reason+ "\nAmount To Be Saved: " +savAmnt+ "\nInterest Rate: " +intRates+ "\nTime Period: " +month+ "\nMonthly Savings: " +Math.Round(monRepay,2));

        }
       
        
        
        private void btnSav_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CaptureSavings();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\nPLEASE ENSURE THAT ALL FIELDS ARE FILLED OUT IN THE CORRECT FORMAT");
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            var sortedDict = from entry in exps orderby entry.Value descending select entry; 
            var lines = sortedDict.Select(kv => kv.Key + ": " + kv.Value.ToString());
            display += "Expenses\n" + string.Join(Environment.NewLine, lines);
            c.SetExp(exps);
            
            notifyUserDelegate nud = delegate (double incomeDel, double totalExpenseDel)
            {
                if (totalExpenseDel > (incomeDel * 0.75))
                {

                    display += "\nALERT!!! Your total Expenses exceed 75% of your monthly income";

                }
            };
            nud.Invoke(grossInc, c.GetTotalExp());
            MessageBox.Show(display);

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }

}
