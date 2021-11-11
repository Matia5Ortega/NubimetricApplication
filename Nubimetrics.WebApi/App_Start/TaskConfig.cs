using Nubimetrics.WebApi.Controllers.Challenge4;

namespace Nubimetrics.WebApi.App_Start
{
    public class TaskConfig
    {
        public static void ExecuteTask()
        {
            CurrenciesController.SaveCurrencies();
        }
    }
}