using Nubimetrics.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nubimetrics.MethodParameters
{
    public class GetUsersOut: BaseMethodOut
    {
        public List<User> Users { get; set; }
    }
}
