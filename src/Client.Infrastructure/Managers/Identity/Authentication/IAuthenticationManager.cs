using Philcosa.Application.Requests.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Philcosa.Shared.Wrapper;

namespace Philcosa.Client.Infrastructure.Managers.Identity.Authentication
{
    public interface IAuthenticationManager : IManager
    {
        Task<IResult> Login(TokenRequest model);

        Task<IResult> Logout();

        Task<string> RefreshToken();

        Task<string> TryRefreshToken();

        Task<string> TryForceRefreshToken();

        Task<ClaimsPrincipal> CurrentUser();
    }
}