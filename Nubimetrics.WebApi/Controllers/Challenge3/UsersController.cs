using Nubimetrics.Common.Utilities;
using Nubimetrics.MethodParameters;
using System.Web.Http;
using static Nubimetrics.Common.Enums.OperationResults;

namespace Nubimetrics.WebApi.Controllers.Challenge3
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            GetUsersOut output = CachingClassFactory.GetOrCreate<BusinessComponents.Challenge3.Users>().GetUsers();

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

        [HttpPost]
        public IHttpActionResult AddUsers([FromBody]AddUsersIn input)
        {
            AddUsersOut output = CachingClassFactory.GetOrCreate<BusinessComponents.Challenge3.Users>().AddUsers(input);

            if (output.OperationResult == OperationResult.Success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser([FromUri]DeleteUsersIn input)
        {
            DeleteUsersOut output = CachingClassFactory.GetOrCreate<BusinessComponents.Challenge3.Users>().DeleteUser(input);

            if (output.OperationResult == OperationResult.Success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult UpdateUser([FromBody]UpdateUsersIn input)
        {
            UpdateUsersOut output = CachingClassFactory.GetOrCreate<BusinessComponents.Challenge3.Users>().UpdateUser(input);

            if (output.OperationResult == OperationResult.Success)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
