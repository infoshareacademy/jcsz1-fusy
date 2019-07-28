using Moq;
using System;
using WalutyBusinessLogic.Services;
using Xunit;
using System.Threading.Tasks;
using WalutyBusinessLogic.DatabaseLoading;

namespace Waluty.Tests.Services
{
    public class DateCheckerTests : IDisposable
    {
        private MockRepository mockRepository;
        private readonly ICurrencyRepository _repository;

        public DateCheckerTests(ICurrencyRepository repository)
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            _repository = repository;
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private DateChecker CreateDateChecker(ICurrencyRepository repository)
        {
            return new DateChecker(repository);
        }

        [Fact]
        public async void DateChecker_For_Two_Currencies_Must_Return_True_On_WorkingDay()
        {
            // Arrange
            var unitUnderTest = this.CreateDateChecker(_repository);
            DateTime dateCurrency = new DateTime(2001, 06, 11);
            string firstNameCurrency = "USD";
            string secondNameCurrency = "AUD";

            // Act
            var result = await unitUnderTest.CheckingIfDateExistsForTwoCurrencies(
                dateCurrency,
                firstNameCurrency,
                secondNameCurrency);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void DateChecker_For_Two_Currencies_Must_Return_False_On_Holiday()
        {
            // Arrange
            var unitUnderTest = this.CreateDateChecker(_repository);
            DateTime dateCurrency = new DateTime(2001, 06, 10);
            string firstNameCurrency = "USD";
            string secondNameCurrency = "AUD";

            // Act
            var result = await unitUnderTest.CheckingIfDateExistsForTwoCurrencies(
                dateCurrency,
                firstNameCurrency,
                secondNameCurrency);

            // Assert
            Assert.False(result);
        }

        [Fact]
         public async void DateChecker_For_Date_In_Range_Must_Return_True()
        { 
            // Arrange
            var unitUnderTest = this.CreateDateChecker(_repository);
            DateTime firstDateCurrency = new DateTime(1995, 06, 11);
            DateTime secondDateCurrency = new DateTime(1995, 06, 20);
            string NameCurrency = "USD";

            // Act
            var result = await unitUnderTest.CheckingIfDateExistInRange(
                firstDateCurrency,
                secondDateCurrency,
                NameCurrency);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void DateChecker_For_Date_Out_Of_Range_Must_Return_Flase()
        {
            // Arrange
            var unitUnderTest = this.CreateDateChecker(_repository);
            DateTime firstDateCurrency = new DateTime(1990, 01, 29);
            DateTime secondDateCurrency = new DateTime(1991, 01, 02);
            string NameCurrency = "AUD";

            // Act
            var result = await unitUnderTest.CheckingIfDateExistInRange(
                firstDateCurrency,
                secondDateCurrency,
                NameCurrency);

            // Assert
            Assert.False(result);
        }

        [Fact]//not work
        public async void DateChecker_For_Date_In_Range_But_In_Weekend_Must_Return_Flase()
        {
            // Arrange
            var unitUnderTest = this.CreateDateChecker(_repository);
            DateTime firstDateCurrency = new DateTime(2009, 02, 07);
            DateTime secondDateCurrency = new DateTime(2009, 02, 08);
            string NameCurrency = "EUR";

            // Act
            var result = await unitUnderTest.CheckingIfDateExistInRange(
                firstDateCurrency,
                secondDateCurrency,
                NameCurrency);

            // Assert
            Assert.False(result);
        }
    }
}
