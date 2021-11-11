using System.Collections.Generic;

namespace Nubimetrics.Entities
{
    public class Item
    {
        public string Site_id { get; set; }
        public string Country_default_time_zone { get; set; }
        public string Query { get; set; }
        public Paging Paging { get; set; }
        public List<Results> Results { get; set; }
    }
}
