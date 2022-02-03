using Philcosa.Application.Features.Themes.Queries.GetAll;
using Philcosa.Client.Infrastructure.Extensions;
using Philcosa.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Philcosa.Application.Features.Themes.Commands.AddEdit;

namespace Philcosa.Client.Infrastructure.Managers.Admin.Theme
{
    public class ThemeManager : IThemeManager
    {
        private readonly HttpClient _httpClient;

        public ThemeManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.ThemesEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllThemesResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.ThemesEndpoints.GetAll);
            return await response.ToResult<List<GetAllThemesResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditThemeCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.ThemesEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}