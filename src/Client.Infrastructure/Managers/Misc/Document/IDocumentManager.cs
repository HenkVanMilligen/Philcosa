using TestApi2.Application.Features.Documents.Commands.AddEdit;
using TestApi2.Application.Features.Documents.Queries.GetAll;
using TestApi2.Application.Requests.Documents;
using TestApi2.Shared.Wrapper;
using System.Threading.Tasks;
using TestApi2.Application.Features.Documents.Queries.GetById;

namespace TestApi2.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}