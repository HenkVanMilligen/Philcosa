using TestApi2.Application.Responses.Identity;
using System.Collections.Generic;

namespace TestApi2.Application.Requests.Identity
{
    public class UpdateUserRolesRequest
    {
        public string UserId { get; set; }
        public IList<UserRoleModel> UserRoles { get; set; }
    }
}