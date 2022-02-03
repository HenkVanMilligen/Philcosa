using Philcosa.Application.Features.CoverValues.Queries.GetAll;
using Philcosa.Client.Extensions;
using Philcosa.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverValues.Commands.AddEdit;

namespace Philcosa.Client.Pages.Catalog
{
    public partial class CoverValues 
    {
        public List<GetAllCoverValuesResponse> CoverValueList = new();
        private GetAllCoverValuesResponse coverValue = new();
        private string searchString = "";
        private bool _dense = true;
        private bool _striped = true;
        private bool _bordered = false;

        protected override async Task OnInitializedAsync()
        {
            await GetCoverValuesAsync();
            hubConnection = hubConnection.TryInitialize(_navigationManager);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
        }

        private async Task GetCoverValuesAsync()
        {
            var response = await _coverValueManager.GetAllAsync();
            if (response.Succeeded)
            {
                CoverValueList = response.Data.ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        [CascadingParameter] public HubConnection hubConnection { get; set; }

        private async Task Delete(int id)
        {
            string deleteContent = "Delete Content";
            var parameters = new DialogParameters();
            parameters.Add("ContentText", string.Format(deleteContent, id));
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>("Delete", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await _coverValueManager.DeleteAsync(id);
                if (response.Succeeded)
                {
                    await Reset();
                    await hubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                    _snackBar.Add(response.Messages[0], Severity.Success);
                }
                else
                {
                    await Reset();
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(message, Severity.Error);
                    }
                }
            }
        }

        private async Task InvokeModal(int id = 0)
        {
            var parameters = new DialogParameters();
            if (id != 0)
            {
                coverValue = CoverValueList.FirstOrDefault(c => c.Id == id);
                if (coverValue != null)
                {
                    parameters.Add(nameof(AddEditCoverValueModal.AddEditCoverValueModel), new AddEditCoverValueCommand
                    {
                        Id = coverValue.Id,
                        Code = coverValue.Code,
                        MinValue = coverValue.MinValue,
                        MaxValue = coverValue.MaxValue
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditCoverValueModal>("Modal", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Reset();
            }
        }

        private async Task Reset()
        {
            coverValue = new GetAllCoverValuesResponse();
            await GetCoverValuesAsync();
        }

        private bool Search(GetAllCoverValuesResponse coverValue)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;
            if (coverValue.Code?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            return false;
        }
    }
}