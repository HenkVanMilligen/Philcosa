using TestApi2.Application.Requests;

namespace TestApi2.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}