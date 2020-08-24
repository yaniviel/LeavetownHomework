using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeavetownHomework.API.Models;

namespace LeavetownHomework.API.Services
{
    public interface IInvoiceService
    {
        Task<Invoice> CalculateTaxAndCurrencyConversion(DateTime date, decimal subTotal, string currency, string paymentCurrency);
    }
}
