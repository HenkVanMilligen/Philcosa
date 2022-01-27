using TestApi2.Shared.Wrapper;
using System.Threading.Tasks;
using TestApi2.Application.Features.Dashboards.Queries.GetData;

namespace TestApi2.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}