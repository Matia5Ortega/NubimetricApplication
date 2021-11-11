using static Nubimetrics.Common.Enums.OperationResults;

namespace Nubimetrics.MethodParameters
{
    public class BaseMethodOut
    {
        public OperationResult OperationResult { get; set; }
        public string OperationResultMessage { get; set; }
    }
}
