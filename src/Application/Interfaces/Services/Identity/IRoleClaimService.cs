using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi2.Application.Interfaces.Common;
using TestApi2.Application.Requests.Identity;
using TestApi2.Application.Responses.Identity;
using TestApi2.Shared.Wrapper;

namespace TestApi2.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}