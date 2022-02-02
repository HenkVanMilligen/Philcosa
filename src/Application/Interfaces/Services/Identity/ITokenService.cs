using System.Threading.Tasks;
using Philcosa.Application.Responses.Identity;
using Philcosa.Application.Interfaces.Common;
using Philcosa.Application.Requests.Identity;
using Philcosa.Shared.Wrapper;

namespace Philcosa.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}