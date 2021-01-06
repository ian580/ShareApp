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
        public void IntegrationTest()
        {
            // Arrange
            var john = new User("John");
            var peter = new User("Peter");
            var mary = new User("Mary");

            var shareApp = new ShareApplication(new List<User> { john, peter, mary });

            // Act
            shareApp.AddExpense(new Expense("Hotel", 500, john));
            shareApp.AddExpense(new Expense("Food", 150, mary));
            shareApp.AddExpense(new Expense("Sightseeing", 100, peter));

            // Assert
            shareApp.GetExpenseTotal().Should().Be(750);
            
            shareApp.GetUsersBalance(john).Should().Be(250);
            shareApp.GetUsersBalance(mary).Should().Be(-100);
            shareApp.GetUsersBalance(peter).Should().Be(-150);
        }
    }
}
