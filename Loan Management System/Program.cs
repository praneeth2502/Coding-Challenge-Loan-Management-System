using Loan_Management_System.Service;

namespace Loan_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILoanService loanService = new LoanService();
            //loanService.GetAllLoan();
            //loanService.GetLoanByID();
            //loanService.ApplyLoan();
            //loanService.calculateInterest();
            //loanService.calculateEMI();
            //loanService.loanRepayment();
            //loanService.loanStatus();
            while (true)
            {
                Console.WriteLine("Loan Management System Menu:");
                Console.WriteLine("1. Apply Loan");
                Console.WriteLine("2. Get All Loans");
                Console.WriteLine("3. Get Loan Details");
                Console.WriteLine("4. Loan Repayment");
                Console.WriteLine("5. Loan Status");
                Console.WriteLine("6. Calculate Interest");
                Console.WriteLine("7.Calculate EMI");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        loanService.ApplyLoan();
                        break;
                    case 2:
                        loanService.GetAllLoan();
                        break;
                    case 3:
                        loanService.GetLoanByID();
                        break;
                    case 4:
                        loanService.loanRepayment();
                        break;
                    case 5:
                        loanService.loanStatus();
                        break;
                    case 6:
                        loanService.calculateInterest();
                        break;
                    case 7:
                        loanService.calculateEMI();
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
