using System;
using Xunit;
using pinpag_banking.Models;
using pinpag_banking.Services;

namespace PinpagBanking.Tests
{
    public class BankAccountTests
    {
        [Fact]
        public void Should_Create_Account_With_Valid_Data()
        {
            // Arrange
            var accountDto = new BankAccountDTO
            {
                ClientName = "John Doe",
                CPF = "12345678901",  // Exemplo de CPF válido
                InitialBalance = 1000m
            };

            // Act
            var account = new Account(accountDto.ClientName, accountDto.CPF, accountDto.InitialBalance);

            // Assert
            Assert.NotNull(account);
            Assert.Equal(accountDto.ClientName, account.ClientName);
            Assert.Equal(accountDto.CPF, account.CPF);
            Assert.Equal(accountDto.InitialBalance, account.Balance);
        }

        [Fact]
        public void Should_Deposit_Amount_Into_Account()
        {
            // Arrange
            var accountDto = new BankAccountDTO
            {
                ClientName = "John Doe",
                CPF = "12345678901",
                InitialBalance = 1000m
            };

            var account = new Account(accountDto.ClientName, accountDto.CPF, accountDto.InitialBalance);

            // Act
            var depositAmount = 500m;
            account.Deposit(depositAmount);

            // Assert
            Assert.Equal(1500m, account.Balance);
        }

        [Fact]
        public void Should_Throw_Exception_When_Depositing_Negative_Amount()
        {
            // Arrange
            var accountDto = new BankAccountDTO
            {
                ClientName = "John Doe",
                CPF = "12345678901",
                InitialBalance = 1000m
            };

            var account = new Account(accountDto.ClientName, accountDto.CPF, accountDto.InitialBalance);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => account.Deposit(-100m));
            Assert.Equal("Deposit amount must be greater than 0", exception.Message);
        }

        [Fact]
        public void Should_Withdraw_Amount_From_Account()
        {
            // Arrange
            var accountDto = new BankAccountDTO
            {
                ClientName = "John Doe",
                CPF = "12345678901",
                InitialBalance = 1000m
            };

            var account = new Account(accountDto.ClientName, accountDto.CPF, accountDto.InitialBalance);

            // Act
            var withdrawAmount = 500m;
            account.Withdraw(withdrawAmount);

            // Assert
            Assert.Equal(500m, account.Balance);
        }

        [Fact]
        public void Should_Throw_Exception_When_Insufficient_Funds_For_Withdrawal()
        {
            // Arrange
            var accountDto = new BankAccountDTO
            {
                ClientName = "John Doe",
                CPF = "12345678901",
                InitialBalance = 1000m
            };

            var account = new Account(accountDto.ClientName, accountDto.CPF, accountDto.InitialBalance);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => account.Withdraw(1500m));
            Assert.Equal("Insufficient funds for withdrawal", exception.Message);
        }
    }
}
