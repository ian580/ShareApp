using System.Collections.Generic;

namespace Ian.ShareApp
{
    /// <summary>Implementation of the share app</summary>
    public class ShareApplication : IShareApp
    {
        private readonly List<User> _users;
        private readonly List<Expense> _expenses;
        private readonly List<Payment> _payments;

        public ShareApplication(List<User> users)
        {
            _users = users;
            _expenses = new List<Expense>();
            _payments = new List<Payment>();
        }

        public void AddExpense(Expense expense)
        {
            throw new System.NotImplementedException();
        }

        public Expense[] GetExpenses()
        {
            throw new System.NotImplementedException();
        }

        public Payment[] GetPaymentsToSettle()
        {
            throw new System.NotImplementedException();
        }

        public decimal GetUsersBalance(User user)
        {
            throw new System.NotImplementedException();
        }

        public void MakePayment(Payment payment)
        {
            throw new System.NotImplementedException();
        }
    }
}
