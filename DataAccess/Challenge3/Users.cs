using DataAccess.Challenge3.Models;
using DataAccess.Utilities;
using Nubimetrics.Common.Utilities;
using Nubimetrics.Entities;
using Nubimetrics.MethodParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Nubimetrics.Common.Enums.OperationResults;

namespace DataAccess.Challenge3
{
    public class Users
    {
        public GetUsersOut GetUsers()
        {
            GetUsersOut output = new GetUsersOut() { OperationResult = OperationResult.Error_Generic };

            using (var dataContext = DataContextHelper.GetDataContext<Challenge3DataContext>())
            {
                var users = dataContext.GetUsers()?.ToList();

                if (users != null)
                {
                    output.Users = new List<User>();

                    foreach(var user in users)
                    {
                        output.Users.Add(new User() {

                            Id = user.Id,
                            Name = user.Name,
                            LastName = user.LastName,
                            Mail = user.Mail,
                            Password = user.Password
                        });
                    }

                    output.OperationResult = OperationResult.Success;
                    output.OperationResultMessage = Resources.SuccessMessage.Success;
                }
                else
                {
                    output.OperationResult = OperationResult.Error_NotFound;
                    output.OperationResultMessage = Resources.ErrorMessage.Error_NotFound;
                }
            }

            return output;
        }

        public AddUsersOut AddUsers (AddUsersIn input)
        {
            AddUsersOut output = new AddUsersOut();

            using (var dataContext = DataContextHelper.GetDataContext<Challenge3DataContext>())
            {
                output.OperationResult = dataContext.AddUser(input.User.Name, input.User.LastName, input.User.Mail, input.User.Password) > 0 ? OperationResult.Success : OperationResult.Error_Generic;
            }

            return output;
        }

        public DeleteUsersOut DeleteUser (DeleteUsersIn input)
        {
            DeleteUsersOut output = new DeleteUsersOut();

            using (var dataContext = DataContextHelper.GetDataContext<Challenge3DataContext>())
            {
                output.OperationResult = dataContext.DeleteUser(input.UserId) > 0 ? OperationResult.Success : OperationResult.Error_NotFound;
            }

            return output;
        }

        public UpdateUsersOut UpdateUser (UpdateUsersIn input)
        {
            UpdateUsersOut output = new UpdateUsersOut();

            using (var dataContext = DataContextHelper.GetDataContext<Challenge3DataContext>())
            {
                output.OperationResult = dataContext.UpdateUsers(input.User.Id, input.User.Name, input.User.LastName, input.User.Mail, input.User.Password) > 0 ? OperationResult.Success : OperationResult.Error_NotFound;
            }

            return output;
        }
    }
}
