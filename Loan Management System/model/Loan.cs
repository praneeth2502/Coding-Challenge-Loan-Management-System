using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Management_System.model
{
    internal class Loan
    {
        int _loanId;
        int _customerID;
        decimal _principalAmount;
        decimal _interestRate;
        int _loanTerm;
        string _loanType;
        string _loanStatus;
        public int LoanID
        {
            get { return _loanId; }
            set { _loanId = value; }
        }

        public int CustomerID
        {
            get { return _customerID; }
            set { _customerID = value; }
        }

        public decimal PrincipalAmount
        {
            get { return _principalAmount; }
            set { _principalAmount = value; }
        }

        public decimal InterestRate
        {
            get { return _interestRate; }
            set { _interestRate = value; }
        }

        public int LoanTerm
        {
            get { return _loanTerm; }
            set { _loanTerm = value; }
        }

        public string LoanType
        {
            get { return _loanType; }
            set { _loanType = value; }
        }

        public string LoanStatus
        {
            get { return _loanStatus; }
            set { _loanStatus = value; }
        }

        public override string ToString()
        {
            return $"LoanId::{LoanID}\t CustomerID::{CustomerID}\t PrincipalAmount::{PrincipalAmount}\t InterestRate::{InterestRate}\t LoanTerm::{LoanTerm}\t LoanType::{LoanType}\t LoanStatus::{LoanStatus}";
        }

        public Loan()
        {
            
        }

        public Loan(int loanId, int customerID, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus)
        {
            LoanID = loanId;
            CustomerID = customerID;
            PrincipalAmount = principalAmount;
            InterestRate = interestRate;
            LoanTerm = loanTerm;
            LoanType = loanType;
            LoanStatus = loanStatus;
        }
        public class HomeLoan : Loan
        {
            public string PropertyAddress { get; set; }
            public int PropertyValue { get; set; }
        }

        public class CarLoan : Loan
        {
            public string CarModel { get; set; }
            public int CarValue { get; set; }
        }
    }
}
