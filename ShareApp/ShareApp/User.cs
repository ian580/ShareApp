namespace Ian.ShareApp
{
    /// <summary>A user of the ShareApp</summary>
    public class User
    {
        public string Name { get; }

        /// <summary>User's balance where a positive balance means they are owed money</summary>
        public decimal Balance { get; private set; }

        public void IncreaseBalance(decimal amount)
        {
            Balance += amount;
        }

        public void DecreaseBalance(decimal amount)
        {
            Balance -= amount;
        }

        public User(string name)
        {
            Name = name;
            Balance = 0.0m;
        }
    }
}
