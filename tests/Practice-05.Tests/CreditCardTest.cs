using FluentAssertions;
using Practice_05.Models;

namespace Practice_05.Tests
{
    public class CreditCardTests
    {
        [Fact]
        public void NewCreditCard_ShouldHaveCorrectInitialState()
        {
            // Arrange & Act
            var creditCard = new CreditCard();

            // Assert
            creditCard.AvailableBalance.Should().Be(500000);
            creditCard.TotalSpent.Should().Be(0);
            creditCard.DailyWithdrawalUsed.Should().Be(0);
            creditCard.RemainingDailyWithdrawalLimit.Should().Be(100000);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(5000)]
        [InlineData(10000)]
        [InlineData(20000)] // Maximum per transaction
        public void WithdrawCash_ValidAmount_ShouldUpdateBalancesCorrectly(double amount)
        {
            // Arrange
            var creditCard = new CreditCard();

            // Act
            creditCard.WithdrawCash(amount);

            // Assert
            creditCard.AvailableBalance.Should().Be(500000 - amount);
            creditCard.TotalSpent.Should().Be(amount);
            creditCard.DailyWithdrawalUsed.Should().Be(amount);
            creditCard.RemainingDailyWithdrawalLimit.Should().Be(100000 - amount);
        }

        [Fact]
        public void WithdrawCash_MultipleWithdrawalsOnSameDay_ShouldAccumulateDailyAmount()
        {
            // Arrange
            var creditCard = new CreditCard();

            // Act
            creditCard.WithdrawCash(15000);
            creditCard.WithdrawCash(10000);
            creditCard.WithdrawCash(5000);

            // Assert
            creditCard.AvailableBalance.Should().Be(470000);
            creditCard.TotalSpent.Should().Be(30000);
            creditCard.DailyWithdrawalUsed.Should().Be(30000);
            creditCard.RemainingDailyWithdrawalLimit.Should().Be(70000);
        }

        [Fact]
        public void WithdrawCash_MaximumDailyLimit_ShouldSucceed()
        {
            // Arrange
            var creditCard = new CreditCard();

            // Act - 5 transactions of 20,000 each = 100,000 (max daily limit)
            creditCard.WithdrawCash(20000);
            creditCard.WithdrawCash(20000);
            creditCard.WithdrawCash(20000);
            creditCard.WithdrawCash(20000);
            creditCard.WithdrawCash(20000);

            // Assert
            creditCard.DailyWithdrawalUsed.Should().Be(100000);
            creditCard.RemainingDailyWithdrawalLimit.Should().Be(0);
            creditCard.TotalSpent.Should().Be(100000);
        }

        [Fact]
        public void WithdrawCash_MaximumPerTransactionLimit_ShouldSucceed()
        {
            // Arrange
            var creditCard = new CreditCard();

            // Act
            creditCard.WithdrawCash(20000);

            // Assert
            creditCard.TotalSpent.Should().Be(20000);
            creditCard.DailyWithdrawalUsed.Should().Be(20000);
        }

        [Theory]
        [InlineData(20001)]
        [InlineData(25000)]
        [InlineData(50000)]
        public void WithdrawCash_ExceedsPerTransactionLimit_ShouldThrowInvalidOperationException(double amount)
        {
            // Arrange
            var creditCard = new CreditCard();

            // Act & Assert
            var exception = creditCard.Invoking(c => c.WithdrawCash(amount))
                .Should().Throw<InvalidOperationException>()
                .Which;

            exception.Message.Should().Contain("exceeds the maximum per-transaction limit");
            exception.Message.Should().Contain("20000");
        }

    }
}