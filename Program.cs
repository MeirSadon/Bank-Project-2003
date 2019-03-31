using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2003___Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank Mizrahi = new Bank();
            Customer c1 = new Customer(1, "meir", 051);
            Customer c2 = new Customer(12, "shiran", 052);
            Customer c3 = new Customer(123, "osher", 053);
            Customer c4 = new Customer(1234, "tohar", 054);
            Account a1 = new Account(c1, 4500);
            Account a2 = new Account(c1, 5000);
            Account a3 = new Account(c2, 9000);
            Account a4 = new Account(c2, 45000);
            Account a5 = new Account(c1, 2500);
            Account a6 = new Account(c3, 2500);
            Account a7 = new Account(c4, 2500);
            Account a8 = new Account(c3, 2500);
            Account a9 = new Account(c3, 2500);

            Mizrahi.AddNewCustomer(c1);
            Mizrahi.AddNewCustomer(c2);
            Mizrahi.AddNewCustomer(c3);
            Mizrahi.AddNewCustomer(c4);
            
            Mizrahi.OpenNewAccount(a1, a1.AccountOwner);
            Mizrahi.OpenNewAccount(a2, a2.AccountOwner);
            Mizrahi.OpenNewAccount(a3, a3.AccountOwner);
            Mizrahi.OpenNewAccount(a4, a4.AccountOwner);
            Mizrahi.OpenNewAccount(a5, a5.AccountOwner);
            Mizrahi.OpenNewAccount(a6, a6.AccountOwner);
            Mizrahi.OpenNewAccount(a7, a7.AccountOwner);
            Mizrahi.OpenNewAccount(a8, a8.AccountOwner);
            Mizrahi.OpenNewAccount(a9, a9.AccountOwner);

            Mizrahi.GetAccountByNumber(3);
            Mizrahi.GetAccountsByCustomer(c1);
            Mizrahi.GetCustomerByID(1);
            Mizrahi.GetCustomerByNumber(4);

            Mizrahi.Deposit(a1, 2000);
            Mizrahi.Deposit(a2, 1200);
            Mizrahi.Deposit(a3, 3500);
            Mizrahi.Deposit(a4, 3300);
            Mizrahi.Withdraw(a1, 20);

            Mizrahi.GetCustomerTotalBalance(c1);
            Mizrahi.CloseAccount(a5, c1);

            Mizrahi.ChargeAnnualCommission(1.3f);
            Mizrahi.JoinAccounts(a1, a2);
            Mizrahi.JoinAccounts(a3, a4);

            Account a = a2 + 200;
        }
    }
}
