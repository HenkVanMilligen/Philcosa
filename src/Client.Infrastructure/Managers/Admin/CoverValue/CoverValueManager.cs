using Philcosa.Application.Features.CoverValues.Queries.GetAll;
using Philcosa.Client.Infrastructure.Extensions;
using Philcosa.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverValues.Commands.AddEdit;

namespace Philcosa.Client.Infrastructure.Managers.Admin.CoverValue
{
    public class CoverValueManager : ICoverValueManager
    {
        private readonly HttpClient _httpClient;

        public CoverValueManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.CoverValuesEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllCoverValuesResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.CoverValuesEndpoints.GetAll);
            return await response.ToResult<List<GetAllCoverValuesResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditCoverValueCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.CoverValuesEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}