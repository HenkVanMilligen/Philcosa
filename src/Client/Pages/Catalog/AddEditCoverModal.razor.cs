using Philcosa.Application.Features.Covers.Commands.AddEdit;
using Philcosa.Application.Requests;
using Philcosa.Client.Extensions;
using Philcosa.Shared.Constants.Application;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Blazored.FluentValidation;
using Philcosa.Application.Features.Countries.Queries.GetAll;
using Philcosa.Application.Features.CoverTypes.Queries.GetAll;
using Philcosa.Application.Features.CoverIssuers.Queries.GetAll;
using Philcosa.Application.Features.CoverValues.Queries.GetAll;
using Philcosa.Application.Features.Themes.Queries.GetAll;
using System.Linq;

namespace Philcosa.Client.Pages.Catalog
{
    public partial class AddEditCoverModal
    {
        [Inject] private Microsoft.Extensions.Localization.IStringLocalizer<AddEditCoverModal> localizer { get; set; }

        private bool resetValueOnEmptyText;
        private bool coerceText;
        private bool coerceValue;

        private FluentValidationValidator _fluentValidationValidator;
        private bool validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });

        [Parameter]
        public AddEditCoverCommand AddEditCoverModel { get; set; } = new();
        private GetAllCountriesResponse selectedCountry = new(); 
        private List<GetAllCountriesResponse> Countries = new();
        private GetAllCoverTypesResponse selectedType = new();
        private List<GetAllCoverTypesResponse> CoverTypes = new();
        private GetAllCoverIssuersResponse selectedIssuer = new();
        private List<GetAllCoverIssuersResponse> CoverIssuers = new();
        private GetAllCoverValuesResponse selectedValue = new();
        private List<GetAllCoverValuesResponse> CoverValues = new();
        private GetAllThemesResponse selectedTheme1 = new();
        private GetAllThemesResponse selectedTheme2 = new();
        private GetAllThemesResponse selectedTheme3 = new();
        private GetAllThemesResponse selectedTheme4 = new();
        private List<GetAllThemesResponse> Themes = new();

        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        [CascadingParameter] public HubConnection hubConnection { get; set; }

        public void Cancel()
        {
            MudDialog.Cancel();
        }
      

        private async Task SaveAsync()
        {
            var response = await _coverManager.SaveAsync(AddEditCoverModel);
            if (response.Succeeded)
            {
                _snackBar.Add(localizer[response.Messages[0]], Severity.Success);
                await hubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(localizer[message], Severity.Error);
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
            hubConnection = hubConnection.TryInitialize(_navigationManager);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
        }

        private async Task LoadDataAsync()
        {
            await LoadImageAsync();
            await LoadCountriesAsync();
            await LoadCoverTypesAsync();
            await LoadCoverIssuersAsync();
            await LoadCoverValuesAsync();
            await LoadThemesAsync();
        }

        #region Countries
        private async Task LoadCountriesAsync()
        {
            var data = await _countryManager.GetAllAsync();
            if (data.Succeeded)
            {
                Countries = data.Data;
            }
            selectedCountry = Countries.SingleOrDefault(x => x.Id == AddEditCoverModel.CountryId);
        }

        private async Task<IEnumerable<GetAllCountriesResponse>> SearchCountries(string search)
        {
            // In real life use an asynchronous function for fetching data from an api.
            //await Task.Delay(5);

            // if text is null or empty, show complete list
            if (string.IsNullOrEmpty(search))
                return Countries;

            return Countries.Where(x => x.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase));
        }

        private void OnCountrySelect(GetAllCountriesResponse value)
        {
            AddEditCoverModel.CountryId = value.Id;
            selectedCountry = value;
        }
        #endregion
        #region CoverTypes

        private async Task LoadCoverTypesAsync()
        {
            var data = await _coverTypeManager.GetAllAsync();
            if (data.Succeeded)
            {
                CoverTypes = data.Data;
            }
            selectedType = CoverTypes.SingleOrDefault(x => x.Id == AddEditCoverModel.CoverTypeId);
        }

        private async Task<IEnumerable<GetAllCoverTypesResponse>> SearchCoverTypes(string search)
        {
            // In real life use an asynchronous function for fetching data from an api.
            //await Task.Delay(5);

            // if text is null or empty, show complete list
            if (string.IsNullOrEmpty(search))
                return CoverTypes;

            return CoverTypes.Where(x => x.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase));
        }

        private void OnCoverTypeSelect(GetAllCoverTypesResponse value)
        {
            AddEditCoverModel.CoverTypeId = value.Id;
            selectedType = value;
        }

        #endregion
        #region CoverIssuers
        private async Task LoadCoverIssuersAsync()
        {
            var data = await _coverIssuerManager.GetAllAsync();
            if (data.Succeeded)
            {
                CoverIssuers = data.Data;
            }
            selectedIssuer = CoverIssuers.SingleOrDefault(x => x.Id == AddEditCoverModel.CoverIssuerId);
        }
        private async Task<IEnumerable<GetAllCoverIssuersResponse>> SearchCoverIssuers(string search)
        {
            // In real life use an asynchronous function for fetching data from an api.
            //await Task.Delay(5);

            // if text is null or empty, show complete list
            if (string.IsNullOrEmpty(search))
                return CoverIssuers;

            return CoverIssuers.Where(x => x.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase));
        }

        private void OnCoverIsseuerSelect(GetAllCoverIssuersResponse value)
        {
            AddEditCoverModel.CoverTypeId = value.Id;
            selectedIssuer = value;
        }
        #endregion
        #region CoverValues
        private async Task LoadCoverValuesAsync()
        {
            var data = await _coverValueManager.GetAllAsync();
            if (data.Succeeded)
            {
                CoverValues = data.Data.OrderBy(x => x.Code).ToList();
            }
            selectedValue = CoverValues.SingleOrDefault(x => x.Id == AddEditCoverModel.ValueId);
        }       

        private void OnCoverValueSelect(GetAllCoverValuesResponse value)
        {
            AddEditCoverModel.ValueId = value.Id;
            selectedValue = value;
        }

        #endregion
        #region Themes

        private async Task LoadThemesAsync()
        {
            var data = await _themeManager.GetAllAsync();
            if (data.Succeeded)
            {
                Themes = data.Data;
            }
            selectedTheme1 = Themes.SingleOrDefault(x => x.Id == AddEditCoverModel.Theme1Id);
            selectedTheme2 = Themes.SingleOrDefault(x => x.Id == AddEditCoverModel.Theme2Id);
            selectedTheme3 = Themes.SingleOrDefault(x => x.Id == AddEditCoverModel.Theme3Id);
            selectedTheme4 = Themes.SingleOrDefault(x => x.Id == AddEditCoverModel.Theme4Id);
        }

        private async Task<IEnumerable<GetAllThemesResponse>> SearchThemes(string search)
        {
            // In real life use an asynchronous function for fetching data from an api.
            //await Task.Delay(5);

            // if text is null or empty, show complete list
            if (string.IsNullOrEmpty(search))
                return Themes;

            return Themes.Where(x => x.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase));
        }

        private void OnTheme1Select(GetAllThemesResponse value)
        {
            AddEditCoverModel.Theme1Id = value.Id;
            selectedTheme1 = value;
        }

        private void OnTheme2Select(GetAllThemesResponse value)
        {
            AddEditCoverModel.Theme2Id = value.Id;
            selectedTheme2 = value;
        }

        private void OnTheme3Select(GetAllThemesResponse value)
        {
            AddEditCoverModel.Theme3Id = value.Id;
            selectedTheme3 = value;
        }

        private void OnTheme4Select(GetAllThemesResponse value)
        {
            AddEditCoverModel.Theme4Id = value.Id;
            selectedTheme4 = value;
        }
        #endregion

        private async Task LoadImageAsync()
        {
            var data = await _coverManager.GetCoverImageAsync(AddEditCoverModel.Id);
            if (data.Succeeded)
            {
                var imageData = data.Data;
                if (!string.IsNullOrEmpty(imageData))
                {
                    AddEditCoverModel.ImageDataURL = imageData;
                }
            }
        }

        private void DeleteAsync()
        {
            AddEditCoverModel.ImageDataURL = null;
            AddEditCoverModel.UploadRequest = new UploadRequest();
        }

        public IBrowserFile file { get; set; }

        private async Task UploadFiles(InputFileChangeEventArgs e)
        {
            file = e.File;
            if (file != null)
            {
                var extension = Path.GetExtension(file.Name);
                var format = "image/png";
                var imageFile = await e.File.RequestImageFileAsync(format, 400, 400);
                var buffer = new byte[imageFile.Size];
                await imageFile.OpenReadStream().ReadAsync(buffer);
                AddEditCoverModel.ImageDataURL = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                AddEditCoverModel.UploadRequest = new UploadRequest { Data = buffer, UploadType = Application.Enums.UploadType.Cover, Extension = extension };
            }
        }
    }
}