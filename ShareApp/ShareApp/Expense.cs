namespace ShareApp
{
    /// <summary>An expense in the ShareApp</summary>
    public class Expense
    {
        public string Description { get; }

        public decimal Amount { get; }

        public User PayedBy { get; }

        public Expense(string description, decimal amount, User payedBy)
        {
            Description = description;
            Amount = amount;
            PayedBy = payedBy;
        }
    }
}
