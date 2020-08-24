using System;
using Xunit;
using LeavetownHomework.API.Services;

namespace LeavetownHomework.Tests
{
    public class InvoiceServiceTests
    {
        [Theory(DisplayName = "Calculate tax for valid currency")]
        [InlineData(1000, "USD")]
        public void CalculateTax_ReturnsTenPercent(decimal subTotal, string currency)
        {
            // 1. Arrange
            var service = new InvoiceService();

            // 2. Act
            var result =  service.CalculateTax(subTotal, currency);

            // 3. Assert
            Assert.Equal(100, result);
        }

        [Theory(DisplayName = "Calculate tax for invalid currency")]
        [InlineData(12345, "DOP")]
        public void CalculateTax_ReturnsZero(decimal subTotal, string currency)
        {
            // 1. Arrange
            var service = new InvoiceService();

            // 2. Act
            var result = service.CalculateTax(subTotal, currency);

            // 3. Assert
            Assert.Equal(0, result);
        }

        [Theory(DisplayName = "Calculate tax and currency conversion")]
        [InlineData("2020-01-01", 123.45, "USD", "CAD")]
        public async void CalculateTaxAndCurrencyConversion_retunrsInvoice(DateTime date, decimal subTotal, string currency, string paymentCurrency)
        {
            // 1. Arrange
            var service = new InvoiceService();

            // 2. Act
            var result = await service.CalculateTaxAndCurrencyConversion(date, subTotal, currency, paymentCurrency);

            // 3. Assert
            Assert.NotNull(result);
            Assert.Equal(12.34M, result.Tax);
            Assert.Equal(135.79M, result.GrandTotal);
            Assert.Equal(1.29755M, result.ExchangeRate);
            Assert.Equal(176.19M, result.ConvertedTotal);
        }
    }
}
