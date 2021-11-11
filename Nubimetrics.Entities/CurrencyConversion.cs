using System;

namespace Nubimetrics.Entities
{
    public class CurrencyConversion
    {
        public string Currency_base { get; set; }
        public string Currency_quote { get; set; }
        public decimal? Ratio { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Inv_rate { get; set; }
        public DateTime? Creation_date { get; set; }
        public DateTime? Valid_until { get; set; }
    }
}
