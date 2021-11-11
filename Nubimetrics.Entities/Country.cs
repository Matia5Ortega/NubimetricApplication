using System.Collections.Generic;

namespace Nubimetrics.Entities
{
    public class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Locale { get; set; }
        public string Currency_id { get; set; }
        public string Decimal_separator { get; set; }
        public string Thousands_separator { get; set; }
        public string Time_zone { get; set; }
        public GeoInformation Geo_information { get; set; }
        public List<State> States { get; set; }
    }
}
