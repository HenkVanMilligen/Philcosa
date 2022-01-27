using TestApi2.Application.Interfaces.Common;
using TestApi2.Application.Requests.Identity;
using TestApi2.Shared.Wrapper;
using System.Threading.Tasks;

namespace TestApi2.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}