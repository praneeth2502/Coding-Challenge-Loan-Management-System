using Loan_Management_System.model;
using Loan_Management_System.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Management_System.Service
{
    internal class LoanService:ILoanService
    {
        readonly ILoanRepository _loanRepository;
        public LoanService()
        {
            _loanRepository = new LoanRepository();
        }
        public void GetAllLoan()
        {
            List<Loan> allLoans = _loanRepository.GetAllLoan();
            foreach(Loan loan in allLoans)
            {
                Console.WriteLine(loan);
            }
        }
        public void GetLoanByID()
        {
            Console.WriteLine("Enter the LoanID: ");
            int loanID = int.Parse(Console.ReadLine());
            List<Loan> Loanlist = _loanRepository.GetLoanByID(loanID);
            foreach (Loan loan in Loanlist)
            {
                Console.WriteLine(loan);
            }
        }
        public void ApplyLoan()
        {
            Console.WriteLine("Do you want to apply Laon: ");
            string UserUpdate = Console.ReadLine();
            if(UserUpdate == "YES")
            {
                Loan addLoan = new Loan();
                Console.WriteLine("Enter the LoanID:");
                addLoan.LoanID=int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the CustomerID: ");
                addLoan.CustomerID=int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the PrincipalAmount: ");
                addLoan.PrincipalAmount=decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter the InterestRate: ") ;
                addLoan.InterestRate=decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter the LoanTerm: ");
                addLoan.LoanTerm=int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the LoanType: ");
                addLoan.LoanType = Console.ReadLine();
                Console.WriteLine("Enter the LoanStatus: ");
                addLoan.LoanStatus = Console.ReadLine();
                int applystatus = _loanRepository.ApplyLoan(addLoan);
                if (applystatus > 0)
                {
                    Console.WriteLine("Loan record is added Successfully");
                }
            }
            else if(UserUpdate == "NO")
            {
                Console.WriteLine("Thanks for visiting Loan Management System");
            }

        }
        public   void calculateInterest()
        {
            Console.WriteLine("Enter the LoanID: ");
            int loanID = int.Parse(Console.ReadLine());
            decimal Interest = _loanRepository.calculateInterest(loanID);
            Console.WriteLine($"Interest Amount for loanId {loanID} is {Interest}");
        }
        public void calculateEMI()
        {
            Console.WriteLine("Enter the LoanID: ");
            int loanID = int.Parse(Console.ReadLine());
            decimal EMI = _loanRepository.calculateEMI(loanID);
            Console.WriteLine($"EMI Amount for loanId {loanID} is {EMI}");
        }
        public void loanRepayment()
        {
            Console.WriteLine("Enter the LoanID: ");
            int loanID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Amount: ");
            decimal Amount = decimal.Parse(Console.ReadLine());
            decimal NoEMIS= _loanRepository.loanRepayment(loanID, Amount);
            Console.WriteLine($"No of EMIs is {NoEMIS}");
        }
        public void loanStatus()
        {
            string loanstatus = "Rejected";
            Console.WriteLine("Enter the LoanID: ");
            int loanID = int.Parse(Console.ReadLine());
            int creditScore =_loanRepository.loanStatus(loanID);
            if (creditScore > 650)
            {
                loanstatus = "Accepted";
                Console.WriteLine("Loan is Accepted");
            }
            else
            {
                Console.WriteLine("Loan is Rejected");
            }
        }
    }
}
