using Philcosa.Application.Features.Products.Commands.AddEdit;
using Philcosa.Application.Features.Products.Queries.GetAllPaged;
using Philcosa.Application.Requests.Catalog;
using System.Threading.Tasks;
using Philcosa.Shared.Wrapper;
using Philcosa.Client.Infrastructure.Managers;

namespace Philcosa.Client.Infrastructure.Managers.Catalog.Product
{
    public interface IProductManager : IManager
    {
        Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

        Task<IResult<string>> GetProductImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditProductCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}