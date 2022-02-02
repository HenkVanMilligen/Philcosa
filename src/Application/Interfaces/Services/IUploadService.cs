using Philcosa.Application.Requests;

namespace Philcosa.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}