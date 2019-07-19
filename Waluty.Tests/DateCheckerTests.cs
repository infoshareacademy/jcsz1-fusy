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

        [Fact]//not work
         public void DateChecker_For_Date_In_Range_Must_Return_True()
        { 
            // Arrange
            var unitUnderTest = this.CreateDateChecker();
            DateTime firstDateCurrency = new DateTime(2001, 06, 11);
            DateTime secondDateCurrency = new DateTime(2000, 01, 04);
            string secondNameCurrency = "AUD";

            // Act
            var result = unitUnderTest.CheckingIfDateExistInRange(
                firstDateCurrency,
                secondDateCurrency,
                secondNameCurrency);

            // Assert
            Assert.True(result);
        }

        [Fact]//not work
        public void DateChecker_For_Date_Out_Of_Range_Must_Return_Flase()
        {
            // Arrange
            var unitUnderTest = this.CreateDateChecker();
            DateTime firstDateCurrency = new DateTime(2001, 06, 11);
            DateTime secondDateCurrency = new DateTime(2000, 01, 04);
            string secondNameCurrency = "AUD";

            // Act
            var result = unitUnderTest.CheckingIfDateExistInRange(
                firstDateCurrency,
                secondDateCurrency,
                secondNameCurrency);

            // Assert
            Assert.True(result);
        }
    }
}
