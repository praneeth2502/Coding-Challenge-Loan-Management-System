using Loan_Management_System.model;
using Loan_Management_System.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loan_Management_System.Exceptions;
using System.Linq.Expressions;

namespace Loan_Management_System.Repository
{
    internal class LoanRepository:ILoanRepository
    {
        public string connectionString;
        SqlConnection sqlconnection = null;
        SqlCommand cmd = null;
        public LoanRepository()
        {
            connectionString = DBUtil.GetConnectionString();
            cmd = new SqlCommand();
        }
        public List<Loan> GetAllLoan()
        {
            List<Loan> Loanlist = new List<Loan>();
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select *from Loan";
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Loan loan = new Loan();
                    loan.LoanID = (int)reader["LoanID"];
                    loan.CustomerID = (int)reader["CustomerID"];
                    loan.PrincipalAmount = (decimal)reader["PrincipalAmount"];
                    loan.InterestRate = (decimal)reader["InterestRate"];
                    loan.LoanTerm = (int)reader["LoanTerm"];
                    loan.LoanType = (string)reader["LoanType"];
                    loan.LoanStatus = (string)reader["LoanStatus"];
                    Loanlist.Add(loan);
                }
            }
            return Loanlist;
        }
        public List<Loan> GetLoanByID(int loanId)
        {
            List<Loan> Loanlist = new List<Loan>();
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "Select *from Loan where LoanID=@LoanID";
                    cmd.Parameters.AddWithValue("@LoanID", loanId);
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Loan loan = new Loan();
                        loan.LoanID = (int)reader["LoanID"];
                        loan.CustomerID = (int)reader["CustomerID"];
                        loan.PrincipalAmount = (decimal)reader["PrincipalAmount"];
                        loan.InterestRate = (decimal)reader["InterestRate"];
                        loan.LoanTerm = (int)reader["LoanTerm"];
                        loan.LoanType = (string)reader["LoanType"];
                        loan.LoanStatus = (string)reader["LoanStatus"];
                        Loanlist.Add(loan);
                    }
                    else
                    {
                        throw new InvalidLoanException("No loan Record is found for the sepeciifed loanId");
                    }
                }
            }
            catch (InvalidLoanException ex)
            {
                Console.WriteLine("Loan Record Generation failed"+ex.Message);
            }
            return Loanlist;
        }
        public int ApplyLoan(Loan loan)
        {
            int ApplyLoanStatus = 0;
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "INSERT INTO Loan VALUES (@LoanID,@ CustomerID, @PrincipalAmount, @InterestRate, @LoanTerm, @LoanType,@oanStatus)";
                cmd.Parameters.AddWithValue("@LoanID", loan.LoanID);
                cmd.Parameters.AddWithValue("@CustomerID", loan.CustomerID);
                cmd.Parameters.AddWithValue("@PrincipalAmount", loan.PrincipalAmount);
                cmd.Parameters.AddWithValue("@InterestRate", loan.InterestRate);
                cmd.Parameters.AddWithValue("@LoanTerm", loan.LoanTerm);
                cmd.Parameters.AddWithValue("@LoanType", loan.LoanType);
                cmd.Parameters.AddWithValue("@oanStatus", loan.LoanStatus);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                ApplyLoanStatus = cmd.ExecuteNonQuery();
            }
            return ApplyLoanStatus;
        }
        public decimal calculateInterest(int loanId)
        {
            decimal Interest = 0;
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "Select *from Loan where LoanID=@LoanID";
                    cmd.Parameters.AddWithValue("@LoanID", loanId);
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Loan loan = new Loan();
                        loan.LoanID = (int)reader["LoanID"];
                        loan.CustomerID = (int)reader["CustomerID"];
                        loan.PrincipalAmount = (decimal)reader["PrincipalAmount"];
                        loan.InterestRate = (decimal)reader["InterestRate"];
                        loan.LoanTerm = (int)reader["LoanTerm"];
                        loan.LoanType = (string)reader["LoanType"];
                        loan.LoanStatus = (string)reader["LoanStatus"];
                        Interest = (loan.PrincipalAmount * loan.InterestRate * loan.LoanTerm) / 12;
                    }
                    else
                    {
                        throw new InvalidLoanException("Loan Record Not found for this Id");
                    }
                }
            }
            catch(InvalidLoanException ex)
            {
                Console.WriteLine(" Loan Record GEneration Failed"+ex.Message);
            }
            return Interest;
        }
        public decimal calculateEMI(int loanId)
        {
            decimal EMI = 0;
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "Select *from Loan where LoanID=@LoanID";
                    cmd.Parameters.AddWithValue("@LoanID", loanId);
                    cmd.Connection = sqlconnection;
                    sqlconnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Loan loan = new Loan();
                        loan.LoanID = (int)reader["LoanID"];
                        loan.CustomerID = (int)reader["CustomerID"];
                        loan.PrincipalAmount = (decimal)reader["PrincipalAmount"];
                        loan.InterestRate = (decimal)reader["InterestRate"];
                        loan.LoanTerm = (int)reader["LoanTerm"];
                        loan.LoanType = (string)reader["LoanType"];
                        loan.LoanStatus = (string)reader["LoanStatus"];
                        decimal MonthlyInterestRate = loan.InterestRate / 12 / 100;
                        EMI = (loan.PrincipalAmount * MonthlyInterestRate * (decimal)Math.Pow((1 + (double)MonthlyInterestRate), loan.LoanTerm)) / ((decimal)Math.Pow((1 + (double)MonthlyInterestRate), loan.LoanTerm) - 1);
                    }
                    else
                    {
                        throw  new InvalidLoanException("loan record not found");
                    }
                }
            }
            catch(InvalidLoanException ex)
            {
                Console.WriteLine(" Loan record generation failed"+ex.Message);
            }
            EMI = Math.Round(EMI, 2);
            return EMI;
        }
        public int loanStatus(int loanId)
        {
            int creditScore = 0;    
            using (SqlConnection sqlconnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "SELECT Customer.CreditScore FROM Customer JOIN Loan ON Customer.CustomerID = Loan.CustomerID WHERE Loan.LoanID = @LoanID";
                cmd.Parameters.AddWithValue("@LoanID", loanId);
                cmd.Connection = sqlconnection;
                sqlconnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    creditScore = (int)reader["CreditScore"];
                }

            }
            return creditScore;
        }
        public int loanRepayment(int loanId, decimal amount)
        {
            LoanRepository loanRepository = new LoanRepository();
            decimal EMI = loanRepository.calculateEMI(loanId);
            int NOEMIS = (int)(amount / EMI);
            return NOEMIS;
        }
    }
}
