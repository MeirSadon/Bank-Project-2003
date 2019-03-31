using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_2003___Bank
{
    public class Customer
    {
        private static int numberOfCust = 1;
        private readonly int customerID;
        private readonly int customerNumber;
        public string Name { get; private set; }
        public double PhNumber { get; private set; }
        public int CustomerID
        {
            get
            {
                return this.customerID;
            }
        }
        public int CustomerNumber
        {
            get
            {
                return this.customerNumber;
            }
        }

        public Customer(int ID, string name, double phone )
        {
            customerID = ID;
            Name = name;
            PhNumber = phone;
            customerNumber = numberOfCust++;
        }
        static public bool operator ==(Customer c1, Customer c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;
            if (ReferenceEquals(c1.CustomerNumber,c2.CustomerNumber))
                return true;
            else return false;
        }
        static public bool operator !=(Customer c1, Customer c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object obj)
        {
            Customer otherCustomer = obj as Customer;
            if (otherCustomer == null)
                return false;
            return otherCustomer.CustomerNumber == this.CustomerNumber;
        }

        public override int GetHashCode()
        {
            return this.CustomerNumber;
        }

        public override string ToString()
        {
            return $"Cutomer Number: {CustomerNumber}. ID: {CustomerID}. Name: {Name}. Phone Number: {PhNumber}";
        }
    }
}