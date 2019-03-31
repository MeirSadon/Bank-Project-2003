using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2003___Bank
{
    public class Account
    {
        private static int numberOfAcc = 1;
        readonly int accountNumber;
        readonly Customer accountOwner;
        private int maxMinusAllowed;
        public int AccountNumber
        {
            get
            {
                return this.accountNumber;
            }
        }
        public int Balance { get; private set; }
        public Customer AccountOwner
        {
            get
            {
                return this.accountOwner;
            }
        }
        public int MaxMinusAllowed
        {
            get
            {
                return this.maxMinusAllowed;
            }
        }

        public Account(Customer accountOwner, int monthlyIncome)
        {
            this.accountOwner = accountOwner;
            maxMinusAllowed = monthlyIncome * 3 * -1;
            accountNumber = numberOfAcc++;
        }

        public void Add(int amount)
        {
            Balance += amount;
        }
        public void Subtract(int amount)
        {
            Balance -= Convert.ToInt32(amount);
        }
        static public bool operator ==(Account a1, Account a2)
        {
            if (ReferenceEquals(a1, null) && ReferenceEquals(a2, null))
                return true;
            if (ReferenceEquals(a1, null) || ReferenceEquals(a2, null))
                return false;
            if (ReferenceEquals(a1.AccountNumber, a2.AccountNumber))
                return true;
            else return false;
        }
        static public bool operator !=(Account a1, Account a2)
        {
            return !(a1 == a2);
        }

        public override bool Equals(object obj)
        {
            Account otherAccount = obj as Account;
            if (otherAccount == null)
                return false;
            return otherAccount.AccountNumber == this.AccountNumber;
        }

        public override int GetHashCode()
        {
            return this.AccountNumber;
        }

        static public Account operator +(Account a1, Account a2)
        {
            if (a1.accountOwner.CustomerNumber != a2.accountOwner.CustomerNumber)
                throw new NotSameCustomerException("The Customers Of Your Accounts Is Not Same!");
            Account newAccount = new Account(a1.accountOwner, Math.Max(a1.MaxMinusAllowed, a2.MaxMinusAllowed)/3*-1);
            newAccount.Balance = a1.Balance + a2.Balance; 
            return newAccount;
        }

        static public Account operator +(Account a, int amount)
        {
            Account newAccount = new Account(a.accountOwner, a.maxMinusAllowed / 3 * -1);
            newAccount.Add(amount);
            return newAccount;
        }
        static public Account operator -(int x, Account a)
        {
            Account newAccount = new Account(a.accountOwner, a.maxMinusAllowed / 3 * -1);
            newAccount.Subtract(x);
            return newAccount;
        }
        public override string ToString()
        {
            return $"Account Number: {accountNumber}. Owner is: {AccountOwner.Name}. Max Minus Allowed is: {maxMinusAllowed}. Balance: {Balance}";
        }
    }
}
