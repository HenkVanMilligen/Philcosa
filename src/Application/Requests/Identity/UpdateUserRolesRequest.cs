using System.Collections.Generic;
using Philcosa.Application.Responses.Identity;

namespace Philcosa.Application.Requests.Identity
{
    public class UpdateUserRolesRequest
    {
        public string UserId { get; set; }
        public IList<UserRoleModel> UserRoles { get; set; }
    }
}