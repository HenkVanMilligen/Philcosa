using Philcosa.Application.Responses.Audit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Philcosa.Shared.Wrapper;
using Philcosa.Client.Infrastructure.Managers;

namespace Philcosa.Client.Infrastructure.Managers.Audit
{
    public interface IAuditManager : IManager
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync();

        Task<IResult<string>> DownloadFileAsync(string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
    }
}