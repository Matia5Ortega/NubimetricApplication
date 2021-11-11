namespace Nubimetrics.Entities
{
    public class Currencies
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public int Decimal_places { get; set; }
        public CurrencyConversion Todolar { get; set; }
    }
}
