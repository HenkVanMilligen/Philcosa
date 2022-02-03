using Philcosa.Application.Features.CoverIssuers.Queries.GetAll;
using Philcosa.Client.Infrastructure.Extensions;
using Philcosa.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverIssuers.Commands.AddEdit;

namespace Philcosa.Client.Infrastructure.Managers.Admin.CoverIssuer
{
    public class CoverIssuerManager : ICoverIssuerManager
    {
        private readonly HttpClient _httpClient;

        public CoverIssuerManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.CoverIssuersEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllCoverIssuersResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.CoverIssuersEndpoints.GetAll);
            return await response.ToResult<List<GetAllCoverIssuersResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditCoverIssuerCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.CoverIssuersEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}