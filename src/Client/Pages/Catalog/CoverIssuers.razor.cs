using Philcosa.Application.Features.CoverIssuers.Queries.GetAll;
using Philcosa.Client.Extensions;
using Philcosa.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Philcosa.Application.Features.CoverIssuers.Commands.AddEdit;

namespace Philcosa.Client.Pages.Catalog

{
    public partial class CoverIssuers 
    {
        public List<GetAllCoverIssuersResponse> CoverIssuerList = new();
        private GetAllCoverIssuersResponse coverIssuer = new();
        private string searchString = "";
        private bool _dense = true;
        private bool _striped = true;
        private bool _bordered = false;

        protected override async Task OnInitializedAsync()
        {
            await GetCoverIssuersAsync();
            hubConnection = hubConnection.TryInitialize(_navigationManager);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
        }

        private async Task GetCoverIssuersAsync()
        {
            var response = await _coverIssuerManager.GetAllAsync();
            if (response.Succeeded)
            {
                CoverIssuerList = response.Data.ToList();
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
                var response = await _coverIssuerManager.DeleteAsync(id);
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
                coverIssuer = CoverIssuerList.FirstOrDefault(c => c.Id == id);
                if (coverIssuer != null)
                {
                    parameters.Add(nameof(AddEditCoverIssuerModal.AddEditCoverIssuerModel), new AddEditCoverIssuerCommand
                    {
                        Id = coverIssuer.Id,
                        Code = coverIssuer.Code,
                        Name = coverIssuer.Name
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditCoverIssuerModal>("Modal", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Reset();
            }
        }

        private async Task Reset()
        {
            coverIssuer = new GetAllCoverIssuersResponse();
            await GetCoverIssuersAsync();
        }

        private bool Search(GetAllCoverIssuersResponse brand)
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