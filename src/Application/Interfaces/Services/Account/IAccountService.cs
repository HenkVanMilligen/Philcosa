using System.Threading.Tasks;
using Philcosa.Application.Requests.Identity;
using Philcosa.Application.Interfaces.Common;
using Philcosa.Shared.Wrapper;

namespace Philcosa.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}