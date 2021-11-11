using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nubimetrics.Entities
{
    public class Results
    {
        public string Id { get; set; }
        public string Site_id { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public Seller Seller { get; set; }
        public string Permalink { get; set; }
    }
}
