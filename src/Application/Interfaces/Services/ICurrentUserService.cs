using Philcosa.Application.Interfaces.Common;

namespace Philcosa.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}