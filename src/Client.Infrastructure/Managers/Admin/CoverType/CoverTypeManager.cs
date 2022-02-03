using Philcosa.Application.Features.CoverTypes.Queries.GetAll;
using Philcosa.Client.Infrastructure.Extensions;
using Philcosa.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverTypes.Commands.AddEdit;

namespace Philcosa.Client.Infrastructure.Managers.Admin.CoverType
{
    public class CoverTypeManager : ICoverTypeManager
    {
        private readonly HttpClient _httpClient;

        public CoverTypeManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.CoverTypesEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllCoverTypesResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.CoverTypesEndpoints.GetAll);
            return await response.ToResult<List<GetAllCoverTypesResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditCoverTypeCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.CoverTypesEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}