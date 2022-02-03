using Philcosa.Application.Features.CoverIssuers.Queries.GetAll;
using Philcosa.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverIssuers.Commands.AddEdit;

namespace Philcosa.Client.Infrastructure.Managers.Admin.CoverIssuer
{
    public interface ICoverIssuerManager : IManager
    {
        Task<IResult<List<GetAllCoverIssuersResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditCoverIssuerCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}