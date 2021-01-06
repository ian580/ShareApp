namespace Ian.ShareApp
{
    /// <summary>A payment in the ShareApp from one user to another</summary>
    public class Payment
    {
        public User PayedBy { get; }

        public User Payee { get; }

        public decimal Amount { get; }

        public Payment(User payedBy, User payee, decimal amount)
        {
            PayedBy = payedBy;
            Payee = payee;
            Amount = amount;
        }
    }
}
