using Nubimetrics.Entities;
using System.Collections.Generic;

namespace Nubimetrics.MethodParameters
{
    public class SaveCurrenciesOut : BaseMethodOut
    {
        public List<Currencies> Currencies { get; set; }
    }
}
