using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Nubimetrics.Common.Enums.OperationResults;

namespace Nubimetrics.WSAdapter.MethodParameters
{
    public class GetServiceOut
    {
        public Object ServiceObject { get; set; }
        public OperationResult OperationResult { get; set; }
    }
}
