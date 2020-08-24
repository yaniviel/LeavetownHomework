using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeavetownHomework.API.Models;
using LeavetownHomework.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeavetownHomework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }   

        [HttpGet("GetTaxAndCurrencyConversion")]
        public async Task<Invoice> Get([FromQuery] DateTime date, [FromQuery] decimal subTotal, [FromQuery] string currency, [FromQuery] string paymentCurrency)
        {
            var invoice = await _invoiceService.CalculateTaxAndCurrencyConversion(date, subTotal, currency, paymentCurrency);
            return invoice;
        }
    }
}
