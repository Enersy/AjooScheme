using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.Domain.utility
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

       
    }
}
