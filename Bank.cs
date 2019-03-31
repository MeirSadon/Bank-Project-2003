using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2003___Bank
{
    public class Bank //: IBank
    {
        //public string Name { get; }
        //
        //public string Address { get; }
        //
        //public int CustomerCount { get; }

        private List<Account> accounts = new List<Account>();
        private List<Customer> customers = new List<Customer>();
        private Dictionary<int, Customer> cusById = new Dictionary<int, Customer>();
        private Dictionary<int, Customer> cusByNumber = new Dictionary<int, Customer>();
        private Dictionary<int, Account> accByNumber = new Dictionary<int, Account>();
        private Dictionary<Customer, List<Account>> accByCustomer = new Dictionary<Customer, List<Account>>();
        private int totalMoneyInBank;
        private int profits;


        //+++++++++++  Find Customer By ID  +++++++++++++++++
        internal Customer GetCustomerByID(int customerID)
        {
            if (cusById.TryGetValue(customerID, out Customer theCustomer))
            {
                //Console.WriteLine(theCustomer);
                return theCustomer;
            }
            else
                throw new CustomerNotFoundException("Sorry but this ID is not exist in our bank");
        }

        //+++++++++++  Find Customer By Number  +++++++++++++++++
        internal Customer GetCustomerByNumber(int customerNumber)
        {
            if (cusByNumber.TryGetValue(customerNumber, out Customer theCustomer))
            {
                //Console.WriteLine(theCustomer);
                return theCustomer;
            }
            else
                throw new CustomerNotFoundException("Sorry but this Number is not exist in our bank");
        }

        //+++++++++++  Find Account By Number  +++++++++++++++++
        internal Account GetAccountByNumber(int accountNumber)
        {
            if (accByNumber.TryGetValue(accountNumber, out Account theAccount))
            {
                //Console.WriteLine(theAccount);
                return theAccount;
            }
            else
                throw new AccountNotFoundException("Sorry but this number is not exist in our bank");
        }

        //+++++++++++  Find Account By Customer  +++++++++++++++++
        internal List<Account> GetAccountsByCustomer(Customer ownerAccounts)
        {
            if (accByCustomer.TryGetValue(ownerAccounts, out List<Account> theAccounts))
            {
                for (int i = 0; i < theAccounts.Count; i++) //TEST.
                {                                           //TEST.
                    Console.WriteLine(theAccounts[i]);      //TEST.
                }                                           //TEST.
                return theAccounts;                         
            }
            else
                throw new AccountNotFoundException("Sorry but this ID is not exist in our bank");
        }

        //+++++++++++  Add New Customer  +++++++++++++++++
        internal void AddNewCustomer(Customer c)
        {
            if (c == null)
                throw new NullReferenceException("You Can't Send Null Customer");
            if (customers.Contains(c))
                throw new CustomerAlreadyExistException("Your Customer Is Already Exist In Our Bank!");
            customers.Add(c);
            cusById.Add(c.CustomerID, c);
            cusByNumber.Add(c.CustomerNumber, c);

            //customers.ForEach(cu => Console.WriteLine(cu));        
            //foreach (KeyValuePair<int,Customer> cus in cusByNumber)
            //{ 
            //    Console.WriteLine(cus.Value);
            //}
            //foreach (KeyValuePair<int, Customer> cus in cusById)   
            //{
            //    Console.WriteLine(cus.Value);
            //}
            //Console.WriteLine("\n\n");
        }

        //+++++++++++  Open New Account  +++++++++++++++++
        internal void OpenNewAccount(Account newAccount, Customer c)
        {
            if(newAccount == null)
                throw new NullReferenceException("You Can't Send Null Account");
            if(accounts.Contains(newAccount))
                throw new AccountAlreadyExistException("Your Account Is Already Exist In Our Bank!");
            if (!customers.Contains(c))
                throw new CustomerNotFoundException("Your Customer Is Not Exist In Our Bank");
            accounts.Add(newAccount);
            accByNumber.Add(newAccount.AccountNumber, newAccount);

            if (!accByCustomer.TryGetValue(c, out List<Account> customerAccounts))
            {
                customerAccounts = new List<Account>();
                customerAccounts.Add(newAccount);
                accByCustomer.Add(c, customerAccounts);
            }
            else
            {
                customerAccounts.Add(newAccount);
            }

            //accounts.ForEach(cu => Console.WriteLine(cu));
            //foreach (KeyValuePair<int, Account> acc in accByNumber)
            //{
            //    Console.WriteLine($"{acc.Value}");
            //}
            //Console.WriteLine("\n\n");
            //
            //foreach (KeyValuePair<Customer, List<Account>> acc in accByCustomer)
            //{
            //        Console.WriteLine($"The Owner Is: {acc.Key.Name}.\nAnd His Accounts Is: ");
            //    for (int i = 0; i < accByCustomer.Keys.Count; i++)
            //    {
            //            customerAccounts.ForEach(cus => Console.Write(cus + "\n"));
            //    }
            //}
            //Console.WriteLine("\n\n");
            //PrintAccByCus(accByCustomer);
        }

        //+++++++++++  Print Dictionary Of Accounts By Customers +++++++++++++++++
        private void PrintAccByCus(Dictionary<Customer, List<Account>> dict)
        {
            foreach (KeyValuePair<Customer, List<Account>> acc in dict)
            {
                Console.WriteLine($"The Owner Is: {acc.Key.Name}.\nAnd His Accounts Is: ");
                acc.Value.ForEach(c => Console.WriteLine(c));
            }
        }

        //+++++++++++  Deposit Money To Account  +++++++++++++++++
        internal int Deposit(Account to, int amount)
        {
            if (amount < 10)
                throw new NegativeDepositException("The Minimum For Deposit Money Is: 10$");
            to.Add(amount);
            totalMoneyInBank += amount;
            Console.WriteLine($"You Add {amount}$ To Your Account. Now, It Has a Total Of {to.Balance}$.");
            return to.Balance;
        }
        
        //+++++++++++  Withdraw Money From Account  +++++++++++++++++
        internal int Withdraw(Account from, int amount)
        {
            if ((from.Balance - amount) > from.MaxMinusAllowed)
            {
                from.Subtract(amount);
                Console.WriteLine($"You Withraw {amount}$ From Your Account. Now, It Has a Total Of {from.Balance}$.");
                totalMoneyInBank -= amount;
                return from.Balance;
            }
            else throw new BalanceException("If You Withraw The Amount, That You Exceed From Your Allowed Minus!");
        }
        
        //+++++++++++  Get The Total Money In Bank Of Customer  +++++++++++++++++
        internal int GetCustomerTotalBalance(Customer c)
        {
            int totalMoney = 0;
            if (accByCustomer.TryGetValue(c, out List<Account> customerAccounts))
                for (int i = 0; i < customerAccounts.Count; i++)
                {
                    totalMoney += customerAccounts[i].Balance;
                }
            else
                throw new NoAccountsException("To Your Customer Don't Have Any Accounts!");
                    return totalMoney;
        }

        //+++++++++++  Close Account  +++++++++++++++++
        internal void CloseAccount(Account a, Customer c)
        {
            if (a.AccountOwner.CustomerID == c.CustomerID && accounts.Contains(a))
            {
                accounts.Remove(a);
                if (accByCustomer.TryGetValue(c, out List<Account> customerAccounts))
                    customerAccounts.Remove(a);
                totalMoneyInBank -= a.Balance;
                if (accByNumber.TryGetValue(a.AccountNumber, out Account acc))
                {
                    accByNumber.Remove(a.AccountNumber);
                }
            }else
                throw new AccountNotFoundException("We Didn't Found The Account");
        }

        //+++++++++++  Take Commision  +++++++++++++++++
        internal void ChargeAnnualCommission(float percentage)
        {
            foreach (Account a in accounts)
            {
                float commission = a.Balance / 100 * percentage;
                a.Subtract(Convert.ToInt32(commission));
                profits += Convert.ToInt32(commission);
                Console.WriteLine($"The Commission Is: {commission}$. And The profit Is: {profits}$");
                totalMoneyInBank += Convert.ToInt32(commission);
                Console.WriteLine($"At Our Bank Have: {totalMoneyInBank}$");
            }
        }

        //+++++++++++  Join Accounts  +++++++++++++++++
        internal void JoinAccounts(Account a1, Account a2)
        {
            if (!accounts.Contains(a1) || !accounts.Contains(a2))
                throw new AccountNotFoundException("Some Of The Accounts Not Exist In Our Bank!");
            if (a1.AccountOwner.CustomerNumber != a2.AccountOwner.CustomerNumber)
                throw new NotSameCustomerException("The Accounts Is Not From Same Customer");
            Account joinAccounts = a1+a2;
            OpenNewAccount(joinAccounts, joinAccounts.AccountOwner);
            CloseAccount(a1, a1.AccountOwner);
            CloseAccount(a2, a2.AccountOwner);
            PrintAccByCus(accByCustomer);
        }

        //+++++++++++  Default Constractor  +++++++++++++++++
        internal Bank()
        {
        }

        //+++++++++++  To String  +++++++++++++++++
        public override string ToString()
        {
            string result = $"In This Bank Have {customers.Count} Customers, And {accounts.Count} Accounts!\nCustomers:\n ";
            for (int i = 0; i < customers.Count; i++)
            {
                result += $"{customers[i].Name}\n";
                accByCustomer.TryGetValue(customers[i], out List<Account> customerAccounts);
                foreach(Account acc in customerAccounts)
                {
                    result += acc.ToString();
                }
            }
            return result;

        }
    }
}