using Philcosa.Application.Features.CoverValues.Queries.GetAll;
using Philcosa.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverValues.Commands.AddEdit;

namespace Philcosa.Client.Infrastructure.Managers.Admin.CoverValue
{
    public interface ICoverValueManager : IManager
    {
        Task<IResult<List<GetAllCoverValuesResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditCoverValueCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}