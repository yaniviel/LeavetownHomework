using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeavetownHomework.API.Models
{
    public class Invoice
    {
        public decimal Tax { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal ConvertedTotal { get; set; }        
    }
}
