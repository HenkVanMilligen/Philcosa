using System.Collections.Generic;
using System.Threading.Tasks;
using Philcosa.Application.Responses.Audit;
using Philcosa.Shared.Wrapper;

namespace Philcosa.Application.Interfaces.Services
{
    public interface IAuditService
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync(string userId);

        Task<IResult<string>> ExportToExcelAsync(string userId, string searchString = "", bool searchInOldValues = false, bool searchInNewValues = false);
    }
}