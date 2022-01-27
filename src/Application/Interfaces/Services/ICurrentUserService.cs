using TestApi2.Application.Interfaces.Common;

namespace TestApi2.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}