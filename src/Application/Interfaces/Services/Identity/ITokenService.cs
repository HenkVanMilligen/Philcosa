using TestApi2.Application.Interfaces.Common;
using TestApi2.Application.Requests.Identity;
using TestApi2.Application.Responses.Identity;
using TestApi2.Shared.Wrapper;
using System.Threading.Tasks;

namespace TestApi2.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}