using Nubimetrics.Common.Utilities;
using Nubimetrics.MethodParameters;
using static Nubimetrics.Common.Enums.OperationResults;

namespace BusinessComponents.Challenge3
{
    public class Users
    {
        public GetUsersOut GetUsers()
        {
            return CachingClassFactory.GetOrCreate<DataAccess.Challenge3.Users>().GetUsers();
        }

        public AddUsersOut AddUsers(AddUsersIn input)
        {
            AddUsersOut output = new AddUsersOut() { OperationResult = OperationResult.Error_Generic };

            if (!string.IsNullOrEmpty(input?.User?.Name) && 
                !string.IsNullOrEmpty(input?.User?.LastName) && 
                !string.IsNullOrEmpty(input?.User?.Password))
            {
                output = CachingClassFactory.GetOrCreate<DataAccess.Challenge3.Users>().AddUsers(input);
            }

            return output;
        }

        public DeleteUsersOut DeleteUser(DeleteUsersIn input)
        {
            DeleteUsersOut output = new DeleteUsersOut() { OperationResult = OperationResult.Error_Generic };

            if(input.UserId > 0)
            {
                output = CachingClassFactory.GetOrCreate<DataAccess.Challenge3.Users>().DeleteUser(input);
            }

            return output;
        }

        public UpdateUsersOut UpdateUser(UpdateUsersIn input)
        {
            UpdateUsersOut output = new UpdateUsersOut() { OperationResult = OperationResult.Error_Generic };

            if(input.User != null)
            {
                output = CachingClassFactory.GetOrCreate<DataAccess.Challenge3.Users>().UpdateUser(input);
            }

            return output;
        }
    }
}
