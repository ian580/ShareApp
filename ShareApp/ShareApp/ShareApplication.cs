using System;
using System.Collections.Generic;
using System.Linq;

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
            _users = users ?? throw new ArgumentNullException(nameof(users));

            _expenses = new List<Expense>();
            _payments = new List<Payment>();
        }

        public void AddExpense(Expense expense)
        {
            _expenses.Add(expense);
        }

        public Expense[] GetExpenses()
        {
            return _expenses.ToArray();
        }

        public decimal GetExpenseTotal()
        {
            return _expenses.Select(expense => expense.Amount).Sum();
        }

        public void MakePayment(Payment payment)
        {
            _payments.Add(payment);
        }

        public Payment[] GetPaymentsToSettle()
        {
            throw new System.NotImplementedException();
        }

        public decimal GetUsersBalance(User user)
        {
            var expensesEach = GetExpenseTotal() / _users.Count;

            var expensesPaidAmount = _expenses
                .Where(expense => expense.PayedBy == user)
                .Select(expense => expense.Amount)
                .Sum();

            // TODO: Take into account payments already made

            return expensesPaidAmount - expensesEach;
        }
    }
}
