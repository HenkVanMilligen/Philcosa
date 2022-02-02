using Philcosa.Application.Features.Documents.Commands.AddEdit;
using Philcosa.Application.Features.Documents.Queries.GetAll;
using Philcosa.Application.Requests.Documents;
using System.Threading.Tasks;
using Philcosa.Application.Features.Documents.Queries.GetById;
using Philcosa.Shared.Wrapper;
using Philcosa.Client.Infrastructure.Managers;

namespace Philcosa.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}