using TestApi2.Application.Interfaces.Common;
using TestApi2.Application.Requests.Identity;
using TestApi2.Application.Responses.Identity;
using TestApi2.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApi2.Application.Interfaces.Services.Identity
{
    public interface IRoleService : IService
    {
        Task<Result<List<RoleResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleResponse>> GetByIdAsync(string id);

        Task<Result<string>> SaveAsync(RoleRequest request);

        Task<Result<string>> DeleteAsync(string id);

        Task<Result<PermissionResponse>> GetAllPermissionsAsync(string roleId);

        Task<Result<string>> UpdatePermissionsAsync(PermissionRequest request);
    }
}