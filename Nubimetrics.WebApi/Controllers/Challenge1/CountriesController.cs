using BusinessComponents.Challenge1;
using Nubimetrics.Common.Utilities;
using Nubimetrics.MethodParameters;
using System.Web.Http;
using static Nubimetrics.Common.Enums.OperationResults;

namespace Nubimetrics.WebApi.Controllers.Challenge1
{
    public class CountriesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetCountryByCountryId([FromUri]CountryIn input)
        {
            CountryOut output = CachingClassFactory.GetOrCreate<Countries>().GetCountryByCountryId(input);

            if (output.OperationResult == OperationResult.Success)
            {
                return Ok(output);
            }
            else if (output.OperationResult == OperationResult.Error_Unauthorized)
            {
                return Content<CountryOut>(System.Net.HttpStatusCode.Unauthorized, output);
            }
            else if (output.OperationResult == OperationResult.Error_NotFound)
            {
                return Content<CountryOut>(System.Net.HttpStatusCode.NotFound, output);
            }

            return BadRequest();
        }
    }
}
