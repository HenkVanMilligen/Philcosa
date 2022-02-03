using Philcosa.Application.Features.Countries.Queries.GetAll;
using Philcosa.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Philcosa.Application.Features.Countries.Commands.AddEdit;

namespace Philcosa.Client.Infrastructure.Managers.Admin.Country
{
    public interface ICountryManager : IManager
    {
        Task<IResult<List<GetAllCountriesResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditCountryCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}