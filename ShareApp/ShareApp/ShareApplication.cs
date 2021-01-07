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
            expense.PayedBy.IncreaseBalance(expense.Amount * ((_users.Count - 1.0m) / _users.Count));
            
            foreach (var user in _users.Except(new List<User> { expense.PayedBy }))
            {
                user.DecreaseBalance(expense.Amount / _users.Count);
            }

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
            payment.PayedBy.IncreaseBalance(payment.Amount);
            payment.Payee.DecreaseBalance(payment.Amount);
            _payments.Add(payment);
        }

        public Payment[] GetPaymentsToSettle()
        {
            // Payment from users who owe(negative balance) to user who are owed(positive balance) in amount of balance / number of people owed
            var peopleOwed = _users.Where(user => user.Balance > 0);

            var peopleWhoOwe = _users.Except(peopleOwed);

            var paymentsToSettle = new List<Payment>();

            foreach (var payer in peopleWhoOwe)
            {
                foreach (var payee in peopleOwed)
                {
                    paymentsToSettle.Add(new Payment(payer, payee, -payer.Balance / peopleOwed.Count()));
                }
            }

            return paymentsToSettle.ToArray();
        }

        public decimal GetUsersBalance(User user)
        {
            return user.Balance;
        }
    }
}
