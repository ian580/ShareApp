namespace ShareApp
{
    /// <summary>Interface for application for sharing expenses</summary>
    public interface IShareApp
    {
        /// <summary>Add a new shared expense</summary>
        /// <param name="expense"></param>
        void AddExpense(Expense expense);

        /// <summary>Get a list of the expenses</summary>
        Expense[] GetExpenses();

        /// <summary>Get the balance for the given user</summary>
        decimal GetUsersBalance(User user);

        /// <summary>Make a payement from one user to another</summary>
        void MakePayment(Payment payment);

        /// <summary>Get a list of payments that would settle all debts</summary>
        Payment[] GetPaymentsToSettle();
    }
}
