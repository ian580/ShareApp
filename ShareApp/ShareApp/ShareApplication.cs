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

            var expensesPaid = _expenses
                .Where(expense => expense.PayedBy == user)
                .Select(expense => expense.Amount)
                .Sum();

            var amountPaid = _payments
                .Where(payment => payment.PayedBy == user)
                .Select(payment => payment.Amount)
                .Sum();

            var amountReceived = _payments
                .Where(payment => payment.Payee == user)
                .Select(payment => payment.Amount)
                .Sum();


            // TODO: Make this read a bit better
            var expenseBalance = expensesEach - expensesPaid;

            return amountPaid - amountReceived - expenseBalance;
        }
    }
}
