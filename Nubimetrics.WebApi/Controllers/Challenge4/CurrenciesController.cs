using Nubimetrics.Common.Utilities;
using Nubimetrics.MethodParameters;
using System.Web.Http;

namespace Nubimetrics.WebApi.Controllers.Challenge4
{
    public class CurrenciesController : ApiController
    {
        public static void SaveCurrencies()
        {
            CachingClassFactory.GetOrCreate<BusinessComponents.Challenge4.Currencies>().SaveCurrencies(new SaveCurrenciesIn());
        }
    }
}
