using Philcosa.Application.Features.Brands.Queries.GetAll;
using System.Collections.Generic;
using System.Threading.Tasks;
using Philcosa.Application.Features.Brands.Commands.AddEdit;
using Philcosa.Shared.Wrapper;

namespace Philcosa.Client.Infrastructure.Managers.Catalog.Brand
{
    public interface IBrandManager : IManager
    {
        Task<IResult<List<GetAllBrandsResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditBrandCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}