using Philcosa.Application.Features.Covers.Queries.GetAllPaged;
using Philcosa.Application.Requests.Catalog;
using Philcosa.Client.Extensions;
using Philcosa.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Philcosa.Application.Features.Covers.Commands.AddEdit;
using Philcosa.Client.Models.Catalog;
using Microsoft.AspNetCore.Components.Forms;
using Philcosa.Application.Requests;
using System.IO;
using System.Windows.Input;
using Philcosa.Client.Infrastructure.Commands;
using System.Threading;

namespace Philcosa.Client.Pages.Catalog
{
    public partial class Covers
    {
        private IEnumerable<GetAllPagedCoversResponse> pagedData;
        //private IEnumerable<GetAllPagedCoversViewModel> pagedVmData;
        private MudTable<GetAllPagedCoversResponse> table;


        private int totalItems;
        private int currentPage;
        private bool pageHasChanged = false;
        private string searchString = null;
        private bool _dense = true;
        private bool _striped = true;
        private bool _bordered = false;
        private EditCoverCommand editCoverCommand;
        [CascadingParameter] public HubConnection hubConnection { get; set; }

        protected override async Task OnInitializedAsync()
        {

            hubConnection = hubConnection.TryInitialize(_navigationManager);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
            editCoverCommand = new EditCoverCommand(EditCoverCommand_Executed);
            //await LoadData(1, 100);
        }

        private async Task<TableData<GetAllPagedCoversResponse>> ServerReload(TableState state)
        {
            if (pageHasChanged)
                await LoadData(state.Page, state.PageSize, state);
            else
                await LoadData(state.Page, 100, state);

            return new TableData<GetAllPagedCoversResponse>() { TotalItems = totalItems, Items = pagedData };
        }

        private async Task SaveAsync(AddEditCoverCommand AddEditCoverModel)
        {
            var response = await _coverManager.SaveAsync(AddEditCoverModel);
            if (response.Succeeded)
            {
                _snackBar.Add(localizer[response.Messages[0]], Severity.Success);
                await hubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(localizer[message], Severity.Error);
                }
            }
        }

        private async void EditCoverCommand_Executed(object parameter)
        {
            var response = (GetAllPagedCoversResponse)parameter;
            AddEditCoverCommand model = new()
            {
                Id = response.Id,
                CountryId = response.CountryId,
                CoverDate = response.CoverDate,
                CoverTypeId = response.CoverTypeId,
                CoverIssuerId = response.CoverIssuerId,
                Number = response.Number,
                ValueId = response.CoverValueId,
                Description = response.Description.Trim(),
                AmountIssued = response.AmountIssued,
                Atlas = response.Atlas,
                Alberta = response.Alberta,
                Theme1Id = response.Theme1Id,
                Theme2Id = response.Theme2Id,
                Theme3Id = response.Theme3Id,
                Theme4Id = response.Theme4Id

            };

            await SaveAsync(model);
        }
        private ClaimsPrincipal AuthenticationStateProviderUser { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            AuthenticationStateProviderUser = await _stateProvider.GetAuthenticationStateProviderUserAsync();
        }


        private async Task LoadData(int pageNumber, int pageSize, TableState state)
        {
            pageHasChanged = true;
            var request = new GetAllPagedCoversRequest { PageSize = pageSize, PageNumber = pageNumber + 1, SearchString = searchString };
            var response = await _coverManager.GetCoversAsync(request);
            if (response.Succeeded)
            {
                totalItems = response.TotalCount;
                currentPage = response.CurrentPage;
                var data = response.Data;
                var loadedData = data.Where(element =>
                {
                    if (string.IsNullOrWhiteSpace(searchString))
                        return true;
                    if (element.CoverDate.ToString("yyyyMMdd").Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                        return true;
                    if (element.Country?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                        return true;
                    if (element.CoverType?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                        return true;
                    if (element.CoverIssuer?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                        return true;
                    if (element.CoverValue?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                        return true;
                    if (element.Description?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                        return true;
                    return false;
                });
                switch (state.SortLabel)
                {
                    case "coverIdField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, p => p.Id);
                        break;
                    case "coverCountryField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, p => p.Country);
                        break;
                    case "coverDateField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, p => p.CoverDate);
                        break;
                    case "coverTypeField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, p => p.CoverType);
                        break;
                    case "coverIssuerField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, p => p.CoverIssuer);
                        break;
                    case "coverNumberField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, p => p.Number);
                        break;
                    case "coverValueField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, p => p.CoverValue);
                        break;
                    case "coverDescriptionField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, p => p.Description);
                        break;
                    case "coveraIssuedField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, p => p.AmountIssued);
                        break;
                }
                data = loadedData.ToList();
                pagedData = data;
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(localizer[message], Severity.Error);
                }
            }
        }

        private void OnSearch(string text)
        {
            searchString = text;            
            table.ReloadServerData();
        }

        private async Task ExportToExcel()
        {
            var base64 = await _coverManager.ExportToExcelAsync();
            await _jsRuntime.InvokeVoidAsync("Download", new
            {
                ByteArray = base64,
                FileName = $"covers_{DateTime.Now:ddMMyyyyHHmmss}.xlsx",
                MimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            });
        }

        private async Task InvokeModal(int id = 0)
        {
            var parameters = new DialogParameters();
            if (id != 0)
            {
                var cover = pagedData.FirstOrDefault(c => c.Id == id);
                if (cover != null)
                {
                    parameters.Add(nameof(AddEditCoverModal.AddEditCoverModel), new AddEditCoverCommand
                    {
                        Id = cover.Id,
                        CountryId = cover.CountryId,
                        CoverDate = cover.CoverDate,
                        CoverTypeId = cover.CoverTypeId,
                        CoverIssuerId = cover.CoverIssuerId,
                        Number = cover.Number,
                        ValueId = cover.CoverValueId,
                        Description = cover.Description,
                        AmountIssued = cover.AmountIssued,
                        Atlas = cover.Atlas,
                        Alberta = cover.Alberta,
                        Theme1Id = cover.Theme1Id,
                        Theme2Id = cover.Theme2Id,
                        Theme3Id = cover.Theme3Id,
                        Theme4Id = cover.Theme4Id

                    }) ;
                }
            }
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditCoverModal>("Modal", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                OnSearch("");
            }
        }

        private async Task Delete(int id)
        {
            string deleteContent = localizer["Delete Content"];
            var parameters = new DialogParameters
            {
                {"ContentText", string.Format(deleteContent, id)}
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>("Delete", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await _coverManager.DeleteAsync(id);
                if (response.Succeeded)
                {
                    OnSearch("");
                    await hubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                    _snackBar.Add(localizer[response.Messages[0]], Severity.Success);
                }
                else
                {
                    OnSearch("");
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(localizer[message], Severity.Error);
                    }
                }
            }
        }

        private void ShowBtnPress(int id)
        {
            Console.Out.WriteLine("test");
            var row = pagedData.FirstOrDefault(x => x.Id == id);
            row.ShowDetails = !row.ShowDetails;
        }
    }
}