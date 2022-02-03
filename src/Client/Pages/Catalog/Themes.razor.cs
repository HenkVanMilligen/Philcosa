using Philcosa.Application.Features.Themes.Queries.GetAll;
using Philcosa.Client.Extensions;
using Philcosa.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Philcosa.Application.Features.Themes.Commands.AddEdit;

namespace Philcosa.Client.Pages.Catalog
{
    public partial class Themes 
    {
        public List<GetAllThemesResponse> ThemeList = new();
        private GetAllThemesResponse theme = new();
        private string searchString = "";
        private bool _dense = true;
        private bool _striped = true;
        private bool _bordered = false;

        protected override async Task OnInitializedAsync()
        {
            await GetThemesAsync();
            hubConnection = hubConnection.TryInitialize(_navigationManager);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
        }

        private async Task GetThemesAsync()
        {
            var response = await _themeManager.GetAllAsync();
            if (response.Succeeded)
            {
                ThemeList = response.Data.ToList();
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
                var response = await _themeManager.DeleteAsync(id);
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
                theme = ThemeList.FirstOrDefault(c => c.Id == id);
                if (theme != null)
                {
                    parameters.Add(nameof(AddEditThemeModal.AddEditThemeModel), new AddEditThemeCommand
                    {
                        Id = theme.Id,
                        Name = theme.Name
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditThemeModal>("Modal", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Reset();
            }
        }

        private async Task Reset()
        {
            theme = new GetAllThemesResponse();
            await GetThemesAsync();
        }

        private bool Search(GetAllThemesResponse theme)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;
            if (theme.Name?.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            return false;
        }
    }
}