using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.BusinessLogic
{
    public static class RequestProcessor
    {
        public static double DepositRequest(double initialBalance, double DepositAmount) 
        {
            var Balance = 0.0;

             Balance =  initialBalance + DepositAmount;

            return Balance;
        
        }

        public static double WithdrawalRequest(double initialBalance, double RequestedAmount)
        {
            var Balance = 0.0;
            if (initialBalance < RequestedAmount)
            {
                Balance = initialBalance;
            }
            else if (initialBalance > RequestedAmount)
            {
                Balance = initialBalance - RequestedAmount;
            }
            
            return Balance;
        }

        public static string GenerateAccountNumber()
        {
            Random random = new Random();
            var r = random.Next(1, 99999999);
            var AccountNum = String.Format("00{0}", r.ToString("D8"));
            return AccountNum;
        }
        public static  string GetPayDate(string payPlan)
        {
           var payDate = DateTime.Now;
            if (payPlan.Equals("Monthly"))
            {
                payDate =  MonthlyPayDate().Result;
            }
            else if (payPlan.Equals("Quarterly"))
            {
                payDate =  QuarterlyPayDate().Result;

            }
            else if (payPlan.Equals("BiAnnually"))
            {
                payDate = BiAnnualPayDate().Result;
            }

            return payDate.ToShortDateString();
        }

        private static async Task<DateTime> MonthlyPayDate()
        {
            DateTime reference = DateTime.Now;
            Calendar calendar = CultureInfo.CurrentCulture.Calendar;

            var firstdayofMonth = new DateTime(reference.Year, reference.Month, 1);
            var lastdayofMnth = new DateTime(reference.Year, reference.Month, DateTime.DaysInMonth(reference.Year, reference.Month));

            return lastdayofMnth;
        }
        private static async Task<DateTime> QuarterlyPayDate()
        {
            DateTime reference = DateTime.Now;
            Calendar calendar = CultureInfo.CurrentCulture.Calendar;

            var firstdayofMonth = new DateTime(reference.Year, reference.Month, 1);
            var lastdayofMnth = new DateTime(reference.Year, reference.Month, DateTime.DaysInMonth(reference.Year, reference.Month));

            return firstdayofMonth.AddMonths(4);
        }
        private static async Task<DateTime> BiAnnualPayDate()
        {
            DateTime reference = DateTime.Now;
            Calendar calendar = CultureInfo.CurrentCulture.Calendar;

            var firstdayofMonth = new DateTime(reference.Year, reference.Month, 1);
            var lastdayofMnth = new DateTime(reference.Year, reference.Month, DateTime.DaysInMonth(reference.Year, reference.Month));

            return firstdayofMonth.AddMonths(6);
        }




    }
}
