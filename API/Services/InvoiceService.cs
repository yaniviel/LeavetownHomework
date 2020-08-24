using LeavetownHomework.API.Models;
using System;
using System.Threading.Tasks;

namespace LeavetownHomework.API.Services
{
    public class InvoiceService : IInvoiceService
    {
        //In a real production system that name "CalculateTaxAndCurrencyConversion" would not make sense... 
        //the method would be broken down en 2 and/or part of a larger "FinalizeInvoice()" process
        public async Task<Invoice> CalculateTaxAndCurrencyConversion(DateTime date, decimal subTotal, string currency, string paymentCurrency)
        {
            var tax = Math.Round(CalculateTax(subTotal, currency), 2);
            var grandTotal = subTotal + tax;

            //Currency conversion is made in a 3rd party API called Fixer
            var response = await FixerAPIService.Convert(date, currency, paymentCurrency, grandTotal);

            //Should add code to valide if API call was a success or a failure, the response include a success field

            var invoice = new Invoice
            {
                Tax = tax,
                GrandTotal = grandTotal,
                ExchangeRate = response.Info.Rate,
                ConvertedTotal = Math.Round(response.Result, 2)
            };

            return invoice;
        }

        //Hardcoded rates as per requirements
        internal decimal CalculateTax(decimal subTotal, string currency)
        {
            var rate = currency switch
            {
                "CAD" => 0.11M,
                "USD" => 0.1M,
                "MXN" => 0.09M,
                _ => 0M,
            };
            return subTotal * rate;
        }
    }
}
