using Philcosa.Application.Features.CoverTypes.Queries.GetAll;
using Philcosa.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverTypes.Commands.AddEdit;

namespace Philcosa.Client.Infrastructure.Managers.Admin.CoverType
{
    public interface ICoverTypeManager : IManager
    {
        Task<IResult<List<GetAllCoverTypesResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditCoverTypeCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}