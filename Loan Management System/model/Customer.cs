using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Management_System.model
{
    internal class Customer
    {
        int _customerID;
        string _name;
        string _emailAddress;
        string _phoneNumber;
        string _address;
        int _creditScore;
        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int CreditScore
        {
            get { return _creditScore; }
            set { _creditScore = value; }
        }

        public override string ToString()
        {
            return $"CustomerID::{CustomerID}\t Name::{Name}\t EmailAddress::{EmailAddress}\t PhoneNumber::{PhoneNumber}\t Address::{Address}\t CreditScore::{CreditScore}";
        }

        public Customer()
        {
            
        }

        public Customer(int customerID, string name, string emailAddress, string phoneNumber, string address, int creditScore)
        {
            CustomerID = customerID;
            Name = name;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Address = address;
            CreditScore = creditScore;
        }
    }
}
