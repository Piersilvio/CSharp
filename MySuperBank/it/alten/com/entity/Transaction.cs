using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank.it.alten.com.entity
{
    internal class Transaction
    {
        internal decimal amount { get; }
        internal DateTime date { get; }
        internal string notes { get; }

        public Transaction(decimal amount, string notes, DateTime date)
        {
            this.date = date;
            this.amount = amount;
            this.notes = notes;
        }
    }
}
