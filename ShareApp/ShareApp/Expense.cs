using System;

namespace Ian.ShareApp
{
    /// <summary>An expense in the ShareApp</summary>
    public class Expense
    {
        public string Description { get; }

        public decimal Amount { get; }

        public User PayedBy { get; }

        public DateTime ExpenseTime { get; }

        public Expense(string description, decimal amount, User payedBy)
        {
            if (amount < 0)
                throw new ArgumentException("Amount must be a positive amount");

            Description = description;
            Amount = amount;
            PayedBy = payedBy;
            ExpenseTime = DateTime.Now;
        }
    }
}
