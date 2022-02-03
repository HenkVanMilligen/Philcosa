using Philcosa.Application.Features.Covers.Queries.GetAllPaged;
using Philcosa.Client.Infrastructure.Extensions;
using Philcosa.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Philcosa.Application.Features.Covers.Commands.AddEdit;
using Philcosa.Application.Requests.Catalog;

namespace Philcosa.Client.Infrastructure.Managers.Admin.Cover
{
    public class CoverManager : ICoverManager
    {
        private readonly HttpClient _httpClient;

        public CoverManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.CoversEndpoints.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<string> ExportToExcelAsync()
        {
            var response = await _httpClient.GetAsync(Routes.CoversEndpoints.Export);
            var data = await response.Content.ReadAsStringAsync();
            return data;
        }

        public async Task<IResult<string>> GetCoverImageAsync(int id)
        {
            var response = await _httpClient.GetAsync(Routes.CoversEndpoints.GetCoverImage(id));
            return await response.ToResult<string>();
        }

        //public async Task<List<GetAllPagedCoversResponse>> GetCoversAsync(GetAllPagedCoversRequest request)
        //{
        //    var response = await _httpClient.GetAsync(Routes.CoversEndpoints.GetAllPaged(request.PageNumber, request.PageSize, request.SearchString));
        //    return await response.ToListResult<GetAllPagedCoversResponse>();
        //}

        public async Task<PaginatedResult<GetAllPagedCoversResponse>> GetCoversAsync(GetAllPagedCoversRequest request)
        {
            var response = await _httpClient.GetAsync(Routes.CoversEndpoints.GetAllPaged(request.PageNumber, request.PageSize, request.SearchString));
            return await response.ToPaginatedResult<GetAllPagedCoversResponse>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditCoverCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.CoversEndpoints.Save, request);
            return await response.ToResult<int>();
        }
    }
}