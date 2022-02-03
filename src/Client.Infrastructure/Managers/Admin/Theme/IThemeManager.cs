using Philcosa.Application.Features.Themes.Queries.GetAll;
using Philcosa.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Philcosa.Application.Features.Themes.Commands.AddEdit;

namespace Philcosa.Client.Infrastructure.Managers.Admin.Theme
{
    public interface IThemeManager : IManager
    {
        Task<IResult<List<GetAllThemesResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditThemeCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}