using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi2.Application.Requests.Identity;
using TestApi2.Application.Responses.Identity;
using TestApi2.Shared.Wrapper;

namespace TestApi2.Client.Infrastructure.Managers.Identity.RoleClaims
{
    public interface IRoleClaimManager : IManager
    {
        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

        Task<IResult<string>> SaveAsync(RoleClaimRequest role);

        Task<IResult<string>> DeleteAsync(string id);
    }
}