using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeavetownHomework.API.Models
{
    //Model for the Fixer 3rd party API

    //JSON sample response
    //{"success":true,"query":{"from":"USD","to":"CAD","amount":10.5},"info":{"timestamp":1598049256,"rate":1.31776},
    //"date":"2020-08-21","result":13.83648}

    public class FixerConvertResponse
    {
        public bool Success { get; set; }
        public ConvertResponseQuery Query { get; set; }
        public ConvertResponseInfo Info { get; set; }
        public bool Historical { get; set; }
        public DateTime Date { get; set; }
        public decimal Result { get; set; }
    }

    public class ConvertResponseQuery
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Amount { get; set; }
    }

    public class ConvertResponseInfo
    {
        public int Timestamp { get; set; }
        public decimal Rate { get; set; }
    }
}
