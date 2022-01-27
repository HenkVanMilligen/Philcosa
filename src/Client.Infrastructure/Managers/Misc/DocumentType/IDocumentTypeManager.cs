using System.Collections.Generic;
using System.Threading.Tasks;
using TestApi2.Application.Features.DocumentTypes.Commands.AddEdit;
using TestApi2.Application.Features.DocumentTypes.Queries.GetAll;
using TestApi2.Shared.Wrapper;

namespace TestApi2.Client.Infrastructure.Managers.Misc.DocumentType
{
    public interface IDocumentTypeManager : IManager
    {
        Task<IResult<List<GetAllDocumentTypesResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditDocumentTypeCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}