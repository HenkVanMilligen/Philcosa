using Philcosa.Application.Features.Covers.Queries.GetAllPaged;
using Philcosa.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Philcosa.Application.Features.Covers.Commands.AddEdit;
using Philcosa.Application.Requests.Catalog;

namespace Philcosa.Client.Infrastructure.Managers.Admin.Cover
{
    public interface ICoverManager : IManager
    {
        //Task<List<GetAllPagedCoversResponse>> GetCoversAsync(GetAllPagedCoversRequest request);
        Task<PaginatedResult<GetAllPagedCoversResponse>> GetCoversAsync(GetAllPagedCoversRequest request);
        Task<IResult<string>> GetCoverImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditCoverCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<string> ExportToExcelAsync();
    }
}