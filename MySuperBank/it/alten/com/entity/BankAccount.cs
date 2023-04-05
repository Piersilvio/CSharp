using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank.it.alten.com.entity
{
    internal class BankAccount
    {
        private static int accountNumberSeed = 123456789;
        private string number;
        private string onwer;
        private decimal balance;
        private List<Transaction> allTransactions = new List<Transaction>(); //rel. 1-m. Istanzio una lista di transazioni

        //metodi di accesso
        internal string getNumber() { return this.number; }
        internal string getOnwer() { return this.onwer; }
        internal decimal getBalance() 
        {
            decimal balance = 0;

            foreach (var transaction in allTransactions)
            {
                balance += transaction.amount;
            }
            return balance;
        }

        internal void setOnwer(string owner) { this.onwer = owner; }

        //metodi

        public BankAccount(string onwer, decimal init_balance, string number = "0x00")
        {
            this.onwer = onwer;
            this.balance = init_balance;

            makeDeposite(init_balance, DateTime.Now, "initial balance");

            this.number = number;
            this.number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void makeDeposite(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "amount of deposit must be a positive");
            }
            var deposit = new Transaction(amount, note, date);
            allTransactions.Add(deposit);
        }

        public void makeWithDrawal(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "amount of withdrawal must be a positive");
            }
            if (balance - amount < 0)
            {
                throw new InvalidOperationException("not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, note, date);
            allTransactions.Add(withdrawal);
        }

        public string getAccountHistory()
        {
            var report = new StringBuilder();
            report.AppendLine("Date\t\t\tammount\t\t\tnote");
            foreach ( var transaction in allTransactions)
            {
                //record
                report.AppendLine($"{transaction.date}\t{transaction.amount}\t\t\t{transaction.notes}");
            }
            return report.ToString();
        }
    }
}
