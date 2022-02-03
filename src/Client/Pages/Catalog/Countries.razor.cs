using Philcosa.Application.Features.Countries.Queries.GetAll;
using Philcosa.Client.Extensions;
using Philcosa.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Philcosa.Application.Features.Countries.Commands.AddEdit;

namespace Philcosa.Client.Pages.Catalog
{
    public partial class Countries 
    {
        public List<GetAllCountriesResponse> CountryList = new();
        private GetAllCountriesResponse country = new();
        private string searchString = "";
        private bool _dense = true;
        private bool _striped = true;
        private bool _bordered = false;

        protected override async Task OnInitializedAsync()
        {
            await GetCountriesAsync();
            hubConnection = hubConnection.TryInitialize(_navigationManager);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
        }

        private async Task GetCountriesAsync()
        {
            var response = await _countryManager.GetAllAsync();
            if (response.Succeeded)
            {
                CountryList = response.Data.ToList();
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
                var response = await _countryManager.DeleteAsync(id);
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
                country = CountryList.FirstOrDefault(c => c.Id == id);
                if (country != null)
                {
                    parameters.Add(nameof(AddEditCountryModal.AddEditCountryModel), new AddEditCountryCommand
                    {
                        Id = country.Id,
                        Code = country.Code,
                        Name = country.Name
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditCountryModal>("Modal", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Reset();
            }
        }

        private async Task Reset()
        {
            country = new GetAllCountriesResponse();
            await GetCountriesAsync();
        }

        private bool Search(GetAllCountriesResponse brand)
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