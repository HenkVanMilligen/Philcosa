using System.Threading.Tasks;
using Philcosa.Application.Features.Dashboards.Queries.GetData;
using Philcosa.Shared.Wrapper;
using Philcosa.Client.Infrastructure.Managers;

namespace Philcosa.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}