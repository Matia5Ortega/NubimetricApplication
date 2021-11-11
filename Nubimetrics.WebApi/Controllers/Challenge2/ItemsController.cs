using Nubimetrics.Common.Utilities;
using Nubimetrics.MethodParameters;
using System.Web.Http;
using static Nubimetrics.Common.Enums.OperationResults;

namespace Nubimetrics.WebApi.Controllers.Challenge2
{
    public class ItemsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult SearchByItem([FromUri] SearchByItemIn input)
        {
            SearchByItemOut output = CachingClassFactory.GetOrCreate<BusinessComponents.Challenge2.Items>().SearchByItem(input);

            if (output.OperationResult == OperationResult.Success)
            {
                return Ok(output);
            }
            else if (output.OperationResult == OperationResult.Error_NotFound)
            {
                return NotFound();
            }

            return BadRequest();
        }
    }
}
