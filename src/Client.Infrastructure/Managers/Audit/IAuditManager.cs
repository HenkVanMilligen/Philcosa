using TestApi2.Application.Responses.Audit;
using TestApi2.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApi2.Client.Infrastructure.Managers.Audit
{
    public interface IAuditManager : IManager
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync();

        Task<IResult<string>> DownloadFileAsync(string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
    }
}