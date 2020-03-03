using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace pz2_clients
{
    /// <summary>
    /// Абстрактный класс Клиент
    /// </summary>
    [XmlInclude(typeof(Investor))]
    [XmlInclude(typeof(Creditor))]
    [XmlInclude(typeof(Organization))]
    [Serializable]
    public abstract class Client
    {
        /// <summary>
        /// Вывод в консоль информации о клиенте
        /// </summary>
        public abstract void DisplayInfo();

        /// <summary>
        /// Поиск клиента по дате
        /// </summary>
        /// <param name="date"></param>
        /// <returns>true - если клиент найдет, false - если нет</returns>
        public abstract bool DateChecker(DateTime date);

    }

    /// <summary>
    /// Класс Инвестор
    /// </summary>
    [Serializable]
    public class Investor : Client
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Дата открытия вклада
        /// </summary>
        public DateTime DepositOpenDate { get; set; }

        /// <summary>
        /// Размер вклада
        /// </summary>
        public double DepositAmount { get; set; }

        /// <summary>
        /// Процент по вкладу
        /// </summary>
        public double DepositInterest { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="depositDate">Дата открытия счета</param>
        /// <param name="depositAmount">Размер вклада</param>
        /// <param name="depositInteres">Процент по вкладу</param>
        public Investor(string lastName, DateTime depositDate, double depositAmount, double depositInteres)
        {
            LastName = lastName;
            DepositOpenDate = depositDate;
            DepositAmount = depositAmount;
            DepositInterest = depositInteres;
        }

        public Investor() { }

        /// <summary>
        /// Вывод в консоль информации о вкладчике
        /// </summary>
        public override void DisplayInfo()
        {
            Trace.WriteLine("Investor.DisplayInfo");
            Console.WriteLine("Investor lastname: {0}", LastName);
            Console.WriteLine("Deposit opening date: {0}", DepositOpenDate.ToShortDateString());
            Console.WriteLine("Deposit amount: {0}", DepositAmount);
            Console.WriteLine("Deposit interest: {0}", DepositInterest);
        }

        /// <summary>
        /// Поиск вкладчика по дате
        /// </summary>
        /// <param name="date">Дата открытия счета</param>
        /// <returns>true - если клиент найдет, false - если нет</returns>
        public override bool DateChecker(DateTime date)
        {
            Trace.WriteLine("Investor.DateChecker");
            if (DepositOpenDate == date)
                return true;
            return false;
        }
    }

    /// <summary>
    /// Класс Кредитор
    /// </summary>
    [Serializable]
    public class Creditor : Client
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Дата выдачи кредита
        /// </summary>
        public DateTime LoanIssuanceDate { get; set; }

        /// <summary>
        /// Размер кредита
        /// </summary>
        public double LoanAmount { get; set; }

        /// <summary>
        /// Процент по кредиту
        /// </summary>
        public double CreditInterest { get; set; }

        /// <summary>
        /// Остаток долга
        /// </summary>
        public double BalanceOfDebt { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="loanIssuanceDate">Дата выдачи кредита</param>
        /// <param name="loanAmount">Размер кредита</param>
        /// <param name="creditInterest">Процент по кредиту</param>
        /// <param name="balanceOfDebt">Остаток долга</param>
        public Creditor(string lastName, DateTime loanIssuanceDate, double loanAmount, double creditInterest,
                        double balanceOfDebt)
        {
            LastName = lastName;
            LoanIssuanceDate = loanIssuanceDate;
            LoanAmount = loanAmount;
            CreditInterest = creditInterest;
            BalanceOfDebt = balanceOfDebt;
        }

        public Creditor() { }

        /// <summary>
        /// Вывод в консоль информации о кредиторе
        /// </summary>
        public override void DisplayInfo()
        {
            Trace.WriteLine("Creditor.DisplayInfo");
            Console.WriteLine("Creditor lastname: {0}", LastName);
            Console.WriteLine("Loan issuance date: {0}", LoanIssuanceDate.ToShortDateString());
            Console.WriteLine("Loan amount: {0}", LoanAmount);
            Console.WriteLine("Credit interest: {0}", CreditInterest);
            Console.WriteLine("Balance of debt: {0}", BalanceOfDebt);
        }

        /// <summary>
        /// Поиск кредитора по дате
        /// </summary>
        /// <param name="date">Дата выдачи кредита</param>
        /// <returns>true - если клиент найдет, false - если нет</returns>
        public override bool DateChecker(DateTime date)
        {
            Trace.WriteLine("Creditor.DateChecker");
            if (LoanIssuanceDate == date)
                return true;
            return false;
        }
    }

    /// <summary>
    /// Класс Организация
    /// </summary>
    [Serializable]
    public class Organization : Client
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата открытия счета
        /// </summary>
        public DateTime AccountOpenDate { get; set; }

        /// <summary>
        /// Номер счета
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Сумма на счету
        /// </summary>
        public double AmountOnAccount { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="accountOpenDate">Дата открытия счета</param>
        /// <param name="accountNumber">Номер счета</param>
        /// <param name="amountOfAccount">Сумма на счету</param>
        public Organization(string name, DateTime accountOpenDate, int accountNumber, double amountOfAccount)
        {
            Name = name;
            AccountOpenDate = accountOpenDate;
            AccountNumber = accountNumber;
            AmountOnAccount = amountOfAccount;
        }

        public Organization() { }

        /// <summary>
        /// Вывод в консоль информации о организации
        /// </summary>
        public override void DisplayInfo()
        {
            Trace.WriteLine("Organization.DisplayInfo");
            Console.WriteLine("Organization name: {0}", Name);
            Console.WriteLine("Account opening date: {0}", AccountOpenDate.ToShortDateString());
            Console.WriteLine("Account number: {0}", AccountNumber);
            Console.WriteLine("Amount on account: {0}", AmountOnAccount);
        }

        /// <summary>
        /// Поиск организации по дате
        /// </summary>
        /// <param name="date">Дата открытия счета</param>
        /// <returns>true - если клиент найдет, false - если нет</returns>
        public override bool DateChecker(DateTime date)
        {
            Trace.WriteLine("Organization.DateChecker");
            if (AccountOpenDate == date)
                return true;
            return false;
        }

    }

    /// <summary>
    /// Класс программы
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        /// <param name="args">Список аргументов</param>
        static void Main(string[] args)
        {
            Trace.WriteLine("Program.Main");
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

            XmlSerializer serializer = new XmlSerializer(typeof(Client[]));
            using (StreamWriter sw = new StreamWriter("datebase.xml"))
            {
                serializer.Serialize(sw, DataBase);
            }

            Console.ReadLine();
        }
    }
}
