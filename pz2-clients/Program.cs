using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pz2_clients
{
    public abstract class Client
    {
        public abstract void DisplayInfo();

        public abstract bool DateChecker(DateTime date);

    }

    public class Investor : Client
    {
        public string LastName { get; set; }
        public DateTime DepositOpenDate { get; set; }
        public double DepositAmount { get; set; }
        public double DepositInterest { get; set; }

        public Investor(string lastName, DateTime depositDate, double depositAmount, double depositInteres)
        {
            LastName = lastName;
            DepositOpenDate = depositDate;
            DepositAmount = depositAmount;
            DepositInterest = depositInteres;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Investor lastname: {0}", LastName);
            Console.WriteLine("Deposit opening date: {0}", DepositOpenDate.ToShortDateString());
            Console.WriteLine("Deposit amount: {0}", DepositAmount);
            Console.WriteLine("Deposit interest: {0}", DepositInterest);
        }

        public override bool DateChecker(DateTime date)
        {
            if (DepositOpenDate == date)
                return true;
            return false;
        }
    }

    public class Creditor : Client
    {
        public string LastName { get; set; }
        public DateTime LoanIssuanceDate { get; set; }
        public double LoanAmount { get; set; }
        public double CreditInterest { get; set; }
        public double BalanceOfDebt { get; set; }


        public Creditor(string lastName, DateTime loanIssuanceDate, double loanAmount, double creditInterest,
                        double balanceOfDebt)
        {
            LastName = lastName;
            LoanIssuanceDate = loanIssuanceDate;
            LoanAmount = loanAmount;
            CreditInterest = creditInterest;
            BalanceOfDebt = balanceOfDebt;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Creditor lastname: {0}", LastName);
            Console.WriteLine("Loan issuance date: {0}", LoanIssuanceDate.ToShortDateString());
            Console.WriteLine("Loan amount: {0}", LoanAmount);
            Console.WriteLine("Credit interest: {0}", CreditInterest);
            Console.WriteLine("Balance of debt: {0}", BalanceOfDebt);
        }

        public override bool DateChecker(DateTime date)
        {
            if (LoanIssuanceDate == date)
                return true;
            return false;
        }
    }

    public class Organization : Client
    {
        public string Name { get; set; }
        public DateTime AccountOpenDate { get; set; }
        public int AccountNumber { get; set; }
        public double AmountOnAccount { get; set; }

        public Organization(string name, DateTime accountOpenDate, int accountNumber, double amountOfAccount)
        {
            Name = name;
            AccountOpenDate = accountOpenDate;
            AccountNumber = accountNumber;
            AmountOnAccount = amountOfAccount;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Organization name: {0}", Name);
            Console.WriteLine("Account opening date: {0}", AccountOpenDate.ToShortDateString());
            Console.WriteLine("Account number: {0}", AccountNumber);
            Console.WriteLine("Amount on account: {0}", AmountOnAccount);
        }
        public override bool DateChecker(DateTime date)
        {
            if (AccountOpenDate == date)
                return true;
            return false;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = -1;
            Client[] DataBase;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = Int32.Parse(sr.ReadLine());
                DataBase = new Client[n];

                for (int i = 0; i < n; i++)
                {
                    string type = sr.ReadLine();

                    if (type == "Investor")
                    {
                        DataBase[i] = new Investor(sr.ReadLine(), new DateTime(Int32.Parse(sr.ReadLine()), Int32.Parse(sr.ReadLine()),
                            Int32.Parse(sr.ReadLine())), Double.Parse(sr.ReadLine()), Double.Parse(sr.ReadLine()));
                    }

                    else if (type == "Creditor")
                    {
                        DataBase[i] = new Creditor(sr.ReadLine(), new DateTime(Int32.Parse(sr.ReadLine()), Int32.Parse(sr.ReadLine()), 
                            Int32.Parse(sr.ReadLine())), Double.Parse(sr.ReadLine()), Double.Parse(sr.ReadLine()), Double.Parse(sr.ReadLine()));
                    }

                    else if (type == "Organization")
                    {
                        DataBase[i] = new Organization(sr.ReadLine(), new DateTime(Int32.Parse(sr.ReadLine()), Int32.Parse(sr.ReadLine()), 
                            Int32.Parse(sr.ReadLine())), Int32.Parse(sr.ReadLine()), Double.Parse(sr.ReadLine()));
                    }
                }
            }

            foreach (Client client in DataBase)
            {
                client.DisplayInfo();
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Year: ");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Month: ");
            int b = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Day: ");
            int c = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            DateTime askDate = new DateTime(a, b, c);
            int foundClients = 0;

            foreach (Client client in DataBase)
            {
                if (client.DateChecker(askDate))
                {
                    client.DisplayInfo();
                    foundClients++;
                    Console.WriteLine();
                }
            }
            if (foundClients == 0)
            {
                Console.WriteLine("No clients found on this date.");
            }
            Console.ReadLine();
        }
    }
}
