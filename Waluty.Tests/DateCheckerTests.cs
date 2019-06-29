using Moq;
using System;
using WalutyBusinessLogic.Services;
using Xunit;

namespace Waluty.Tests.Services
{
    public class DateCheckerTests : IDisposable
    {
        private MockRepository mockRepository;

        public DateCheckerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private DateChecker CreateDateChecker()
        {
            return new DateChecker();
        }

        [Fact]
        public void DateChecker_For_Single_Currency_Must_Return_True_On_WorkingDay()
        {
            // Arrange
            var unitUnderTest = this.CreateDateChecker();
            DateTime dateCurrency = new DateTime(2019, 1, 18);
            string nameCurrency = "USD";

            // Act
            var result = unitUnderTest.CheckingIfDateExists(
                dateCurrency,
                nameCurrency);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DateChecker_For_Single_Currency_Must_Return_False_On_Holiday()
        {
            // Arrange
            var unitUnderTest = this.CreateDateChecker();
            DateTime dateCurrency = new DateTime(2001, 06, 10);
            string nameCurrency = "USD";

            // Act
            var result = unitUnderTest.CheckingIfDateExists(
                dateCurrency,
                nameCurrency);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void DateChecker_For_Two_Currencies_Must_Return_True_On_WorkingDay()
        {
            // Arrange
            var unitUnderTest = this.CreateDateChecker();
            DateTime dateCurrency = new DateTime(2001, 06, 11);
            string firstNameCurrency = "USD";
            string secondNameCurrency = "AUD";

            // Act
            var result = unitUnderTest.CheckingIfDateExistsForTwoCurrencies(
                dateCurrency,
                firstNameCurrency,
                secondNameCurrency);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void DateChecker_For_Two_Currencies_Must_Return_False_On_Holiday()
        {
            // Arrange
            var unitUnderTest = this.CreateDateChecker();
            DateTime dateCurrency = new DateTime(2001, 06, 10);
            string firstNameCurrency = "USD";
            string secondNameCurrency = "AUD";

            // Act
            var result = unitUnderTest.CheckingIfDateExistsForTwoCurrencies(
                dateCurrency,
                firstNameCurrency,
                secondNameCurrency);

            // Assert
            Assert.False(result);
        }
    }
}
