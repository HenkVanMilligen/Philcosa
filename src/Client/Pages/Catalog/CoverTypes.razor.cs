using Philcosa.Application.Features.CoverTypes.Queries.GetAll;
using Philcosa.Client.Extensions;
using Philcosa.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverTypes.Commands.AddEdit;

namespace Philcosa.Client.Pages.Catalog
{
    public partial class CoverTypes 
    {
        public List<GetAllCoverTypesResponse> CoverTypeList = new();
        private GetAllCoverTypesResponse coverType = new();
        private string searchString = "";
        private bool _dense = true;
        private bool _striped = true;
        private bool _bordered = false;

        protected override async Task OnInitializedAsync()
        {
            await GetCoverTypesAsync();
            hubConnection = hubConnection.TryInitialize(_navigationManager);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
        }

        private async Task GetCoverTypesAsync()
        {
            var response = await _coverTypeManager.GetAllAsync();
            if (response.Succeeded)
            {
                CoverTypeList = response.Data.ToList();
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
                var response = await _coverTypeManager.DeleteAsync(id);
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
                coverType = CoverTypeList.FirstOrDefault(c => c.Id == id);
                if (coverType != null)
                {
                    parameters.Add(nameof(AddEditCoverTypeModal.AddEditCoverTypeModel), new AddEditCoverTypeCommand
                    {
                        Id = coverType.Id,
                        Code = coverType.Code,
                        Name = coverType.Name
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditCoverTypeModal>("Modal", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Reset();
            }
        }

        private async Task Reset()
        {
            coverType = new GetAllCoverTypesResponse();
            await GetCoverTypesAsync();
        }

        private bool Search(GetAllCoverTypesResponse brand)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;
            if (brand.Name?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            return false;
        }
    }
}