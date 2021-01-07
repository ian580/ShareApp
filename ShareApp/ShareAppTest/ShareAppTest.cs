using FluentAssertions;
using Ian.ShareApp;
using System;
using System.Collections.Generic;
using Xunit;

namespace Ian.ShareAppTest
{
    public class ShareAppTest
    {
        [Fact]
        public void ApplicationExists()
        {
            _ = new ShareApplication(new List<User>());
        }

        [Fact]
        public void UsersMustNotBeNull()
        {
            Action constructApp = () => new ShareApplication(null);

            constructApp.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ExpensesCanBeAdded()
        {
            // Arrange
            var user = new User("user");
            var app = new ShareApplication(new List<User> { user });

            // Act
            var expense = new Expense("hotel", 100, user);
            app.AddExpense(expense);

            // Assert
            app.GetExpenses().Should().BeEquivalentTo(new List<Expense> { expense });
        }

        [Fact]
        public void NegativeExpensesCannotBeCreated()
        {
            Action constructExpense = () => new Expense("expense", -100, new User(""));

            constructExpense.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void PaymentsCanBeMade()
        {
            // Arrange
            var user1 = new User("user");
            var user2 = new User("user");
            var app = new ShareApplication(new List<User> { user1, user2 });

            // Act
            var payment = new Payment(user1, user2, 100);
            app.MakePayment(payment);

            // Assert
            app.GetUsersBalance(user1).Should().Be(100);
            app.GetUsersBalance(user2).Should().Be(-100);
        }

        [Fact]
        public void IntegrationTest()
        {
            // Arrange
            var john = new User("John");
            var peter = new User("Peter");
            var mary = new User("Mary");

            var shareApp = new ShareApplication(new List<User> { john, peter, mary });

            // Act - add expenses
            shareApp.AddExpense(new Expense("Hotel", 500, john));
            shareApp.AddExpense(new Expense("Food", 150, mary));
            shareApp.AddExpense(new Expense("Sightseeing", 100, peter));

            // Assert - total expenses
            shareApp.GetExpenseTotal().Should().Be(750);
            
            // Assert - users' balances
            shareApp.GetUsersBalance(john).Should().BeApproximately(250.00m, 0.001m);
            shareApp.GetUsersBalance(mary).Should().BeApproximately(-100.00m, 0.001m);
            shareApp.GetUsersBalance(peter).Should().BeApproximately(-150.00m, 0.001m);

            var paymentMaryToJohn = new Payment(mary, john, 100);
            var paymentPeterToJohn = new Payment(peter, john, 150);

            // Act - get payments to settle
            var paymentsToSettle = shareApp.GetPaymentsToSettle();

            // Assert - correct payments to settle
            paymentsToSettle.Should().BeEquivalentTo(new List<Payment> { paymentMaryToJohn, paymentPeterToJohn });

            // Act - make payments
            shareApp.MakePayment(paymentMaryToJohn);
            shareApp.MakePayment(paymentPeterToJohn);

            // Assert - all settled
            shareApp.GetUsersBalance(john).Should().BeApproximately(0.0m, 0.001m);
            shareApp.GetUsersBalance(mary).Should().BeApproximately(0.0m, 0.001m);
            shareApp.GetUsersBalance(peter).Should().BeApproximately(0.0m, 0.001m);
        }
    }
}
