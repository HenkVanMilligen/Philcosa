using TestApi2.Application.Features.Products.Commands.AddEdit;
using TestApi2.Application.Features.Products.Queries.GetAllPaged;
using TestApi2.Application.Requests.Catalog;
using TestApi2.Shared.Wrapper;
using System.Threading.Tasks;

namespace TestApi2.Client.Infrastructure.Managers.Catalog.Product
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